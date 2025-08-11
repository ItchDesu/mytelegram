namespace MyTelegram.ReadModel.ReadModelLocators;

public class ChatAdminReadModelLocator : IChatAdminReadModelLocator, ITransientDependency
{
    public IEnumerable<string> GetReadModelIds(IDomainEvent domainEvent)
    {
        var aggregateEvent = domainEvent.GetAggregateEvent();
        switch (aggregateEvent)
        {
            case ChannelAdminRightsEditedEvent channelAdminRightsEditedEvent:
                yield return AdminId.Create(channelAdminRightsEditedEvent.ChannelId, channelAdminRightsEditedEvent.UserId).Value;
                break;
            case ChannelCreatedEvent channelCreatedEvent:
                yield return AdminId.Create(channelCreatedEvent.ChannelId, channelCreatedEvent.CreatorId).Value;
                break;
        }
    }
}