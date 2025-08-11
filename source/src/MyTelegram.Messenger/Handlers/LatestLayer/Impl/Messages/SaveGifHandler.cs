namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Messages;

///<summary>
/// Add GIF to saved gifs list
/// <para>Possible errors</para>
/// Code Type Description
/// 400 GIF_ID_INVALID The provided GIF ID is invalid.
/// See <a href="https://corefork.telegram.org/method/messages.saveGif" />
///</summary>
internal sealed class SaveGifHandler : RpcResultObjectHandler<MyTelegram.Schema.Messages.RequestSaveGif, IBool>,
    Messages.ISaveGifHandler
{
    protected override Task<IBool> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Messages.RequestSaveGif obj)
    {
        return Task.FromResult<IBool>(new TBoolTrue());
    }
}
