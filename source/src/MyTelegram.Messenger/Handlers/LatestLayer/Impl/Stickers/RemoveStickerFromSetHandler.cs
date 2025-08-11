using MyTelegram.Messenger.Handlers.LatestLayer.Impl;

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Stickers;

///<summary>
/// Remove a sticker from the set where it belongs. The sticker set must have been created by the current user/bot.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 STICKER_INVALID The provided sticker is invalid.
/// See <a href="https://corefork.telegram.org/method/stickers.removeStickerFromSet" />
///</summary>
internal sealed class RemoveStickerFromSetHandler : RpcResultObjectHandler<MyTelegram.Schema.Stickers.RequestRemoveStickerFromSet, MyTelegram.Schema.Messages.IStickerSet>,
    Stickers.IRemoveStickerFromSetHandler
{
    protected override Task<MyTelegram.Schema.Messages.IStickerSet> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Stickers.RequestRemoveStickerFromSet obj)
    {
        return Task.FromResult<MyTelegram.Schema.Messages.IStickerSet>(StickerSample.CreateMessagesStickerSet());
    }
}
