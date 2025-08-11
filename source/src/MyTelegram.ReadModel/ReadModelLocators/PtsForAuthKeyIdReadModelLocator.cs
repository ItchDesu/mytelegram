namespace MyTelegram.ReadModel.ReadModelLocators;

public class PtsForAuthKeyIdReadModelLocator : IPtsForAuthKeyIdReadModelLocator, ITransientDependency
{
    public IEnumerable<string> GetReadModelIds(IDomainEvent domainEvent)
    {
        var aggregateEvent = domainEvent.GetAggregateEvent();
        var permAuthKeyId = 0L;
        var peerId = 0L;
        switch (aggregateEvent)
        {
            //case PtsAckedEvent ptsAckedEvent:
            //    permAuthKeyId = ptsAckedEvent.PermAuthKeyId;
            //    peerId= ptsAckedEvent.PeerId;
            //    break;
            case PtsUpdatedEvent ptsUpdatedEvent:
                permAuthKeyId=ptsUpdatedEvent.PermAuthKeyId;
                peerId= ptsUpdatedEvent.PeerId;
                break;

            case QtsUpdatedEvent qtsUpdatedEvent:
                permAuthKeyId = qtsUpdatedEvent.PermAuthKeyId;
                peerId = qtsUpdatedEvent.PeerId;
                break;
        }

        if (permAuthKeyId != 0)
        {
            yield return PtsForAuthKeyId.Create(peerId, permAuthKeyId).Value;
        }
    }
}