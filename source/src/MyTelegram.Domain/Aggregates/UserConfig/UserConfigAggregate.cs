using MyTelegram.Domain.Commands;

namespace MyTelegram.Domain.Aggregates.UserConfig;

public class UserConfigId(string value) : Identity<UserConfigId>(value)
{
    public static UserConfigId Create(long userId, string key)
    {
        return NewDeterministic(GuidFactories.Deterministic.Namespaces.Commands, $"userconfig-id-{userId}-{key}");
    }
}

public record UserConfigSnapshot(long UserId, string Key, string Value) : ISnapshot;

public class UserConfigState : AggregateState<UserConfigAggregate, UserConfigId, UserConfigState>,
    IApply<UserConfigChangedEvent>
{
    public long UserId { get; private set; }
    public string Key { get; private set; }
    public string Value { get; private set; }

    public void LoadSnapshot(UserConfigSnapshot snapshot)
    {
        UserId = snapshot.UserId;
        Key = snapshot.Key;
        Value = snapshot.Value;
    }

    public void Apply(UserConfigChangedEvent aggregateEvent)
    {
        UserId = aggregateEvent.UserId;
        Key = aggregateEvent.Key;
        Value = aggregateEvent.Value;
    }
}

public class UserConfigChangedEvent(RequestInfo requestInfo, long userId, string key, string value) : RequestAggregateEvent2<UserConfigAggregate, UserConfigId>(requestInfo)
{
    public long UserId { get; } = userId;
    public string Key { get; } = key;
    public string Value { get; } = value;
}

public class UpdateUserConfigCommand(UserConfigId aggregateId, RequestInfo requestInfo, long userId, string key, string value) : RequestCommand2<UserConfigAggregate, UserConfigId, IExecutionResult>(aggregateId, requestInfo)
{
    public long UserId { get; } = userId;
    public string Key { get; } = key;
    public string Value { get; } = value;
}

public class UpdateUserConfigCommandHandler : CommandHandler<UserConfigAggregate, UserConfigId, UpdateUserConfigCommand>
{
    public override Task ExecuteAsync(UserConfigAggregate aggregate, UpdateUserConfigCommand command, CancellationToken cancellationToken)
    {
        aggregate.UpdateConfig(command.RequestInfo,command.UserId,command.Key,command.Value);

        return Task.CompletedTask;
    }
}

public class UserConfigAggregate : MyInMemorySnapshotAggregateRoot<UserConfigAggregate, UserConfigId, UserConfigSnapshot>
{
    private readonly UserConfigState _state = new();

    public UserConfigAggregate(UserConfigId id) : base(id, SnapshotEveryFewVersionsStrategy.Default)
    {
        Register(_state);
    }

    public void UpdateConfig(RequestInfo requestInfo, long userId, string key, string value)
    {
        Emit(new UserConfigChangedEvent(requestInfo, userId, key, value));
    }

    protected override Task<UserConfigSnapshot> CreateSnapshotAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult(new UserConfigSnapshot(_state.UserId, _state.Key, _state.Value));
    }

    protected override Task LoadSnapshotAsync(UserConfigSnapshot snapshot, ISnapshotMetadata metadata, CancellationToken cancellationToken)
    {
        _state.LoadSnapshot(snapshot);

        return Task.CompletedTask;
    }
}
