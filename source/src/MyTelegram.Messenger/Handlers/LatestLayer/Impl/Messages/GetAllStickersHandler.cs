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
        var sets = StickerData.DefaultStickerIds.Count > 0
            ? new TVector<MyTelegram.Schema.IStickerSet>(new MyTelegram.Schema.TStickerSet
            {
                Id = 1,
                AccessHash = 0,
                Title = "Bin",
                ShortName = "bin_vk",
                Count = StickerData.DefaultStickerIds.Count,
                Hash = 0
            })
            : new TVector<MyTelegram.Schema.IStickerSet>();

        var r = new MyTelegram.Schema.Messages.TAllStickers
        {
            Hash = 0,
            Sets = sets
        };

        return Task.FromResult<IAllStickers>(r);
    }
}