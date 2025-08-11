// ReSharper disable All

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Account;

///<summary>
/// Save a theme
/// See <a href="https://corefork.telegram.org/method/account.saveTheme" />
///</summary>
internal sealed class SaveThemeHandler : RpcResultObjectHandler<MyTelegram.Schema.Account.RequestSaveTheme, IBool>,
    Account.ISaveThemeHandler
{
    protected override Task<IBool> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Account.RequestSaveTheme obj)
    {
        return Task.FromResult<IBool>(new TBoolTrue());
    }
}
