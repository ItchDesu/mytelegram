namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Messages;

///<summary>
/// Clear recently used <a href="https://corefork.telegram.org/api/reactions">message reactions</a>
/// See <a href="https://corefork.telegram.org/method/messages.clearRecentReactions" />
///</summary>
internal sealed class ClearRecentReactionsHandler : RpcResultObjectHandler<MyTelegram.Schema.Messages.RequestClearRecentReactions, IBool>,
    Messages.IClearRecentReactionsHandler
{
    protected override Task<IBool> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Messages.RequestClearRecentReactions obj)
    {
        return Task.FromResult<IBool>(new TBoolTrue());
    }
}
