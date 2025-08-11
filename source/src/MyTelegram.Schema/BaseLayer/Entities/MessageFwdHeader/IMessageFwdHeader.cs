// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Info about a forwarded message
/// See <a href="https://corefork.telegram.org/constructor/MessageFwdHeader" />
///</summary>
[JsonDerivedType(typeof(TMessageFwdHeader), nameof(TMessageFwdHeader))]
public interface IMessageFwdHeader : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// Whether this message was <a href="https://corefork.telegram.org/api/import">imported from a foreign chat service, click here for more info </a>
    ///</summary>
    bool Imported { get; set; }

    ///<summary>
    /// Only for messages forwarded to <a href="https://corefork.telegram.org/api/saved-messages">saved messages </a>, set if the original message was outgoing (though the message may have been originally outgoing even if this flag is not set, if <code>from_id</code> points to the current user).
    ///</summary>
    bool SavedOut { get; set; }

    ///<summary>
    /// The ID of the user that originally sent the message
    /// See <a href="https://corefork.telegram.org/type/Peer" />
    ///</summary>
    MyTelegram.Schema.IPeer? FromId { get; set; }

    ///<summary>
    /// The name of the user that originally sent the message
    ///</summary>
    string? FromName { get; set; }

    ///<summary>
    /// When was the message originally sent
    ///</summary>
    int Date { get; set; }

    ///<summary>
    /// ID of the channel message that was forwarded
    ///</summary>
    int? ChannelPost { get; set; }

    ///<summary>
    /// For channels and if signatures are enabled, author of the channel message
    ///</summary>
    string? PostAuthor { get; set; }

    ///<summary>
    /// Only for messages forwarded to <a href="https://corefork.telegram.org/api/saved-messages">saved messages </a>, contains the dialog where the message was originally sent.
    /// See <a href="https://corefork.telegram.org/type/Peer" />
    ///</summary>
    MyTelegram.Schema.IPeer? SavedFromPeer { get; set; }

    ///<summary>
    /// Only for messages forwarded to <a href="https://corefork.telegram.org/api/saved-messages">saved messages </a>, contains the original ID of the message in <code>saved_from_peer</code>.
    ///</summary>
    int? SavedFromMsgId { get; set; }

    ///<summary>
    /// Only for forwarded messages reforwarded to <a href="https://corefork.telegram.org/api/saved-messages">saved messages </a>, contains the sender of the original message (i.e. if user A sends a message, then user B forwards it somewhere, then user C saves it to saved messages, this field will contain the ID of user B and <code>from_id</code> will contain the ID of user A).
    /// See <a href="https://corefork.telegram.org/type/Peer" />
    ///</summary>
    MyTelegram.Schema.IPeer? SavedFromId { get; set; }

    ///<summary>
    /// Only for forwarded messages from users with forward privacy enabled, sent by users with forward privacy enabled, reforwarded to <a href="https://corefork.telegram.org/api/saved-messages">saved messages </a>, contains the sender of the original message (i.e. if user A (fwd privacy enabled) sends a message, then user B (fwd privacy enabled) forwards it somewhere, then user C saves it to saved messages, this field will contain the name of user B and <code>from_name</code> will contain the name of user A).
    ///</summary>
    string? SavedFromName { get; set; }

    ///<summary>
    /// Only for forwarded messages reforwarded to <a href="https://corefork.telegram.org/api/saved-messages">saved messages </a>, indicates when was the original message sent (i.e. if user A sends a message @ unixtime 1, then user B forwards it somewhere @ unixtime 2, then user C saves it to saved messages @ unixtime 3, this field will contain 2, <code>date</code> will contain 1 and the <code>date</code> of the containing <a href="https://corefork.telegram.org/constructor/message">message</a> will contain 3).
    ///</summary>
    int? SavedDate { get; set; }

    ///<summary>
    /// PSA type
    ///</summary>
    string? PsaType { get; set; }
}
