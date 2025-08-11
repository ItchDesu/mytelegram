namespace MyTelegram.Domain.Aggregates.Pts;


public class PtsAggregate : MyInMemorySnapshotAggregateRoot<PtsAggregate, PtsId, PtsSnapshot>, INotSaveAggregateEvents
{
    private readonly PtsState _state = new();

    public PtsAggregate(PtsId id) : base(id,
        SnapshotEveryFewVersionsStrategy.Default
    )
    {
        Register(_state);
    }

    protected override Task<PtsSnapshot> CreateSnapshotAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult(new PtsSnapshot(_state.PeerId,
            _state.Pts,
            _state.Qts,
            _state.UnreadCount,
            _state.Date,
            _state.GlobalSeqNo, _state.PermAuthKeyId));
    }

    protected override Task LoadSnapshotAsync(PtsSnapshot snapshot,
        ISnapshotMetadata metadata,
        CancellationToken cancellationToken)
    {
        _state.LoadSnapshot(snapshot);
        return Task.CompletedTask;
    }

    public void PtsAcked(long peerId,
        long permAuthKeyId,
        long msgId,
        int pts,
        long globalSeqNo,
        Peer toPeer,
        bool isFromGetDifference
        )
    {
        Emit(new PtsAckedEvent(peerId,
            permAuthKeyId,
            msgId,
            pts,
            globalSeqNo,
            toPeer,
            isFromGetDifference
            ));
    }

    public void QtsAcked(long peerId,
        long permAuthKeyId,
        long msgId,
        int qts,
        long globalSeqNo,
        Peer toPeer,
        bool isFromGetDifference
        )
    {
        Emit(new QtsAckedEvent(peerId,
            permAuthKeyId,
            msgId,
            qts,
            globalSeqNo,
            toPeer,
            isFromGetDifference
            ));
    }

    public void UpdateGlobalSeqNo(long peerId,
        long permAuthKeyId,
        long globalSeqNo)
    {
        Emit(new PtsGlobalSeqNoUpdatedEvent(peerId, permAuthKeyId, globalSeqNo));
    }

    public void UpdatePts(long peerId,
        long permAuthKeyId,
        int newPts, long globalSeqNo, int changedUnreadCount, int? messageId)
    {
        if (!IsNew)
        {
            if (_state.Pts < newPts)
            {
                Emit(new PtsUpdatedEvent(peerId, permAuthKeyId, newPts, DateTime.UtcNow.ToTimestamp(), globalSeqNo, changedUnreadCount, messageId));
            }
        }
        else
        {
            Emit(new PtsUpdatedEvent(peerId, permAuthKeyId, newPts, DateTime.UtcNow.ToTimestamp(), globalSeqNo, changedUnreadCount, messageId));
        }
    }

    public void UpdateQts(long peerId,
        long permAuthKeyId,
        int newQts, long globalSeqNo)
    {
        if (!IsNew)
        {
            if (_state.Qts < newQts)
            {
                Emit(new QtsUpdatedEvent(peerId, permAuthKeyId, newQts, DateTime.UtcNow.ToTimestamp(), globalSeqNo));
            }
        }
        else
        {
            Emit(new QtsUpdatedEvent(peerId, permAuthKeyId, newQts, DateTime.UtcNow.ToTimestamp(), globalSeqNo));
        }
    }

    public void UpdatePtsForAuthKeyId(long peerId,
        long permAuthKeyId,
        int pts,
        int changedUnreadCount,
        long globalSeqNo)
    {
        Emit(new PtsForAuthKeyIdUpdatedEvent(peerId, permAuthKeyId, pts, changedUnreadCount, globalSeqNo));
    }

    public void UpdateQtsForAuthKeyId(long peerId,
        long permAuthKeyId,
        int qts,
        long globalSeqNo
        )
    {
        Emit(new QtsForAuthKeyIdUpdatedEvent(peerId, permAuthKeyId, qts, globalSeqNo));
    }
}