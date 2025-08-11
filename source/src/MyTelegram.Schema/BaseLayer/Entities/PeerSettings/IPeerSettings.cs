// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// List of actions that are possible when interacting with this user, to be shown as suggested actions in the chat bar
/// See <a href="https://corefork.telegram.org/constructor/PeerSettings" />
///</summary>
[JsonDerivedType(typeof(TPeerSettings), nameof(TPeerSettings))]
public interface IPeerSettings : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// Whether we can still report the user for spam
    ///</summary>
    bool ReportSpam { get; set; }

    ///<summary>
    /// Whether we can add the user as contact
    ///</summary>
    bool AddContact { get; set; }

    ///<summary>
    /// Whether we can block the user
    ///</summary>
    bool BlockContact { get; set; }

    ///<summary>
    /// Whether we can share the user's contact
    ///</summary>
    bool ShareContact { get; set; }

    ///<summary>
    /// Whether a special exception for contacts is needed
    ///</summary>
    bool NeedContactsException { get; set; }

    ///<summary>
    /// Whether we can report a geogroup as irrelevant for this location
    ///</summary>
    bool ReportGeo { get; set; }

    ///<summary>
    /// Whether this peer was automatically archived according to <a href="https://corefork.telegram.org/constructor/globalPrivacySettings">privacy settings</a> and can be unarchived
    ///</summary>
    bool Autoarchived { get; set; }

    ///<summary>
    /// If set, this is a recently created group chat to which new members can be invited
    ///</summary>
    bool InviteMembers { get; set; }

    ///<summary>
    /// This flag is set if <code>request_chat_title</code> and <code>request_chat_date</code> fields are set and the <a href="https://corefork.telegram.org/api/invites#join-requests">join request </a> is related to a channel (otherwise if only the request fields are set, the <a href="https://corefork.telegram.org/api/invites#join-requests">join request </a> is related to a chat).
    ///</summary>
    bool RequestChatBroadcast { get; set; }

    ///<summary>
    /// This flag is set if both <code>business_bot_id</code> and <code>business_bot_manage_url</code> are set and all <a href="https://corefork.telegram.org/api/business#connected-bots">connected business bots </a> were paused in this chat using <a href="https://corefork.telegram.org/method/account.toggleConnectedBotPaused">account.toggleConnectedBotPaused </a>.
    ///</summary>
    bool BusinessBotPaused { get; set; }

    ///<summary>
    /// This flag is set if both <code>business_bot_id</code> and <code>business_bot_manage_url</code> are set and <a href="https://corefork.telegram.org/api/business#connected-bots">connected business bots </a> can reply to messages in this chat, as specified by the settings during <a href="https://corefork.telegram.org/api/business#connected-bots">initial configuration</a>.
    ///</summary>
    bool BusinessBotCanReply { get; set; }

    ///<summary>
    /// Distance in meters between us and this peer
    ///</summary>
    int? GeoDistance { get; set; }

    ///<summary>
    /// If set, this is a private chat with an administrator of a chat or channel to which the user sent a join request, and this field contains the chat/channel's title.
    ///</summary>
    string? RequestChatTitle { get; set; }

    ///<summary>
    /// If set, this is a private chat with an administrator of a chat or channel to which the user sent a join request, and this field contains the timestamp when the <a href="https://corefork.telegram.org/api/invites#join-requests">join request </a> was sent.
    ///</summary>
    int? RequestChatDate { get; set; }

    ///<summary>
    /// Contains the ID of the <a href="https://corefork.telegram.org/api/business#connected-bots">business bot </a> managing this chat, used to display info about the bot in the action bar.
    ///</summary>
    long? BusinessBotId { get; set; }

    ///<summary>
    /// Contains a <a href="https://corefork.telegram.org/api/links">deep link </a>, used to open a management menu in the business bot. This flag is set if and only if <code>business_bot_id</code> is set.
    ///</summary>
    string? BusinessBotManageUrl { get; set; }
    long? ChargePaidMessageStars { get; set; }
    string? RegistrationMonth { get; set; }
    string? PhoneCountry { get; set; }
    int? NameChangeDate { get; set; }
    int? PhotoChangeDate { get; set; }
}
