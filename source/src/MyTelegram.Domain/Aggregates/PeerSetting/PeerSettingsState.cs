namespace MyTelegram.Domain.Aggregates.PeerSetting;

public class PeerSettingsState : AggregateState<PeerSettingsAggregate, PeerSettingsId, PeerSettingsState>,
    IApply<PeerSettingsBarHiddenEvent>
{
    public PeerSettings PeerSettings { get; private set; } = new();
    public bool HidePeerSettingsBar { get; private set; }
    public long OwnerPeerId { get; private set; }
    public long PeerId { get; private set; }

    public void LoadSnapshot(PeerSettingsSnapshot snapshot)
    {
        PeerSettings = snapshot.PeerSettings;
    }

    public void Apply(PeerSettingsBarHiddenEvent aggregateEvent)
    {
        HidePeerSettingsBar = true;
        OwnerPeerId = aggregateEvent.OwnerPeerId;
        PeerId = aggregateEvent.PeerId;
    }
}