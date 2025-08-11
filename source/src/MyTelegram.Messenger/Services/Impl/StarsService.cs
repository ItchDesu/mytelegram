using System.Collections.Concurrent;
using MyTelegram.Abstractions;
using MyTelegram.Messenger.Services.Interfaces;

namespace MyTelegram.Messenger.Services.Impl;

internal sealed class StarsService : IStarsService, ISingletonDependency
{
    private readonly ConcurrentDictionary<long, long> _balance = new();

    public Task<long> GetStarsAsync(long userId)
    {
        var value = _balance.GetOrAdd(userId, 0);
        return Task.FromResult(value);
    }

    public Task AddStarsAsync(long userId, long amount)
    {
        _balance.AddOrUpdate(userId, amount, (_, existing) => existing + amount);
        return Task.CompletedTask;
    }
}