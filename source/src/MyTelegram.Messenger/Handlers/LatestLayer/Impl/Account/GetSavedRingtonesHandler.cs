namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Account;

///<summary>
/// Fetch saved notification sounds
/// See <a href="https://corefork.telegram.org/method/account.getSavedRingtones" />
///</summary>
internal sealed class GetSavedRingtonesHandler : RpcResultObjectHandler<MyTelegram.Schema.Account.RequestGetSavedRingtones, MyTelegram.Schema.Account.ISavedRingtones>,
    Account.IGetSavedRingtonesHandler
{
    protected override Task<MyTelegram.Schema.Account.ISavedRingtones> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Account.RequestGetSavedRingtones obj)
    {
        return Task.FromResult<Schema.Account.ISavedRingtones>(new TSavedRingtones
        {
            Ringtones = []
        });
    }
}
