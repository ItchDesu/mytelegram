namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Messages;

///<summary>
/// Gets the list of currently installed <a href="https://corefork.telegram.org/api/custom-emoji">custom emoji stickersets</a>.
/// See <a href="https://corefork.telegram.org/method/messages.getEmojiStickers" />
///</summary>
internal sealed class GetEmojiStickersHandler : RpcResultObjectHandler<MyTelegram.Schema.Messages.RequestGetEmojiStickers, MyTelegram.Schema.Messages.IAllStickers>,
    Messages.IGetEmojiStickersHandler
{
    protected override Task<MyTelegram.Schema.Messages.IAllStickers> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Messages.RequestGetEmojiStickers obj)
    {
        return Task.FromResult<MyTelegram.Schema.Messages.IAllStickers>(new TAllStickers
        {
            Sets = [],
        });
    }
}
