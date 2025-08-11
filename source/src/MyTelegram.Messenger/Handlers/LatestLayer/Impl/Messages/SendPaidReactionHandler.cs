// ReSharper disable All

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Messages;

///<summary>
/// See <a href="https://corefork.telegram.org/method/messages.sendPaidReaction" />
///</summary>
internal sealed class SendPaidReactionHandler : RpcResultObjectHandler<MyTelegram.Schema.Messages.RequestSendPaidReaction, MyTelegram.Schema.IUpdates>,
    Messages.ISendPaidReactionHandler
{
    protected override Task<MyTelegram.Schema.IUpdates> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Messages.RequestSendPaidReaction obj)
    {
        var updates = new TUpdates
        {
            Updates = [],
            Users = [],
            Chats = [],
            Date = CurrentDate,
            Seq = 0
        };

        return Task.FromResult<IUpdates>(updates);
    }
}