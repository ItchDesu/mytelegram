namespace MyTelegram.Domain.CommandHandlers.Pts;

public class UpdateQtsCommandHandler : CommandHandler<PtsAggregate, PtsId, UpdateQtsCommand>
{
    public override Task ExecuteAsync(PtsAggregate aggregate,
        UpdateQtsCommand command,
        CancellationToken cancellationToken)
    {
        aggregate.UpdateQts(command.PeerId, command.PermAuthKeyId,command.NewQts,command.GlobalSeqNo);
        return Task.CompletedTask;
    }
}
