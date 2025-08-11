using EventFlow.Queries;
using MyTelegram.Queries;

namespace MyTelegram.DataSeeder;

public class MyTelegramDataSeederBackgroundService(
    IDataSeederService dataSeederService,
    IDataSeederHelper dataSeederHelper,
    IMongoDbIndexesCreator mongoDbIndexesCreator,
    IQueryProcessor queryProcessor) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await mongoDbIndexesCreator.CreateAllIndexesAsync();
        var myTelegramUserReadModel =
            await queryProcessor.ProcessAsync(new GetUserByIdQuery(MyTelegramConsts.OfficialUserId),
                stoppingToken);
        if (myTelegramUserReadModel == null)
        {
            await dataSeederHelper.ResetDataSeederConfigAsync();
        }
        //var aggregate = new UserAggregate(UserId.Create(MyTelegramConsts.OfficialUserId));
        //await aggregate.LoadAsync(eventStore, snapshotStore, stoppingToken);
        //if (aggregate.IsNew)
        //{
        //    await dataSeederHelper.ResetDataSeederConfigAsync();
        //}

        await dataSeederService.SeedAllAsync();
    }
}