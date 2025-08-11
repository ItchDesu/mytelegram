namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Channels;

///<summary>
/// Get link and embed info of a message in a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a>
/// <para>Possible errors</para>
/// Code Type Description
/// 400 CHANNEL_INVALID The provided channel is invalid.
/// 400 CHANNEL_PRIVATE You haven't joined this channel/supergroup.
/// 400 MESSAGE_ID_INVALID The provided message id is invalid.
/// 400 MSG_ID_INVALID Invalid message ID provided.
/// See <a href="https://corefork.telegram.org/method/channels.exportMessageLink" />
///</summary>
internal sealed class ExportMessageLinkHandler(IPeerHelper peerHelper)
    : RpcResultObjectHandler<MyTelegram.Schema.Channels.RequestExportMessageLink,
            MyTelegram.Schema.IExportedMessageLink>,
        Channels.IExportMessageLinkHandler
{
    protected override Task<IExportedMessageLink> HandleCoreAsync(IRequestInput input,
        RequestExportMessageLink obj)
    {
        var peer = peerHelper.GetChannel(obj.Channel);
        return Task.FromResult<IExportedMessageLink>(new TExportedMessageLink
        {
            Link = $"Not support export link.Id={obj.Id},channelId={peer.PeerId}",
            Html = "No html"
        });
    }
}
