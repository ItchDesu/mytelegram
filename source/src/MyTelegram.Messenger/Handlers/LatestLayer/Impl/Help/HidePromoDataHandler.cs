namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Help;

///<summary>
/// Hide MTProxy/Public Service Announcement information
/// See <a href="https://corefork.telegram.org/method/help.hidePromoData" />
///</summary>
internal sealed class HidePromoDataHandler : RpcResultObjectHandler<MyTelegram.Schema.Help.RequestHidePromoData, IBool>,
    Help.IHidePromoDataHandler
{
    protected override Task<IBool> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Help.RequestHidePromoData obj)
    {
        return Task.FromResult<IBool>(new TBoolTrue());
    }
}
