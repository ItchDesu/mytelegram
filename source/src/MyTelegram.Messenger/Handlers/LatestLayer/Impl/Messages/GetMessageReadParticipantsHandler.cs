namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Messages;

///<summary>
/// Get which users read a specific message: only available for groups and supergroups with less than <a href="https://corefork.telegram.org/api/config#chat-read-mark-size-threshold"><code>chat_read_mark_size_threshold</code> members</a>, read receipts will be stored for <a href="https://corefork.telegram.org/api/config#chat-read-mark-expire-period"><code>chat_read_mark_expire_period</code> seconds after the message was sent</a>, see <a href="https://corefork.telegram.org/api/config#client-configuration">client configuration for more info </a>.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 CHAT_TOO_BIG This method is not available for groups with more than <code>chat_read_mark_size_threshold</code> members, <a href="https://corefork.telegram.org/api/config#client-configuration">see client configuration</a>.
/// 400 MSG_ID_INVALID Invalid message ID provided.
/// 400 MSG_TOO_OLD <a href="https://corefork.telegram.org/api/config#chat-read-mark-expire-period"><code>chat_read_mark_expire_period</code> seconds</a> have passed since the message was sent, read receipts were deleted.
/// 400 PEER_ID_INVALID The provided peer id is invalid.
/// See <a href="https://corefork.telegram.org/method/messages.getMessageReadParticipants" />
///</summary>
internal sealed class GetMessageReadParticipantsHandler(
    IQueryProcessor queryProcessor,
    IPeerHelper peerHelper)
    : RpcResultObjectHandler<MyTelegram.Schema.Messages.RequestGetMessageReadParticipants,
            TVector<MyTelegram.Schema.IReadParticipantDate>>,
        Messages.IGetMessageReadParticipantsHandler
{
    protected override async Task<TVector<MyTelegram.Schema.IReadParticipantDate>> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Messages.RequestGetMessageReadParticipants obj)
    {
        var peer = peerHelper.GetPeer(obj.Peer);
        var ownerPeerId = peer.PeerType == PeerType.Channel ? peer.PeerId : input.UserId;
        var messageReadModel =
            await queryProcessor.ProcessAsync(new GetMessageByPeerIdAndMessageIdQuery(ownerPeerId, obj.MsgId));
        if (messageReadModel == null)
        {
            RpcErrors.RpcErrors400.MessageIdInvalid.ThrowRpcError();
        }

        var chatReadMarkExpirePeriod = 604800; // 7days
        var expireDate = messageReadModel!.Date + chatReadMarkExpirePeriod;
        if (CurrentDate > expireDate)
        {
            //RpcErrors.RpcErrors400.MsgTooOld.ThrowRpcError();
            return [];
        }

        var readModels = await queryProcessor
            .ProcessAsync(new GetMessageReadParticipantsQuery(input.UserId, peer.PeerId, obj.MsgId), default);

        return [.. readModels.Select(p => new TReadParticipantDate
        {
            Date = p.Date,
            UserId = p.ReaderPeerId,
        })];
    }
}
