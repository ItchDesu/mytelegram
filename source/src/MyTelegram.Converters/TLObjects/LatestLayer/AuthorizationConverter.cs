using System.Net.Http;
using System.Text.Json;
using MyTelegram.Schema.Auth;
using MyTelegram.Schema.Help;
using IAuthorization = MyTelegram.Schema.Auth.IAuthorization;
using TAuthorization = MyTelegram.Schema.Auth.TAuthorization;

namespace MyTelegram.Converters.TLObjects.LatestLayer;

internal sealed class AuthorizationConverter(IObjectMapper objectMapper) : IAuthorizationConverter, ITransientDependency
{
    private static readonly HttpClient _httpClient = new HttpClient();

    public int Layer => Layers.LayerLatest;

    private async Task<string> GetCountryFromIpAsync()
    {
        try
        {
            // Puedes usar ipapi.co, ipinfo.io o cualquier otro
            var response = await _httpClient.GetStringAsync("https://ipapi.co/country_name/");
            return string.IsNullOrWhiteSpace(response) ? "Unknown" : response.Trim();
        }
        catch
        {
            return "Unknown";
        }
    }

    public IAuthorization CreateAuthorization(IUser? user, bool setupPasswordRequired = false)
    {
        if (user == null)
        {
            return new TAuthorizationSignUpRequired
            {
                TermsOfService = new TTermsOfService
                {
                    Entities = new TVector<IMessageEntity>(),
                    Id = new TDataJSON
                    {
                        Data =
                            "{\"country\":\"US\",\"min_age\":false,\"terms_key\":\"TERMS_OF_SERVICE\",\"terms_lang\":\"en\",\"terms_version\":1,\"terms_hash\":\"7dca806cb8d387c07c778ce9ef6aac04\"}"
                    },
                    Text =
                        "Al registrarte en Buzzster, aceptas no:\n\n- Usar nuestro servicio para enviar spam o estafar a otros usuarios.\n- Promover la violencia en bots, grupos o canales pblicos de Buzzster.\n- Publicar contenido pornogrfico en bots, grupos o canales pblicos de Buzzster.\n\nNos reservamos el derecho de actualizar estos Trminos de Servicio en el futuro."
                }
            };
        }

        return new TAuthorization
        {
            User = user,
            SetupPasswordRequired = setupPasswordRequired,
            OtherwiseReloginDays = setupPasswordRequired ? 1 : null
        };
    }

    public IAuthorization CreateSignUpAuthorization()
    {
        return new TAuthorizationSignUpRequired
        {
            TermsOfService = new TTermsOfService
            {
                Entities = new TVector<IMessageEntity>(),
                Id = new TDataJSON
                {
                    Data =
                        "{\"country\":\"US\",\"min_age\":false,\"terms_key\":\"TERMS_OF_SERVICE\",\"terms_lang\":\"en\",\"terms_version\":1,\"terms_hash\":\"7dca806cb8d387c07c778ce9ef6aac04\"}"
                },
                Text =
                    "Al registrarte en Buzzster, aceptas no:\n\n- Usar nuestro servicio para enviar spam o estafar a otros usuarios.\n- Promover la violencia en bots, grupos o canales pblicos de Buzzster.\n- Publicar contenido pornogrfico en bots, grupos o canales pblicos de Buzzster.\n\nNos reservamos el derecho de actualizar estos Trminos de Servicio en el futuro."
            }
        };
    }

    public Schema.IAuthorization ToAuthorization(IDeviceReadModel deviceReadModel, long selfPermAuthKeyId = -1)
    {
        var authorization = objectMapper.Map<IDeviceReadModel, Schema.TAuthorization>(deviceReadModel);
        authorization.AppName = deviceReadModel.LangPack;

        // Obtener pas real por IP (sin bloquear)
        authorization.Country = GetCountryFromIpAsync().GetAwaiter().GetResult();

        authorization.Region = string.Empty;
        authorization.Current = selfPermAuthKeyId == deviceReadModel.PermAuthKeyId;

        return authorization;
    }

    public IWebAuthorization ToWebAuthorization(IDeviceReadModel deviceReadModel, long selfPermAuthKeyId = -1)
    {
        var authorization = objectMapper.Map<IDeviceReadModel, TWebAuthorization>(deviceReadModel);
        authorization.Region = "Test region";
        authorization.Domain = "Test domain";

        return authorization;
    }

    public IReadOnlyList<Schema.IAuthorization> ToAuthorizations(IReadOnlyCollection<IDeviceReadModel> deviceReadModels,
        long selfPermAuthKeyId = -1)
    {
        return deviceReadModels.Select(p => ToAuthorization(p, selfPermAuthKeyId)).ToList();
    }

    public IReadOnlyList<IWebAuthorization> ToWebAuthorizations(IReadOnlyCollection<IDeviceReadModel> deviceReadModels,
        long selfPermAuthKeyId = -1)
    {
        return deviceReadModels.Select(p => ToWebAuthorization(p, selfPermAuthKeyId)).ToList();
    }
}