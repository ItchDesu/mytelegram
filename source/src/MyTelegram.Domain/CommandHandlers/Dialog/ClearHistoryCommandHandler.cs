namespace MyTelegram.Domain.CommandHandlers.Dialog;

public class ClearHistoryCommandHandler : CommandHandler<DialogAggregate, DialogId, ClearHistoryCommand>
{
    public override Task ExecuteAsync(DialogAggregate aggregate,
        ClearHistoryCommand command,
        CancellationToken cancellationToken)
    {
        aggregate.ClearHistory(command.RequestInfo,
            command.Revoke,
            command.MessageActionData,
            command.RandomId,
            command.MessageIdListToBeDelete,
            command.NextMaxId);
        return Task.CompletedTask;
    }
}
