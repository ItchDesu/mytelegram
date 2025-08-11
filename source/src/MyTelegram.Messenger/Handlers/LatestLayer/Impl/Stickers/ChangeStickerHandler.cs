using MyTelegram.Messenger.Handlers.LatestLayer.Impl;

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Stickers;

///<summary>
/// Update the keywords, emojis or <a href="https://corefork.telegram.org/api/stickers#mask-stickers">mask coordinates</a> of a sticker.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 STICKER_INVALID The provided sticker is invalid.
/// See <a href="https://corefork.telegram.org/method/stickers.changeSticker" />
///</summary>
internal sealed class ChangeStickerHandler : RpcResultObjectHandler<MyTelegram.Schema.Stickers.RequestChangeSticker, MyTelegram.Schema.Messages.IStickerSet>,
    Stickers.IChangeStickerHandler
{
    protected override Task<MyTelegram.Schema.Messages.IStickerSet> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Stickers.RequestChangeSticker obj)
    {
        return Task.FromResult<MyTelegram.Schema.Messages.IStickerSet>(StickerSample.CreateMessagesStickerSet());
    }
}
