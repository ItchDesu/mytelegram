using Microsoft.Extensions.Options;
using Telegram.Bot;

namespace MyTelegram.DataSeeder.Bots;

public class BotfatherBot
{
    private readonly ITelegramBotClient _botClient;
    private readonly string? _webhookUrl;

    public BotfatherBot(IOptions<MyTelegramDataSeederOptions> options)
    {
        var botOptions = options.Value.MyTelegramBotOptions;
        var baseUrl = botOptions.BotApiBaseUrl ?? "https://api.buzzster.io";
        var botClientOptions = new TelegramBotClientOptions(botOptions.BotFatherToken, baseUrl);
        _botClient = new TelegramBotClient(botClientOptions);
        _webhookUrl = botOptions.BotFatherWebHookUrl;
    }

    public async Task EnsureWebhookAsync()
    {
        if (!string.IsNullOrEmpty(_webhookUrl))
        {
            await _botClient.SetWebhook(_webhookUrl);
        }
    }
}