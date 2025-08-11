using MyTelegram.Schema;
using MyTelegram.Schema.Messages;

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Messages;

///<summary>
/// Method for fetching previously featured stickers
/// See <a href="https://corefork.telegram.org/method/messages.getOldFeaturedStickers" />
///</summary>
internal sealed class GetOldFeaturedStickersHandler : RpcResultObjectHandler<MyTelegram.Schema.Messages.RequestGetOldFeaturedStickers, MyTelegram.Schema.Messages.IFeaturedStickers>,
    Messages.IGetOldFeaturedStickersHandler
{
    protected override Task<MyTelegram.Schema.Messages.IFeaturedStickers> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Messages.RequestGetOldFeaturedStickers obj)
    {
        return Task.FromResult<IFeaturedStickers>(new TFeaturedStickers
        {
            Hash = 0,
            Count = 0,
            Sets = new TVector<MyTelegram.Schema.IStickerSetCovered>(),
            Unread = new TVector<long>()
        });
    }
}
