using System.Collections.Concurrent;
using System.Threading.Channels;
using EventFlow.Core;
using MyTelegram.Schema;

namespace MyTelegram.Services.Services;

public class InvokeAfterMsgProcessor(IHandlerHelper handlerHelper, ILogger<InvokeAfterMsgProcessor> logger) : IInvokeAfterMsgProcessor
    , ISingletonDependency
{
    private readonly CircularBuffer<long> _recentMessageIds = new(50000);
    private readonly ConcurrentDictionary<long, InvokeAfterMsgItem> _requests = new();
    private readonly System.Threading.Channels.Channel<long> _completedReqMsgIds = Channel.CreateUnbounded<long>();

    public void AddToRecentMessageIdList(long messageId)
    {
        _recentMessageIds.Put(messageId);
    }

    public bool ExistsInRecentMessageId(long messageId)
    {
        return _recentMessageIds.Contains(messageId);
    }

    public void Enqueue(long reqMsgId,
        IRequestInput input,
        IObject query)
    {
        _requests.TryAdd(reqMsgId, new InvokeAfterMsgItem(input, query));
    }

    public ValueTask AddCompletedReqMsgIdAsync(long reqMsgId)
    {
        return _completedReqMsgIds.Writer.WriteAsync(reqMsgId);
    }

    public async Task ProcessAsync()
    {
        while (await _completedReqMsgIds.Reader.WaitToReadAsync().ConfigureAwait(false))
        {
            if (_completedReqMsgIds.Reader.TryRead(out var reqMsgId))
            {
                try
                {
                    await HandleAsync(reqMsgId);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "InvokeAfterMsg failed");
                }
            }
        }
    }

    public Task HandleAsync(long reqMsgId)
    {
        if (_requests.TryGetValue(reqMsgId, out var item))
        {
            if (!handlerHelper.TryGetHandler(item.Query.ConstructorId, out var handler))
            {
                throw new NotImplementedException($"Not supported query: {item.Query.ConstructorId:x2}");
            }

            return handler.HandleAsync(item.Input, item.Query);
        }

        return Task.CompletedTask;
    }

    public Task<IObject> HandleAsync(IRequestInput input,
        IObject query)
    {
        if (!handlerHelper.TryGetHandler(query.ConstructorId, out var handler))
        {
            throw new NotSupportedException($"Not supported query:{query.ConstructorId:x2}");
        }

        return handler.HandleAsync(input, query);
    }
}