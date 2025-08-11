// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Channel admin log event
/// See <a href="https://corefork.telegram.org/constructor/ChannelAdminLogEventAction" />
///</summary>
[JsonDerivedType(typeof(TChannelAdminLogEventActionChangeTitle), nameof(TChannelAdminLogEventActionChangeTitle))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionChangeAbout), nameof(TChannelAdminLogEventActionChangeAbout))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionChangeUsername), nameof(TChannelAdminLogEventActionChangeUsername))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionChangePhoto), nameof(TChannelAdminLogEventActionChangePhoto))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionToggleInvites), nameof(TChannelAdminLogEventActionToggleInvites))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionToggleSignatures), nameof(TChannelAdminLogEventActionToggleSignatures))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionUpdatePinned), nameof(TChannelAdminLogEventActionUpdatePinned))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionEditMessage), nameof(TChannelAdminLogEventActionEditMessage))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionDeleteMessage), nameof(TChannelAdminLogEventActionDeleteMessage))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionParticipantJoin), nameof(TChannelAdminLogEventActionParticipantJoin))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionParticipantLeave), nameof(TChannelAdminLogEventActionParticipantLeave))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionParticipantInvite), nameof(TChannelAdminLogEventActionParticipantInvite))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionParticipantToggleBan), nameof(TChannelAdminLogEventActionParticipantToggleBan))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionParticipantToggleAdmin), nameof(TChannelAdminLogEventActionParticipantToggleAdmin))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionChangeStickerSet), nameof(TChannelAdminLogEventActionChangeStickerSet))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionTogglePreHistoryHidden), nameof(TChannelAdminLogEventActionTogglePreHistoryHidden))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionDefaultBannedRights), nameof(TChannelAdminLogEventActionDefaultBannedRights))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionStopPoll), nameof(TChannelAdminLogEventActionStopPoll))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionChangeLinkedChat), nameof(TChannelAdminLogEventActionChangeLinkedChat))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionChangeLocation), nameof(TChannelAdminLogEventActionChangeLocation))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionToggleSlowMode), nameof(TChannelAdminLogEventActionToggleSlowMode))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionStartGroupCall), nameof(TChannelAdminLogEventActionStartGroupCall))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionDiscardGroupCall), nameof(TChannelAdminLogEventActionDiscardGroupCall))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionParticipantMute), nameof(TChannelAdminLogEventActionParticipantMute))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionParticipantUnmute), nameof(TChannelAdminLogEventActionParticipantUnmute))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionToggleGroupCallSetting), nameof(TChannelAdminLogEventActionToggleGroupCallSetting))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionParticipantJoinByInvite), nameof(TChannelAdminLogEventActionParticipantJoinByInvite))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionExportedInviteDelete), nameof(TChannelAdminLogEventActionExportedInviteDelete))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionExportedInviteRevoke), nameof(TChannelAdminLogEventActionExportedInviteRevoke))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionExportedInviteEdit), nameof(TChannelAdminLogEventActionExportedInviteEdit))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionParticipantVolume), nameof(TChannelAdminLogEventActionParticipantVolume))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionChangeHistoryTTL), nameof(TChannelAdminLogEventActionChangeHistoryTTL))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionParticipantJoinByRequest), nameof(TChannelAdminLogEventActionParticipantJoinByRequest))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionToggleNoForwards), nameof(TChannelAdminLogEventActionToggleNoForwards))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionSendMessage), nameof(TChannelAdminLogEventActionSendMessage))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionChangeAvailableReactions), nameof(TChannelAdminLogEventActionChangeAvailableReactions))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionChangeUsernames), nameof(TChannelAdminLogEventActionChangeUsernames))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionToggleForum), nameof(TChannelAdminLogEventActionToggleForum))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionCreateTopic), nameof(TChannelAdminLogEventActionCreateTopic))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionEditTopic), nameof(TChannelAdminLogEventActionEditTopic))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionDeleteTopic), nameof(TChannelAdminLogEventActionDeleteTopic))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionPinTopic), nameof(TChannelAdminLogEventActionPinTopic))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionToggleAntiSpam), nameof(TChannelAdminLogEventActionToggleAntiSpam))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionChangePeerColor), nameof(TChannelAdminLogEventActionChangePeerColor))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionChangeProfilePeerColor), nameof(TChannelAdminLogEventActionChangeProfilePeerColor))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionChangeWallpaper), nameof(TChannelAdminLogEventActionChangeWallpaper))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionChangeEmojiStatus), nameof(TChannelAdminLogEventActionChangeEmojiStatus))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionChangeEmojiStickerSet), nameof(TChannelAdminLogEventActionChangeEmojiStickerSet))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionToggleSignatureProfiles), nameof(TChannelAdminLogEventActionToggleSignatureProfiles))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionParticipantSubExtend), nameof(TChannelAdminLogEventActionParticipantSubExtend))]
[JsonDerivedType(typeof(TChannelAdminLogEventActionToggleAutotranslation), nameof(TChannelAdminLogEventActionToggleAutotranslation))]
public interface IChannelAdminLogEventAction : IObject
{

}
