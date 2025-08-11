using System.Collections.Concurrent;
using System.Threading.Channels;
using Microsoft.Extensions.Logging;

namespace MyTelegram.Core;

public class MessageQueueProcessor<TData>(
    IDataProcessor<TData> dataProcessor,
    ILogger<MessageQueueProcessor<TData>> logger) : IMessageQueueProcessor<TData>
{
    private readonly TimeSpan _idleTimeSpan = TimeSpan.FromMinutes(5);
    private readonly ConcurrentDictionary<long, QueueItem> _queues = [];
    private readonly ConcurrentDictionary<long, CancellationTokenSource> _timeoutTokens = [];

    public void Enqueue(TData data, long key)
    {
        var cts = _timeoutTokens.AddOrUpdate(
            key,
            _ => new CancellationTokenSource(),
            (_, existingCts) =>
            {
                existingCts.Cancel();
                return new CancellationTokenSource();
            });

        var queue = _queues.GetOrAdd(key, _ => CreateChannel());
        if (!queue.IsProcessed)
        {
            queue.IsProcessed = true;
            _ = ProcessAsync(queue.Channel);
        }

        queue.Channel.Writer.TryWrite(data);
        _ = ProcessTimeoutTaskAsync(key, cts.Token);
    }

    public Task ProcessAsync(CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }

    private QueueItem CreateChannel()
    {
        var channel = Channel.CreateUnbounded<TData>();

        return new QueueItem(channel);
    }

    private async Task ProcessTimeoutTaskAsync(long key, CancellationToken cancellationToken)
    {
        await Task.Delay(_idleTimeSpan, cancellationToken)
            .ConfigureAwait(ConfigureAwaitOptions.SuppressThrowing);
        if (!cancellationToken.IsCancellationRequested)
        {
            ReleaseQueue(key);
        }
    }

    private void ReleaseQueue(long key)
    {
        if (_queues.TryRemove(key, out var queue))
        {
            queue.Channel.Writer.Complete();

            _timeoutTokens.TryRemove(key, out var cts);
            cts?.Cancel();
        }
    }

    private async Task ProcessAsync(Channel<TData> channel)
    {
        while (await channel.Reader.WaitToReadAsync())
        {
            await foreach (var data in channel.Reader.ReadAllAsync())
            {
                try
                {
                    await dataProcessor.ProcessAsync(data);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Process {MessageType} queue failed", typeof(TData));
                }
            }
        }
    }

    public record QueueItem(Channel<TData> Channel)
    {
        public bool IsProcessed { get; set; }
    }
}