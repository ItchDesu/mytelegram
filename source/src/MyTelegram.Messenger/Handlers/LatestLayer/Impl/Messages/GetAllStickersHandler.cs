using MyTelegram.Schema;

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Messages;

/// <summary>
///     Get all installed stickers
///     See <a href="https://corefork.telegram.org/method/messages.getAllStickers" />
/// </summary>
internal sealed class GetAllStickersHandler :
    RpcResultObjectHandler<MyTelegram.Schema.Messages.RequestGetAllStickers, MyTelegram.Schema.Messages.IAllStickers>,
    Messages.IGetAllStickersHandler
{
    protected override Task<MyTelegram.Schema.Messages.IAllStickers> HandleCoreAsync(
        IRequestInput input,
        RequestGetAllStickers obj)
    {
        var set = new MyTelegram.Schema.TStickerSet
        {
            Id = StickerData.StickerSetId,
            AccessHash = StickerData.StickerSetAccessHash,
            Title = StickerData.StickerSetTitle,
            ShortName = StickerData.StickerSetShortName,
            Count = StickerData.DefaultStickerIds.Count,
            Hash = 0
        };
        var sets = new TVector<MyTelegram.Schema.IStickerSet>(set);

        var r = new MyTelegram.Schema.Messages.TAllStickers
        {
            Hash = 0,
            Sets = sets
        };

        return Task.FromResult<IAllStickers>(r);
    }
}