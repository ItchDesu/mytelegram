namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Messages;

///<summary>
/// See <a href="https://corefork.telegram.org/method/messages.reportMessagesDelivery" />
///</summary>
internal sealed class ReportMessagesDeliveryHandler : RpcResultObjectHandler<MyTelegram.Schema.Messages.RequestReportMessagesDelivery, IBool>,
    Messages.IReportMessagesDeliveryHandler
{
    protected override Task<IBool> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Messages.RequestReportMessagesDelivery obj)
    {
        return Task.FromResult<IBool>(new TBoolTrue());
    }
}
