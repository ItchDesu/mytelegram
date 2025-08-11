namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Payments;

using MyTelegram.Schema.Payments;

///<summary>
/// Apply a <a href="https://corefork.telegram.org/api/giveaways">Telegram Premium giftcode </a>
/// <para>Possible errors</para>
/// Code Type Description
/// 400 GIFT_SLUG_EXPIRED The specified gift slug has expired.
/// 400 GIFT_SLUG_INVALID The specified slug is invalid.
/// 420 PREMIUM_SUB_ACTIVE_UNTIL_%d You already have a premium subscription active until unixtime %d .
/// See <a href="https://corefork.telegram.org/method/payments.applyGiftCode" />
///</summary>
internal sealed class ApplyGiftCodeHandler : RpcResultObjectHandler<MyTelegram.Schema.Payments.RequestApplyGiftCode, MyTelegram.Schema.IUpdates>,
    Payments.IApplyGiftCodeHandler
{
    protected override Task<MyTelegram.Schema.IUpdates> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Payments.RequestApplyGiftCode obj)
    {
        var updates = new TUpdates
        {
            Updates = [],
            Users = [],
            Chats = [],
            Date = CurrentDate,
            Seq = 0
        };

        return Task.FromResult<IUpdates>(updates);
    }
}