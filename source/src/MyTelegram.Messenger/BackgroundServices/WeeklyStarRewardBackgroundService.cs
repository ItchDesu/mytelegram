using EventFlow.Queries;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyTelegram.Messenger.Services.Interfaces;
using MyTelegram.Queries;
using MyTelegram;

namespace MyTelegram.Messenger.BackgroundServices;

internal sealed class WeeklyStarRewardBackgroundService(
    IQueryProcessor queryProcessor,
    IStarsService starsService,
    ILogger<WeeklyStarRewardBackgroundService> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await GrantAsync(stoppingToken);
            await Task.Delay(TimeSpan.FromDays(7), stoppingToken);
        }
    }

    private async Task GrantAsync(CancellationToken cancellationToken)
    {
        var maxUserId = await queryProcessor.ProcessAsync(new GetMaxUserIdQuery(), cancellationToken);
        for (long userId = MyTelegramConsts.UserIdInitId; userId <= maxUserId; userId++)
        {
            var user = await queryProcessor.ProcessAsync(new GetUserByIdQuery(userId), cancellationToken);
            if (user?.Premium == true)
            {
                await starsService.AddStarsAsync(userId, 100);
                logger.LogInformation("Granted weekly stars to {UserId}", userId);
            }
        }
    }
}