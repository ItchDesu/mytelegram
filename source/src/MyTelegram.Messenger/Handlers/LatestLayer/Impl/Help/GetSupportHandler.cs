namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Help;

///<summary>
/// Returns the support user for the "ask a question" feature.
/// See <a href="https://corefork.telegram.org/method/help.getSupport" />
///</summary>
internal sealed class GetSupportHandler(
    IUserAppService userAppService,
    IUserConverterService userConverterService,
    IOptionsMonitor<MyTelegramMessengerServerOptions> options) : RpcResultObjectHandler<MyTelegram.Schema.Help.RequestGetSupport, MyTelegram.Schema.Help.ISupport>,
    Help.IGetSupportHandler
{
    protected override async Task<MyTelegram.Schema.Help.ISupport> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Help.RequestGetSupport obj)
    {
        var supportUserId = MyTelegramConsts.DefaultSupportUserId;
        if (!string.IsNullOrEmpty(options.CurrentValue.SupportUserId))
        {
            if (!long.TryParse(options.CurrentValue.SupportUserId, out supportUserId))
            {
                supportUserId = MyTelegramConsts.DefaultSupportUserId;
            }
        }
        var userReadModel = await userAppService.GetAsync(supportUserId);

        if (userReadModel == null)
        {
            supportUserId = MyTelegramConsts.DefaultSupportUserId;
            userReadModel = await userAppService.GetAsync(supportUserId);
        }

        var user = await userConverterService.GetUserAsync(input, supportUserId, layer: input.Layer);

        return new TSupport
        {
            PhoneNumber = user.Phone,
            User = user
        };
    }
}
