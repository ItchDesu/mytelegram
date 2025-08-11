using MyTelegram.Messenger.Handlers.LatestLayer.Impl;

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Stickers;

///<summary>
/// Renames a stickerset.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 STICKERSET_INVALID The provided sticker set is invalid.
/// See <a href="https://corefork.telegram.org/method/stickers.renameStickerSet" />
///</summary>
internal sealed class RenameStickerSetHandler : RpcResultObjectHandler<MyTelegram.Schema.Stickers.RequestRenameStickerSet, MyTelegram.Schema.Messages.IStickerSet>,
    Stickers.IRenameStickerSetHandler
{
    protected override Task<MyTelegram.Schema.Messages.IStickerSet> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Stickers.RequestRenameStickerSet obj)
    {
        return Task.FromResult<MyTelegram.Schema.Messages.IStickerSet>(StickerSample.CreateMessagesStickerSet());
    }
}
