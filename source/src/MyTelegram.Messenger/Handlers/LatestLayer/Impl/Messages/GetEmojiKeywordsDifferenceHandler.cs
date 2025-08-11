namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Messages;

///<summary>
/// Get changed <a href="https://corefork.telegram.org/api/custom-emoji#emoji-keywords">emoji keywords </a>.
/// See <a href="https://corefork.telegram.org/method/messages.getEmojiKeywordsDifference" />
///</summary>
internal sealed class GetEmojiKeywordsDifferenceHandler : RpcResultObjectHandler<MyTelegram.Schema.Messages.RequestGetEmojiKeywordsDifference, MyTelegram.Schema.IEmojiKeywordsDifference>,
    Messages.IGetEmojiKeywordsDifferenceHandler
{
    protected override Task<MyTelegram.Schema.IEmojiKeywordsDifference> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Messages.RequestGetEmojiKeywordsDifference obj)
    {
        var r = new TEmojiKeywordsDifference
        {
            LangCode = "es",
            FromVersion = 0,
            Version = 0,
            Keywords = []
        };

        return Task.FromResult<IEmojiKeywordsDifference>(r);
    }
}
