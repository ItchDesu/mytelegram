namespace MyTelegram.Domain.Sagas;

public class ClearHistorySaga : MyInMemoryAggregateSaga<ClearHistorySaga, ClearHistorySagaId, ClearHistorySagaLocator>,
    ISagaIsStartedBy<DialogAggregate, DialogId, HistoryClearedEvent>,
    ISagaHandles<MessageAggregate, MessageId, MessageDeletedEvent>,
    ISagaHandles<MessageAggregate, MessageId, OtherPartyMessageDeletedEvent>,
    IApply<ClearHistorySagaCompletedSagaEvent>
{
    private readonly IIdGenerator _idGenerator;
    private readonly ClearHistoryState _state = new();

    public ClearHistorySaga(ClearHistorySagaId id, IEventStore eventStore, IIdGenerator idGenerator) : base(id, eventStore)
    {
        _idGenerator = idGenerator;
        Register(_state);
    }

    public void Apply(ClearHistorySagaCompletedSagaEvent aggregateEvent)
    {
        CompleteAsync();
    }

    public async Task HandleAsync(IDomainEvent<MessageAggregate, MessageId, MessageDeletedEvent> domainEvent,
        ISagaContext sagaContext,
        CancellationToken cancellationToken)
    {
        await IncrementPtsAsync(domainEvent.AggregateEvent.OwnerPeerId, domainEvent.AggregateEvent.MessageId)
     ;
        DeleteMessagesForOtherParty(domainEvent.AggregateEvent);
    }

    public async Task HandleAsync(
        IDomainEvent<MessageAggregate, MessageId, OtherPartyMessageDeletedEvent> domainEvent,
        ISagaContext sagaContext,
        CancellationToken cancellationToken)
    {
        await IncrementPtsAsync(domainEvent.AggregateEvent.OwnerPeerId, domainEvent.AggregateEvent.MessageId)
     ;
    }

    public Task HandleAsync(IDomainEvent<DialogAggregate, DialogId, HistoryClearedEvent> domainEvent,
        ISagaContext sagaContext,
        CancellationToken cancellationToken)
    {
        return CompleteAsync(cancellationToken);
        //Emit(new ClearHistorySagaStartedEvent(domainEvent.AggregateEvent.RequestInfo,
        //    domainEvent.AggregateEvent.OwnerPeerId,
        //    domainEvent.AggregateEvent.Revoke,
        //    domainEvent.AggregateEvent.ToPeer,
        //    domainEvent.AggregateEvent.MessageActionData,
        //    domainEvent.AggregateEvent.RandomId,
        //    domainEvent.AggregateEvent.MessageIdListToBeDelete.Count,
        //    domainEvent.AggregateEvent.NextMaxId
        //));

        //DeleteMessagesForSelf(domainEvent.AggregateEvent.OwnerPeerId,
        //    domainEvent.AggregateEvent.MessageIdListToBeDelete,
        //    domainEvent.AggregateEvent.CorrelationId);

        //return Task.CompletedTask;
    }

    private void DeleteMessagesForOtherParty(MessageDeletedEvent aggregateEvent)
    {
        if (!_state.Revoke)
        {
            return;
        }

        // Only user peer support clear other member's history
        if (_state.ToPeer.PeerType != PeerType.User)
        {
            return;
        }

        if (aggregateEvent.IsOut)
        {
            if (aggregateEvent.InboxItems?.Count > 0)
            {
                foreach (var inboxItem in aggregateEvent.InboxItems)
                {
                    if (inboxItem.InboxOwnerPeerId == _state.RequestInfo.UserId)
                    {
                        continue;
                    }

                    var command = new DeleteOtherPartyMessageCommand(
                        MessageId.Create(inboxItem.InboxOwnerPeerId, inboxItem.InboxMessageId),
                        _state.RequestInfo
                        );
                    Publish(command);
                }
            }
        }
        else if (_state.ToPeer.PeerType == PeerType.User)
        {
            var command = new DeleteOtherPartyMessageCommand(
                MessageId.Create(aggregateEvent.SenderPeerId, aggregateEvent.SenderMessageId), _state.RequestInfo);
            Publish(command);
        }
    }

    //private void DeleteMessagesForSelf(long selfUserId,
    //    IReadOnlyList<int> messageIdList)
    //{
    //    foreach (var messageId in messageIdList)
    //    {
    //        var command = new DeleteMessageCommand(MessageId.Create(selfUserId, messageId));
    //        Publish(command);
    //    }
    //}

    private async Task HandleClearHistoryCompletedAsync(long peerId)
    {
        if (_state.IsCompletedForUserId(peerId))
        {
            if (_state.OwnerToMessageIdList.TryGetValue(peerId, out var deletedMessageIdList))
            {
                if (_state.PeerToPts.TryGetValue(peerId, out var pts))
                {
                    Emit(new ClearSingleUserHistoryCompletedSagaEvent(_state.RequestInfo,
                        _state.RequestInfo.AuthKeyId,
                        _state.NextMaxId,
                        _state.RequestInfo.UserId == peerId,
                        _state.ToPeer.PeerType,
                        new DeletedBoxItem(peerId, pts, deletedMessageIdList.Count, deletedMessageIdList)
                    ));
                }
            }

            if (_state.IsCompleted())
            {
                // after messages cleared should send history cleared service message
                var ownerPeerId = _state.RequestInfo.UserId;
                var outMessageId = await _idGenerator.NextIdAsync(IdType.MessageId, ownerPeerId);
                //var aggregateId = MessageId.Create(ownerPeerId, outMessageId);
                var messageItem = new MessageItem(
                    new Peer(PeerType.User, ownerPeerId),
                    _state.ToPeer,
                    new Peer(PeerType.User, _state.RequestInfo.UserId),
                    _state.RequestInfo.UserId,
                    outMessageId,
                    string.Empty,
                    DateTime.UtcNow.ToTimestamp(),
                    _state.RandomId,
                    true,
                    SendMessageType.MessageService,
                    MessageSubType: MessageSubType.ClearHistory,
                    //MessageActionData: _state.MessageActionData,

                    MessageActionType: MessageActionType.HistoryClear);
                //var command = new CreateOutboxMessageCommand(aggregateId, _state.RequestInfo with { RequestId = Guid.NewGuid() }, messageItem);
                var command = new StartSendMessageCommand(TempId.New,
                                    _state.RequestInfo with { RequestId = Guid.NewGuid() },
                    [new SendMessageItem(messageItem)]
                );
                Publish(command);

                Emit(new ClearHistorySagaCompletedSagaEvent());
            }
        }
    }

    private async Task IncrementPtsAsync(long peerId,
        int messageId)
    {
        var pts = await _idGenerator.NextIdAsync(IdType.Pts, peerId);
        Emit(new ClearHistoryPtsIncrementedSagaEvent(peerId, messageId, pts));
        await HandleClearHistoryCompletedAsync(peerId);
    }
}
