namespace MyTelegram.Domain.CommandHandlers.AppCode;

public class SendAppCodeCommandHandler : CommandHandler<AppCodeAggregate, AppCodeId, SendAppCodeCommand>
{
    public override Task ExecuteAsync(AppCodeAggregate aggregate,
        SendAppCodeCommand command,
        CancellationToken cancellationToken)
    {
        aggregate.Create(command.RequestInfo,
            command.UserId,
            command.PhoneNumber,
            command.Code,
            command.PhoneCodeHash,
            command.CreationTime);
        return Task.CompletedTask;
    }
}
