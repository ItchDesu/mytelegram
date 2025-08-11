using Microsoft.Extensions.Logging;
using MyTelegram.Abstractions;

namespace MyTelegram.DataSeeder.DataSeeders;

public record GiftCodeData(string Slug, int Months);

public class GiftCodeDataSeeder(
    IDataSeeder<GiftCodeData> dataSeeder,
    ILogger<GiftCodeDataSeeder> logger) : IDataSeeder, ITransientDependency
{
    private const string FileName = "giftcodes.json";

    public Task SeedAsync()
    {
        return dataSeeder.SeedAsync(FileName, d =>
        {
            logger.LogInformation("Gift code {Slug} created for {Months} months", d.Slug, d.Months);
            return Task.CompletedTask;
        });
    }
}