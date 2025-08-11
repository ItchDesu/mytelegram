using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using MyTelegram.Schema.Extensions;
using MyTelegram;
using MyTelegram.Messenger.Services.Interfaces;

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Messages
{
    public sealed class TranslateTextHandler : RpcResultObjectHandler<RequestTranslateText, ITranslatedText>,
        ITranslateTextHandler
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<TranslateTextHandler> _logger;
        private readonly IMessageAppService _messageAppService;

        public TranslateTextHandler(
            IHttpClientFactory httpClientFactory,
            ILogger<TranslateTextHandler> logger,
            IMessageAppService messageAppService)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _messageAppService = messageAppService;
        }

        public Task<ITranslatedText> HandleAsync(RequestTranslateText input)
        {
            return HandleCoreAsync(null!, input);
        }

        protected override async Task<ITranslatedText> HandleCoreAsync(IRequestInput input, RequestTranslateText obj)
        {
            if (string.IsNullOrWhiteSpace(obj.ToLang))
                throw new RpcException(new RpcError(400, "TO_LANG_INVALID"));

            if ((obj.Text?.Count ?? 0) == 0 && (obj.Id?.Count ?? 0) == 0)
                throw new RpcException(new RpcError(400, "INPUT_TEXT_EMPTY"));

            var result = new TVector<ITextWithEntities>();

            if (obj.Text != null)
            {
                foreach (var textEntity in obj.Text)
                {
                    _logger.LogInformation("Translating text: {Text}", textEntity.Text);
                    var translated = await TranslateTextAsync(textEntity.Text, obj.ToLang);
                    _logger.LogInformation("Translation result: {Translated}", translated);

                    result.Add(new TTextWithEntities
                    {
                        Text = translated ?? textEntity.Text,
                        Entities = new TVector<IMessageEntity>()
                    });
                }
            }
            else if (obj.Id != null)
            {
                // Aqu est el cambio importante - ya no usamos .Id ya que son directamente int
                var idList = obj.Id.ToList();
                var messages = await _messageAppService.GetMessagesAsync(
                    new GetMessagesInput(input.UserId, input.UserId, idList, null) { Limit = 50 });

                foreach (var message in messages.MessageList)
                {
                    if (string.IsNullOrEmpty(message.Message))
                        continue;

                    _logger.LogInformation("Translating message ID {Id}: {Text}", message.Id, message.Message);
                    var translated = await TranslateTextAsync(message.Message, obj.ToLang);

                    result.Add(new TTextWithEntities
                    {
                        Text = translated ?? message.Message,
                        Entities = new TVector<IMessageEntity>()
                    });
                }
            }

            return new TTranslateResult
            {
                Result = result
            };
        }

        private async Task<string?> TranslateTextAsync(string text, string toLang)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            try
            {
                var client = _httpClientFactory.CreateClient();
                var payload = new
                {
                    q = text,
                    source = "auto",
                    target = toLang
                };

                var response = await client.PostAsJsonAsync("http://libretranslate:5000/translate", payload);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                _logger.LogDebug("LibreTranslate raw response: {Content}", content);

                var data = System.Text.Json.JsonSerializer.Deserialize<LibreTranslateResponse>(content);
                return data?.TranslatedText;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Translation failed for text: '{Text}' to language: '{Lang}'", text, toLang);
                return null;
            }
        }

        private class LibreTranslateResponse
        {
            [JsonPropertyName("detectedLanguage")]
            public DetectedLanguage DetectedLanguage { get; set; } = null!;

            [JsonPropertyName("translatedText")]
            public string TranslatedText { get; set; } = null!;
        }

        private class DetectedLanguage
        {
            [JsonPropertyName("confidence")]
            public double Confidence { get; set; }

            [JsonPropertyName("language")]
            public string Language { get; set; } = null!;
        }
    }
}