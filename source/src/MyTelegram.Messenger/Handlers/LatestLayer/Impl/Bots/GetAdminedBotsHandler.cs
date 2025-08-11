// ReSharper disable All

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Bots;

///<summary>
/// See <a href="https://corefork.telegram.org/method/bots.getAdminedBots" />
///</summary>
internal sealed class GetAdminedBotsHandler : RpcResultObjectHandler<MyTelegram.Schema.Bots.RequestGetAdminedBots, TVector<MyTelegram.Schema.IUser>>,
    Bots.IGetAdminedBotsHandler
{
    protected override Task<TVector<MyTelegram.Schema.IUser>> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Bots.RequestGetAdminedBots obj)
    {
        return Task.FromResult(new MyTelegram.Schema.TVector<MyTelegram.Schema.IUser>());
    }
}
