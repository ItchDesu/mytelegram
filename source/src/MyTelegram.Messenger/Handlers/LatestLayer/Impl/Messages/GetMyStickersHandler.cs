using MyTelegram.Messenger.Handlers.LatestLayer.Impl;
using MyTelegram.Schema;
using MyTelegram.Schema.Messages;

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Messages;

///<summary>
/// Fetch all <a href="https://corefork.telegram.org/api/stickers">stickersets </a> owned by the current user.
/// See <a href="https://corefork.telegram.org/method/messages.getMyStickers" />
///</summary>
internal sealed class GetMyStickersHandler : RpcResultObjectHandler<MyTelegram.Schema.Messages.RequestGetMyStickers, MyTelegram.Schema.Messages.IMyStickers>,
    Messages.IGetMyStickersHandler
{
    protected override Task<MyTelegram.Schema.Messages.IMyStickers> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Messages.RequestGetMyStickers obj)
    {
        var hasStickers = StickerData.StickerInfos.Count > 0;
        var sets = new TVector<MyTelegram.Schema.IStickerSetCovered>();
        if (hasStickers)
        {
            sets.Add(StickerSample.CreateStickerSetCovered());
        }

        return Task.FromResult<IMyStickers>(new TMyStickers
        {
            Count = hasStickers ? 1 : 0,
            Sets = sets
        });
    }
}
