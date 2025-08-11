namespace MyTelegram.Domain.Sagas;

public class ImportContactsSaga : AggregateSaga<ImportContactsSaga, ImportContactsSagaId, ImportContactsSagaLocator>,
    ISagaIsStartedBy<ImportedContactAggregate, ImportedContactId, ContactsImportedEvent>,
    ISagaHandles<ImportedContactAggregate, ImportedContactId, SingleContactImportedEvent>,
    IApply<ImportContactsCompletedSagaEvent>
{
    private readonly ImportContactsSagaState _state = new();

    public ImportContactsSaga(ImportContactsSagaId id) : base(id)
    {
        Register(_state);
    }

    public void Apply(ImportContactsCompletedSagaEvent aggregateEvent)
    {
        Complete();
    }

    public Task HandleAsync(
        IDomainEvent<ImportedContactAggregate, ImportedContactId, SingleContactImportedEvent> domainEvent,
        ISagaContext sagaContext,
        CancellationToken cancellationToken)
    {
        Emit(new ImportContactsSagaSingleContactImportedSagaEvent(domainEvent.AggregateEvent.PhoneContact));
        HandleImportContactsCompleted();
        return Task.CompletedTask;
    }

    public Task HandleAsync(
        IDomainEvent<ImportedContactAggregate, ImportedContactId, ContactsImportedEvent> domainEvent,
        ISagaContext sagaContext,
        CancellationToken cancellationToken)
    {
        Emit(new ImportContactsStartedSagaEvent(domainEvent.AggregateEvent.RequestInfo,
            domainEvent.AggregateEvent.PhoneContacts.Count));
        foreach (var phoneContact in domainEvent.AggregateEvent.PhoneContacts)
        {
            var command = new ImportSingleContactCommand(
                ImportedContactId.Create(domainEvent.AggregateEvent.SelfUserId, phoneContact.Phone),
                _state.RequestInfo,
                domainEvent.AggregateEvent.SelfUserId,
                phoneContact);
            Publish(command);

            if (phoneContact.UserId > 0)
            {
                var addContactCommand = new CreateContactCommand(
                    ContactId.Create(domainEvent.AggregateEvent.SelfUserId, phoneContact.UserId),
                    domainEvent.AggregateEvent.SelfUserId,
                    phoneContact.UserId,
                    phoneContact.Phone,
                    phoneContact.FirstName,
                    phoneContact.LastName,
                    false);
                Publish(addContactCommand);
            }
        }

        return Task.CompletedTask;
    }

    private void HandleImportContactsCompleted()
    {
        if (_state.IsCompleted())
        {
            Emit(new ImportContactsCompletedSagaEvent(_state.RequestInfo, _state.PhoneContacts));
        }
    }
}
