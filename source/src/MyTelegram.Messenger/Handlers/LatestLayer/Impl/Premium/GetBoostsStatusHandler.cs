// ReSharper disable All

using MyTelegram.Schema.Premium;

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Premium;

///<summary>
/// Gets the current <a href="https://corefork.telegram.org/api/boost">number of boosts</a> of a channel/supergroup.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 PEER_ID_INVALID The provided peer id is invalid.
/// See <a href="https://corefork.telegram.org/method/premium.getBoostsStatus" />
///</summary>
internal sealed class GetBoostsStatusHandler : RpcResultObjectHandler<MyTelegram.Schema.Premium.RequestGetBoostsStatus, MyTelegram.Schema.Premium.IBoostsStatus>,
    Premium.IGetBoostsStatusHandler
{
    protected override Task<MyTelegram.Schema.Premium.IBoostsStatus> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Premium.RequestGetBoostsStatus obj)
    {
        var boostsStatus = new TBoostsStatus
        {
            MyBoost = false,
            Level = 50,
            Boosts = 1000,
            CurrentLevelBoosts = 100,
            NextLevelBoosts = 100,
            BoostUrl = "https://buzzster.io/"
        };

        return Task.FromResult<IBoostsStatus>(boostsStatus);
    }
}
