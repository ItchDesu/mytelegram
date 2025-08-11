// ReSharper disable All

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Account;

///<summary>
/// Set an <a href="https://corefork.telegram.org/api/emoji-status">emoji status</a>
/// See <a href="https://corefork.telegram.org/method/account.updateEmojiStatus" />
///</summary>
internal sealed class UpdateEmojiStatusHandler : RpcResultObjectHandler<MyTelegram.Schema.Account.RequestUpdateEmojiStatus, IBool>,
    Account.IUpdateEmojiStatusHandler
{
    protected override Task<IBool> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Account.RequestUpdateEmojiStatus obj)
    {
        return Task.FromResult<IBool>(new TBoolTrue());
    }
}
