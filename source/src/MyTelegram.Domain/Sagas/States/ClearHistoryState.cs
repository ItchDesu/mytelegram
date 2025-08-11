namespace MyTelegram.Domain.Sagas.States;

public class ClearHistoryState : AggregateState<ClearHistorySaga, ClearHistorySagaId, ClearHistoryState>,
    IApply<ClearHistorySagaStartedSagaEvent>,
    IApply<ClearSingleUserHistoryCompletedSagaEvent>,
    IApply<ClearHistoryPtsIncrementedSagaEvent>,
    IInMemoryAggregate
{
    public RequestInfo RequestInfo { get; private set; } = default!;
    public string MessageActionData { get; private set; } = default!;
    public bool NeedWaitForClearParticipantHistory { get; private set; }
    public int NextMaxId { get; private set; }

    public Dictionary<long, List<int>> OwnerToMessageIdList { get; private set; } = default!;

    public Dictionary<long, int> PeerToPts { get; private set; } = default!;
    public long RandomId { get; private set; }
    public bool Revoke { get; private set; }
    public Peer ToPeer { get; private set; } = default!;
    public int TotalCountToBeDelete { get; private set; }


    public void Apply(ClearHistoryPtsIncrementedSagaEvent aggregateEvent)
    {
        if (PeerToPts.TryGetValue(aggregateEvent.PeerId, out var pts))
        {
            if (pts < aggregateEvent.Pts)
            {
                PeerToPts[aggregateEvent.PeerId] = aggregateEvent.Pts;
            }
        }
        else
        {
            PeerToPts.TryAdd(aggregateEvent.PeerId, aggregateEvent.Pts);
        }

        if (OwnerToMessageIdList.TryGetValue(aggregateEvent.PeerId, out var messageIdList))
        {
            messageIdList.Add(aggregateEvent.MessageId);
        }
        else
        {
            OwnerToMessageIdList.TryAdd(aggregateEvent.PeerId, new List<int> { aggregateEvent.MessageId });
        }
    }

    public void Apply(ClearHistorySagaStartedSagaEvent aggregateEvent)
    {
        RequestInfo = aggregateEvent.RequestInfo;
        Revoke = aggregateEvent.Revoke;
        ToPeer = aggregateEvent.ToPeer;
        MessageActionData = aggregateEvent.MessageActionData;
        NextMaxId = aggregateEvent.NextMaxId;
        RandomId = aggregateEvent.RandomId;
        PeerToPts = new Dictionary<long, int>();
        OwnerToMessageIdList = new Dictionary<long, List<int>>();
        TotalCountToBeDelete = aggregateEvent.TotalCountToBeDelete;
        if (Revoke)
        {
            NeedWaitForClearParticipantHistory = true;
        }
    }

    public void Apply(ClearSingleUserHistoryCompletedSagaEvent aggregateEvent)
    {
    }

    public bool IsCompleted()
    {
        if (OwnerToMessageIdList.TryGetValue(RequestInfo.UserId, out var messageIdList))
        {
            if (messageIdList.Count == TotalCountToBeDelete)
            {
                foreach (var kv in OwnerToMessageIdList)
                {
                    if (kv.Value.Count != TotalCountToBeDelete)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        return false;
    }

    public bool IsCompletedForUserId(long userId)
    {
        if (OwnerToMessageIdList.TryGetValue(userId, out var messageIdList))
        {
            if (messageIdList.Count == TotalCountToBeDelete)
            {
                return true;
            }
        }

        return false;
    }
}
