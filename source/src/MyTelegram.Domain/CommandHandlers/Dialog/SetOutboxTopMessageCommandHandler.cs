namespace MyTelegram.Domain.CommandHandlers.Dialog;

public class SetOutboxTopMessageCommandHandler : CommandHandler<DialogAggregate, DialogId, SetOutboxTopMessageCommand>
{
    public override Task ExecuteAsync(DialogAggregate aggregate,
        SetOutboxTopMessageCommand command,
        CancellationToken cancellationToken)
    {
        aggregate.SetOutboxTopMessage(
            //command.RequestInfo,
            command.MessageId,
            command.OwnerPeerId,
            //command.Pts,
            command.ToPeer,
            command.ClearDraft);
        return Task.CompletedTask;
    }
}
