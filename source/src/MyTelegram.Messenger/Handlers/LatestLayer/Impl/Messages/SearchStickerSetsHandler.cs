using MyTelegram.Schema;
using MyTelegram.Schema.Messages;

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Messages;

///<summary>
/// Search for stickersets
/// See <a href="https://corefork.telegram.org/method/messages.searchStickerSets" />
///</summary>
internal sealed class SearchStickerSetsHandler : RpcResultObjectHandler<MyTelegram.Schema.Messages.RequestSearchStickerSets, MyTelegram.Schema.Messages.IFoundStickerSets>,
    Messages.ISearchStickerSetsHandler
{
    protected override Task<MyTelegram.Schema.Messages.IFoundStickerSets> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Messages.RequestSearchStickerSets obj)
    {
        return Task.FromResult<IFoundStickerSets>(new TFoundStickerSets
        {
            Hash = 0,
            Sets = new TVector<MyTelegram.Schema.IStickerSetCovered>()
        });
    }
}
