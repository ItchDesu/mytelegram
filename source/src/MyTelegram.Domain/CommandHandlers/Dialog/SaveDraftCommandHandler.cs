namespace MyTelegram.Domain.CommandHandlers.Dialog;

public class SaveDraftCommandHandler : CommandHandler<DialogAggregate, DialogId, SaveDraftCommand>
{
    public override Task ExecuteAsync(DialogAggregate aggregate,
        SaveDraftCommand command,
        CancellationToken cancellationToken)
    {
        aggregate.SaveDraft(command.RequestInfo,
            command.Draft);
        return Task.CompletedTask;
    }
}
