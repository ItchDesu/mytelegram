using MyTelegram.Messenger.Handlers.LatestLayer.Impl;

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Stickers;

///<summary>
/// Set stickerset thumbnail
/// <para>Possible errors</para>
/// Code Type Description
/// 400 STICKERSET_INVALID The provided sticker set is invalid.
/// 400 STICKER_THUMB_PNG_NOPNG Incorrect stickerset thumb file provided, PNG / WEBP expected.
/// 400 STICKER_THUMB_TGS_NOTGS Incorrect stickerset TGS thumb file provided.
/// See <a href="https://corefork.telegram.org/method/stickers.setStickerSetThumb" />
///</summary>
internal sealed class SetStickerSetThumbHandler : RpcResultObjectHandler<MyTelegram.Schema.Stickers.RequestSetStickerSetThumb, MyTelegram.Schema.Messages.IStickerSet>,
    Stickers.ISetStickerSetThumbHandler
{
    protected override Task<MyTelegram.Schema.Messages.IStickerSet> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Stickers.RequestSetStickerSetThumb obj)
    {
        return Task.FromResult<MyTelegram.Schema.Messages.IStickerSet>(StickerSample.CreateMessagesStickerSet());
    }
}
