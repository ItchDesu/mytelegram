// ReSharper disable All

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Bots;

///<summary>
/// See <a href="https://corefork.telegram.org/method/bots.canSendMessage" />
///</summary>
internal sealed class CanSendMessageHandler : RpcResultObjectHandler<MyTelegram.Schema.Bots.RequestCanSendMessage, IBool>,
    Bots.ICanSendMessageHandler
{
    protected override Task<IBool> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Bots.RequestCanSendMessage obj)
    {
        return System.Threading.Tasks.Task.FromResult<IBool>(new TBoolTrue());
    }
}
