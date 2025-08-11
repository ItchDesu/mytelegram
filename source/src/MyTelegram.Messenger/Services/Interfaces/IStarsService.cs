namespace MyTelegram.Messenger.Services.Interfaces;

public interface IStarsService
{
    Task<long> GetStarsAsync(long userId);
    Task AddStarsAsync(long userId, long amount);
}