using MyTelegram.Schema;
using MyTelegram.Schema.Messages;

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Messages;

///<summary>
/// Search for <a href="https://corefork.telegram.org/api/custom-emoji">custom emoji stickersets </a>
/// See <a href="https://corefork.telegram.org/method/messages.searchEmojiStickerSets" />
///</summary>
internal sealed class SearchEmojiStickerSetsHandler : RpcResultObjectHandler<MyTelegram.Schema.Messages.RequestSearchEmojiStickerSets, MyTelegram.Schema.Messages.IFoundStickerSets>,
    Messages.ISearchEmojiStickerSetsHandler
{
    protected override Task<MyTelegram.Schema.Messages.IFoundStickerSets> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Messages.RequestSearchEmojiStickerSets obj)
    {
        return Task.FromResult<IFoundStickerSets>(new TFoundStickerSets
        {
            Hash = 0,
            Sets = new TVector<MyTelegram.Schema.IStickerSetCovered>()
        });
    }
}
