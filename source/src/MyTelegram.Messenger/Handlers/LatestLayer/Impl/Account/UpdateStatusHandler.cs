namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Account;

///<summary>
/// Updates online user status.
/// See <a href="https://corefork.telegram.org/method/account.updateStatus" />
///</summary>
internal sealed class UpdateStatusHandler(IUserStatusCacheAppService userStatusAppService)
    : RpcResultObjectHandler<MyTelegram.Schema.Account.RequestUpdateStatus, IBool>,
        Account.IUpdateStatusHandler
{
    protected override Task<IBool> HandleCoreAsync(IRequestInput input,
        RequestUpdateStatus obj)
    {
        userStatusAppService.UpdateStatus(input.UserId, !obj.Offline);

        return Task.FromResult<IBool>(new TBoolTrue());
    }
}
