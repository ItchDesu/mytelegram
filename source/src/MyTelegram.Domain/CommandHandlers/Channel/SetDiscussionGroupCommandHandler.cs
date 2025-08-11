namespace MyTelegram.Domain.CommandHandlers.Channel;

public class
    SetDiscussionGroupCommandHandler : CommandHandler<ChannelAggregate, ChannelId, SetDiscussionGroupCommand>
{
    public override Task ExecuteAsync(ChannelAggregate aggregate,
        SetDiscussionGroupCommand command,
        CancellationToken cancellationToken)
    {
        aggregate.SetDiscussionGroup(command.RequestInfo,
            command.BroadcastChannelId,
            command.GroupChannelId);
        return Task.CompletedTask;
    }
}
