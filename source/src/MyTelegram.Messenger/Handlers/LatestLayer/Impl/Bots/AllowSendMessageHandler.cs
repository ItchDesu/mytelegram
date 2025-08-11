// ReSharper disable All

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Bots;

///<summary>
/// See <a href="https://corefork.telegram.org/method/bots.allowSendMessage" />
///</summary>
internal sealed class AllowSendMessageHandler : RpcResultObjectHandler<MyTelegram.Schema.Bots.RequestAllowSendMessage, MyTelegram.Schema.IUpdates>,
    Bots.IAllowSendMessageHandler
{
    protected override Task<MyTelegram.Schema.IUpdates> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Bots.RequestAllowSendMessage obj)
    {
        return Task.FromResult<MyTelegram.Schema.IUpdates>(new MyTelegram.Schema.TUpdates
        {
            Updates = new MyTelegram.Schema.TVector<MyTelegram.Schema.IUpdate>(),
            Users = new MyTelegram.Schema.TVector<MyTelegram.Schema.IUser>(),
            Chats = new MyTelegram.Schema.TVector<MyTelegram.Schema.IChat>(),
            Date = (int)System.DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
            Seq = 0
        });
    }
}
