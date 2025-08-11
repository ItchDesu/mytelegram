namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Messages;

///<summary>
/// Get dialogs manually marked as unread
/// See <a href="https://corefork.telegram.org/method/messages.getDialogUnreadMarks" />
///</summary>
internal sealed class GetDialogUnreadMarksHandler : RpcResultObjectHandler<MyTelegram.Schema.Messages.RequestGetDialogUnreadMarks, TVector<MyTelegram.Schema.IDialogPeer>>,
    Messages.IGetDialogUnreadMarksHandler
{
    protected override Task<TVector<MyTelegram.Schema.IDialogPeer>> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Messages.RequestGetDialogUnreadMarks obj)
    {
        return Task.FromResult<TVector<IDialogPeer>>([]);
    }
}
