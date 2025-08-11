namespace MyTelegram.Converters.TLObjects.LatestLayer;

internal sealed class PeerNotifySettingsConverter(IObjectMapper objectMapper)
    : IPeerNotifySettingsConverter, ITransientDependency
{
    
    public int Layer => Layers.LayerLatest;

    public IPeerNotifySettings ToPeerNotifySettings(PeerNotifySettings peerNotifySettings)
    {
        return objectMapper.Map<PeerNotifySettings, TPeerNotifySettings>(peerNotifySettings);
    }

    public IPeerNotifySettings ToPeerNotifySettings(IPeerNotifySettingsReadModel? readModel)
    {
        return objectMapper.Map<PeerNotifySettings, TPeerNotifySettings>(readModel?.NotifySettings ??
                                                                         PeerNotifySettings.DefaultSettings);
    }
}