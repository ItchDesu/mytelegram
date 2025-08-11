namespace MyTelegram.Messenger.QueryServer.EventHandlers;

public class MessengerEventHandler(
    IMessageQueueProcessor<MessengerQueryDataReceivedEvent> processor)
    :
        IEventHandler<MessengerQueryDataReceivedEvent>,
        IEventHandler<StickerDataReceivedEvent>,
        ITransientDependency
{
    public Task HandleEventAsync(MessengerQueryDataReceivedEvent eventData)
    {
        processor.Enqueue(eventData, eventData.PermAuthKeyId);
        return Task.CompletedTask;
    }

    public Task HandleEventAsync(StickerDataReceivedEvent eventData)
    {
        processor.Enqueue(
            new MessengerQueryDataReceivedEvent(eventData.ConnectionId, eventData.RequestId, eventData.ObjectId,
                eventData.UserId, eventData.ReqMsgId, eventData.SeqNumber, eventData.AuthKeyId, eventData.PermAuthKeyId,
                eventData.Data, eventData.Layer, eventData.Date, eventData.DeviceType, eventData.ClientIp, eventData.SessionId, eventData.AccessHashKeyId),
            eventData.AuthKeyId);
        return Task.CompletedTask;
    }
}