using System.Net.Http.Json;

namespace MyTelegram.DataSeeder.Bots;

public class BotfatherClient
{
    private readonly HttpClient _httpClient;

    public BotfatherClient(IOptions<MyTelegramDataSeederOptions> options)
    {
        var botOptions = options.Value.MyTelegramBotOptions;
        var baseUrl = botOptions.BotApiBaseUrl ?? "https://api.buzzster.io";
        _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
    }

    public Task RegisterAsync(long userId, string token)
    {
        var payload = new { userId, token };
        return _httpClient.PostAsJsonAsync("/botfather/register", payload);
    }

    public Task CreateBotAsync(string token, string name, string userName)
    {
        var payload = new { token, name, userName };
        return _httpClient.PostAsJsonAsync("/botfather/create", payload);
    }
}