using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MyTelegram.SmsSender;

public class LiberlandSmsSender : ISmsSender, ITransientDependency
{
    private readonly IOptionsMonitor<LiberlandSmsOptions> _options;
    private readonly ILogger<LiberlandSmsSender> _logger;
    private readonly HttpClient _httpClient;

    public LiberlandSmsSender(IOptionsMonitor<LiberlandSmsOptions> options, ILogger<LiberlandSmsSender> logger, HttpClient httpClient)
    {
        _options = options;
        _logger = logger;
        _httpClient = httpClient;
    }

    public bool Enabled => _options.CurrentValue.Enabled;

    public async Task SendAsync(SmsMessage smsMessage)
    {
        if (!Enabled)
        {
            _logger.LogWarning("Liberland SMS sender disabled, the code will not be sent. PhoneNumber: {To}, Text: {Text}", smsMessage.PhoneNumber, smsMessage.Text);
            return;
        }

        var phoneNumber = smsMessage.PhoneNumber;

        if (!phoneNumber.StartsWith("+"))
        {
            phoneNumber = $"+{phoneNumber}";
        }

        if (!phoneNumber.StartsWith("+901"))
        {
            _logger.LogWarning("Nmero no permitido: {PhoneNumber}", phoneNumber);
            return;
        }

        var payload = new
        {
            to = phoneNumber,
            from = _options.CurrentValue.BrandName,
            message = smsMessage.Text
        };

        var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

        var uri = "https://sms.buzzster.io/sms";

        HttpResponseMessage response;
        try
        {
            response = await _httpClient.PostAsync(uri, content);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al enviar SMS a {PhoneNumber}", phoneNumber);
            return;
        }

        var responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("Error enviando SMS a {PhoneNumber}: {StatusCode} - {Response}", phoneNumber, response.StatusCode, responseContent);
        }
        else
        {
            _logger.LogInformation("Send SMS completed. To={To}, StatusCode={StatusCode}, Response={Response}", phoneNumber, response.StatusCode, responseContent);
        }
    }
}
