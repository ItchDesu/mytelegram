namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Account;

///<summary>
/// Activate or deactivate a purchased <a href="https://fragment.com/">fragment.com</a> username associated to the currently logged-in user.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 USERNAMES_ACTIVE_TOO_MUCH The maximum number of active usernames was reached.
/// 400 USERNAME_INVALID The provided username is not valid.
/// 400 USERNAME_NOT_MODIFIED The username was not modified.
/// See <a href="https://corefork.telegram.org/method/account.toggleUsername" />
///</summary>
internal sealed class ToggleUsernameHandler : RpcResultObjectHandler<MyTelegram.Schema.Account.RequestToggleUsername, IBool>,
    Account.IToggleUsernameHandler
{
    protected override Task<IBool> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Account.RequestToggleUsername obj)
    {
        return Task.FromResult<IBool>(new TBoolTrue());
    }
}
