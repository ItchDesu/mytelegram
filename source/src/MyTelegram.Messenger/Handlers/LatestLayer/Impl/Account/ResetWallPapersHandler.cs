// ReSharper disable All

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Account;

///<summary>
/// Delete all installed <a href="https://corefork.telegram.org/api/wallpapers">wallpapers</a>, reverting to the default wallpaper set.
/// See <a href="https://corefork.telegram.org/method/account.resetWallPapers" />
///</summary>
internal sealed class ResetWallPapersHandler : RpcResultObjectHandler<MyTelegram.Schema.Account.RequestResetWallPapers, IBool>,
    Account.IResetWallPapersHandler
{
    protected override Task<IBool> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Account.RequestResetWallPapers obj)
    {
        return Task.FromResult<IBool>(new TBoolTrue());
    }
}
