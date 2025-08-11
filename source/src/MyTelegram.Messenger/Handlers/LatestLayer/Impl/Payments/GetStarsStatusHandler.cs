// ReSharper disable All

using MyTelegram.Converters.TLObjects.Payments;
using MyTelegram.Messenger.Services.Interfaces;
using MyTelegram.Schema;
using MyTelegram.Schema.Payments;

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Payments;

///<summary>
/// Get the current <a href="https://corefork.telegram.org/api/stars">Telegram Stars balance</a> of the current account (with peer=<a href="https://corefork.telegram.org/constructor/inputPeerSelf">inputPeerSelf</a>), or the stars balance of the bot specified in <code>peer</code>.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 PEER_ID_INVALID The provided peer id is invalid.
/// See <a href="https://corefork.telegram.org/method/payments.getStarsStatus" />
///</summary>
internal sealed class GetStarsStatusHandler(
    ILayeredService<IStarsStatusConverter> starsStatusLayeredService,
    IStarsService starsService) : RpcResultObjectHandler<MyTelegram.Schema.Payments.RequestGetStarsStatus, MyTelegram.Schema.Payments.IStarsStatus>,
    Payments.IGetStarsStatusHandler
{
    protected override async Task<MyTelegram.Schema.Payments.IStarsStatus> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Payments.RequestGetStarsStatus obj)
    {
        var result = starsStatusLayeredService.GetConverter(input.Layer).ToStarsStatus();
        var balance = await starsService.GetStarsAsync(input.UserId);
        result.Balance = new TStarsAmount { Amount = balance };
        return result;
    }
}