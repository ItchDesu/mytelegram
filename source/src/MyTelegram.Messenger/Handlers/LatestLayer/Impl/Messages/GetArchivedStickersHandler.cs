namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Messages;

///<summary>
/// Get all archived stickers
/// See <a href="https://corefork.telegram.org/method/messages.getArchivedStickers" />
///</summary>
internal sealed class GetArchivedStickersHandler : RpcResultObjectHandler<MyTelegram.Schema.Messages.RequestGetArchivedStickers, MyTelegram.Schema.Messages.IArchivedStickers>,
    Messages.IGetArchivedStickersHandler
{
    protected override Task<IArchivedStickers> HandleCoreAsync(IRequestInput input,
        RequestGetArchivedStickers obj)
    {
        var r = new TArchivedStickers { Sets = [] };

        return Task.FromResult<IArchivedStickers>(r);
    }
}
