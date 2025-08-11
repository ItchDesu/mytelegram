using MyTelegram.Messenger.Handlers.LatestLayer.Impl;

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Stickers;

///<summary>
/// Changes the absolute position of a sticker in the set to which it belongs. The sticker set must have been created by the current user/bot.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 STICKER_INVALID The provided sticker is invalid.
/// See <a href="https://corefork.telegram.org/method/stickers.changeStickerPosition" />
///</summary>
internal sealed class ChangeStickerPositionHandler : RpcResultObjectHandler<MyTelegram.Schema.Stickers.RequestChangeStickerPosition, MyTelegram.Schema.Messages.IStickerSet>,
    Stickers.IChangeStickerPositionHandler
{
    protected override Task<MyTelegram.Schema.Messages.IStickerSet> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Stickers.RequestChangeStickerPosition obj)
    {
        return Task.FromResult<MyTelegram.Schema.Messages.IStickerSet>(StickerSample.CreateMessagesStickerSet());
    }
}
