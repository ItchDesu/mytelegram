namespace MyTelegram.Messenger.Services.Filters;

public class MyCuckooFilter : ICuckooFilter, ISingletonDependency
{
    private readonly Microsoft.Cuckoo.ICuckooFilter _filter = new Microsoft.Cuckoo.CuckooFilter(capacity: 5_000_000, falsePositiveRate: 0.01);

    public Task<bool> ExistsAsync(byte[] filterKey)
    {
        return Task.FromResult(_filter.Contains(filterKey));
    }

    public Task<bool> AddAsync(byte[] filterKey)
    {
        return Task.FromResult(_filter.TryInsert(filterKey));
    }

    public Task<bool> DeleteAsync(byte[] filterKey)
    {
        return Task.FromResult(_filter.Remove(filterKey));
    }
}