// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Contains info about a <a href="https://corefork.telegram.org/api/business#business-chat-links">business chat deep link </a> created by the current account.
/// See <a href="https://corefork.telegram.org/constructor/BusinessChatLink" />
///</summary>
[JsonDerivedType(typeof(TBusinessChatLink), nameof(TBusinessChatLink))]
public interface IBusinessChatLink : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/links#business-chat-links">Business chat deep link</a>.
    ///</summary>
    string Link { get; set; }

    ///<summary>
    /// Message to pre-fill in the message input field.
    ///</summary>
    string Message { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a>
    /// See <a href="https://corefork.telegram.org/type/MessageEntity" />
    ///</summary>
    TVector<MyTelegram.Schema.IMessageEntity>? Entities { get; set; }

    ///<summary>
    /// Human-readable name of the link, to simplify management in the UI (only visible to the creator of the link).
    ///</summary>
    string? Title { get; set; }

    ///<summary>
    /// Number of times the link was resolved (clicked/scanned/etc...).
    ///</summary>
    int Views { get; set; }
}
