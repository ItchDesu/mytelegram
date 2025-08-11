namespace MyTelegram.Domain.Aggregates.PeerSetting;

public class
    HidePeerSettingsBarCommandHandler : CommandHandler<PeerSettingsAggregate, PeerSettingsId,
        HidePeerSettingsBarCommand>
{
    public override Task ExecuteAsync(PeerSettingsAggregate aggregate, HidePeerSettingsBarCommand command,
        CancellationToken cancellationToken)
    {
        aggregate.HidePeerSettingsBar(command.RequestInfo, command.PeerId);
        return Task.CompletedTask;
    }
}