// ReSharper disable All

namespace MyTelegram.Messenger.Handlers.Phone;

///<summary>
/// See <a href="https://corefork.telegram.org/method/phone.getGroupCallChainBlocks" />
///</summary>
internal sealed class GetGroupCallChainBlocksHandler : RpcResultObjectHandler<MyTelegram.Schema.Phone.RequestGetGroupCallChainBlocks, MyTelegram.Schema.IUpdates>,
    Phone.IGetGroupCallChainBlocksHandler
{
    protected override Task<MyTelegram.Schema.IUpdates> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Phone.RequestGetGroupCallChainBlocks obj)
    {
        throw new NotImplementedException();
    }
}
