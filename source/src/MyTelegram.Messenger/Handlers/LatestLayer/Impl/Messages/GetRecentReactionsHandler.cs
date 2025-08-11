// ReSharper disable All

using MyTelegram.Schema.Messages;

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Messages;

///<summary>
/// Get recently used <a href="https://corefork.telegram.org/api/reactions">message reactions</a>
/// See <a href="https://corefork.telegram.org/method/messages.getRecentReactions" />
///</summary>
internal sealed class GetRecentReactionsHandler : RpcResultObjectHandler<MyTelegram.Schema.Messages.RequestGetRecentReactions, MyTelegram.Schema.Messages.IReactions>,
    Messages.IGetRecentReactionsHandler
{
    protected override Task<MyTelegram.Schema.Messages.IReactions> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Messages.RequestGetRecentReactions obj)
    {
        return Task.FromResult<IReactions>(new TReactions
        {
            Reactions = []
        });
    }
}
