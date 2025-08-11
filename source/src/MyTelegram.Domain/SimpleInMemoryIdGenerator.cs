using System.Collections.Concurrent;

namespace MyTelegram.Domain;

public class SimpleInMemoryIdGenerator : IIdGenerator
{
    private readonly ConcurrentDictionary<string, long> _ids = new();
    public async Task<int> NextIdAsync(IdType idType,
        long id,
        int step = 1,
        CancellationToken cancellationToken = default)
    {
        var value = await NextLongIdAsync(idType, id, step, cancellationToken);

        return (int)value;
    }

    public Task<long> NextLongIdAsync(IdType idType,
        long id = 0,
        int step = 1,
        CancellationToken cancellationToken = default)
    {
        var key = $"{idType}_{id}";
        if (_ids.TryGetValue(key, out var value))
        {
            _ids.TryUpdate(key, value + step, value);
            return Task.FromResult(value + step);
        }

        var initValue = GetInitId(idType) + step;
        _ids.TryAdd(key, initValue);

        return Task.FromResult(initValue);
    }

    private static long GetInitId(IdType idType)
    {
        return idType switch
        {
            IdType.ChannelId => MyTelegramConsts.ChannelInitId,
            IdType.UserId => MyTelegramConsts.UserIdInitId + 10000,// The first 10000 users is reserved for testing
            IdType.BotUserId => MyTelegramConsts.BotUserInitId,
            IdType.ChatId => MyTelegramConsts.ChatIdInitId,
            IdType.Pts => MyTelegramConsts.PtsInitId,
            _ => 0,
        };
    }
}
