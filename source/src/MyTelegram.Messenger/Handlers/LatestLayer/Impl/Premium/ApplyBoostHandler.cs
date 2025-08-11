using MyTelegram.Schema.Premium;

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Premium;

///<summary>
/// Apply one or more <a href="https://corefork.telegram.org/api/boost">boosts </a> to a peer.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 BOOSTS_EMPTY No boost slots were specified.
/// 400 PEER_ID_INVALID The provided peer id is invalid.
/// 400 SLOTS_EMPTY The specified slot list is empty.
/// See <a href="https://corefork.telegram.org/method/premium.applyBoost" />
///</summary>
internal sealed class ApplyBoostHandler : RpcResultObjectHandler<MyTelegram.Schema.Premium.RequestApplyBoost, MyTelegram.Schema.Premium.IMyBoosts>,
    Premium.IApplyBoostHandler
{
    protected override Task<MyTelegram.Schema.Premium.IMyBoosts> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Premium.RequestApplyBoost obj)
    {
        return Task.FromResult<MyTelegram.Schema.Premium.IMyBoosts>(new TMyBoosts
        {
            Chats = [],
            MyBoosts = [],
            Users = []
        });
    }
}