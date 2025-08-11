namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Help;

///<summary>
/// Look for updates of telegram's terms of service
/// See <a href="https://corefork.telegram.org/method/help.getTermsOfServiceUpdate" />
///</summary>
internal sealed class GetTermsOfServiceUpdateHandler : RpcResultObjectHandler<MyTelegram.Schema.Help.RequestGetTermsOfServiceUpdate, MyTelegram.Schema.Help.ITermsOfServiceUpdate>,
    Help.IGetTermsOfServiceUpdateHandler
{
    protected override Task<ITermsOfServiceUpdate> HandleCoreAsync(IRequestInput input,
        RequestGetTermsOfServiceUpdate obj)
    {
        var userId = input.UserId;
        if (userId > 0)
        {
            var alreadyRegisteredTermsOfService = new TTermsOfServiceUpdateEmpty
            {
                Expires = (int)DateTimeOffset.UtcNow.AddDays(10).ToUnixTimeSeconds()
            };

            return Task.FromResult<ITermsOfServiceUpdate>(alreadyRegisteredTermsOfService);
        }

        var r = new TTermsOfServiceUpdate
        {
            Expires = (int)((DateTimeOffset)DateTime.UtcNow.AddDays(10)).ToUnixTimeSeconds(),
            //TermsOfService=new TTermsOfService()
            TermsOfService = new TTermsOfService
            {
                Entities = [],
                //Popup = false,
                Id = new TDataJSON
                {
                    Data =
                        "{\"country\":\"US\",\"min_age\":false,\"terms_key\":\"TERMS_OF_SERVICE\",\"terms_lang\":\"en\",\"terms_version\":1,\"terms_hash\":\"7dca806cb8d387c07c778ce9ef6aac04\"}"
                },
                Text =
                    "Al registrarte en Buzzster, aceptas no:\n\n- Usar nuestro servicio para enviar spam o estafar a otros usuarios.\n- Promover la violencia en bots, grupos o canales pblicos de Buzzster.\n- Publicar contenido pornogrfico en bots, grupos o canales pblicos de Buzzster.\n\nNos reservamos el derecho de actualizar estos Trminos de Servicio en el futuro."
                //MinAgeConfirm = 0
            }
        };

        return Task.FromResult<ITermsOfServiceUpdate>(r);
    }
}