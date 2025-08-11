namespace MyTelegram.Domain.Sagas;

public class SignInSaga :
    MyInMemoryAggregateSaga<SignInSaga, SignInSagaId, SignInSagaLocator>,
    ISagaIsStartedBy<AppCodeAggregate, AppCodeId, CheckSignInCodeCompletedEvent>,
    ISagaHandles<UserAggregate, UserId, CheckUserStatusCompletedEvent>,
    IApply<SignInSuccessSagaEvent>,
    IApply<SignUpRequiredSagaEvent>
{
    private readonly SignInSagaState _state = new();

    public SignInSaga(SignInSagaId id, IEventStore eventStore) : base(id, eventStore)
    {
        Register(_state);
    }

    public void Apply(SignInSuccessSagaEvent aggregateEvent)
    {
        CompleteAsync();
    }

    public Task HandleAsync(IDomainEvent<UserAggregate, UserId, CheckUserStatusCompletedEvent> domainEvent,
        ISagaContext sagaContext,
        CancellationToken cancellationToken)
    {
        Emit(new SignInSuccessSagaEvent(_state.RequestInfo,
            _state.RequestInfo.AuthKeyId,
            _state.RequestInfo.PermAuthKeyId,
            domainEvent.AggregateEvent.UserId,
            domainEvent.AggregateEvent.AccessHash,
            domainEvent.AggregateEvent.UserId == 0,
            domainEvent.AggregateEvent.PhoneNumber,
            domainEvent.AggregateEvent.FirstName,
            domainEvent.AggregateEvent.LastName,
            domainEvent.AggregateEvent.HasPassword));

        return Task.CompletedTask;
    }

    public async Task HandleAsync(IDomainEvent<AppCodeAggregate, AppCodeId, CheckSignInCodeCompletedEvent> domainEvent,
        ISagaContext sagaContext,
        CancellationToken cancellationToken)
    {
        if (!domainEvent.AggregateEvent.IsCodeValid)
        {
            await CompleteAsync(cancellationToken);
            RpcErrors.RpcErrors400.PhoneCodeInvalid.ThrowRpcError();
        }

        if (domainEvent.AggregateEvent.UserId == 0)
        {
            Emit(new SignUpRequiredSagaEvent(domainEvent.AggregateEvent.RequestInfo));
            return;
        }

        Emit(new SignInStartedSagaEvent(domainEvent.AggregateEvent.RequestInfo));
        var checkUserStatusCommand = new CheckUserStatusCommand(UserId.Create(domainEvent.AggregateEvent.UserId),
            domainEvent.AggregateEvent.RequestInfo);
        Publish(checkUserStatusCommand);
    }

    public void Apply(SignUpRequiredSagaEvent aggregateEvent)
    {
        CompleteAsync();
    }
}
