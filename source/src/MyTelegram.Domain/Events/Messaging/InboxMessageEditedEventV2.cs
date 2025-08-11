namespace MyTelegram.Domain.Events.Messaging;

public class InboxMessageEditedEventV2(
    RequestInfo requestInfo,
    MessageItem oldMessageItem,
    MessageItem newMessageItem
)
    : RequestAggregateEvent2<MessageAggregate, MessageId>(requestInfo)
{
    public MessageItem OldMessageItem { get; } = oldMessageItem;
    public MessageItem NewMessageItem { get; } = newMessageItem;
}