namespace MyTelegram.DataSeeder;

public class MyTelegramBotOptions
{
    public string BotFatherToken { get; set; } = string.Empty;
    public string? BotFatherWebHookUrl { get; set; }
    public string? StickerLoaderBotWebHookUrl { get; set; }
    public string? TestBotWebHookUrl { get; set; }
}