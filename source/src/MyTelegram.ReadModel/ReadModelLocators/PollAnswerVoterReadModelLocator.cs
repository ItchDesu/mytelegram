namespace MyTelegram.ReadModel.ReadModelLocators;

public class PollAnswerVoterReadModelLocator : IPollAnswerVoterReadModelLocator, ITransientDependency
{
    public IEnumerable<string> GetReadModelIds(IDomainEvent domainEvent)
    {
        var aggregateEvent = domainEvent.GetAggregateEvent();
        switch (aggregateEvent)
        {
            case VoteAnswerCreatedEvent voteAnswerCreatedEvent:
                yield return $"{domainEvent.GetIdentity().Value}_{voteAnswerCreatedEvent.VoterPeerId}";
                break;
            case VoteAnswerDeletedEvent voteAnswerDeletedEvent:
                yield return $"{domainEvent.GetIdentity().Value}_{voteAnswerDeletedEvent.VoterPeerId}";
                break;
        }
    }
}