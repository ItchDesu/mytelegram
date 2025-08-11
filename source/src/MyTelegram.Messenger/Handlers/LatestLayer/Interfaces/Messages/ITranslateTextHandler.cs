namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Messages;

public interface ITranslateTextHandler : IObjectHandler
{
    Task<ITranslatedText> HandleAsync(RequestTranslateText input);
}