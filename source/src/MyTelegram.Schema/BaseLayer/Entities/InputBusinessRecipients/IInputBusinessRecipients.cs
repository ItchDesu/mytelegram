// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Specifies the chats that <strong>can</strong> receive Telegram Business <a href="https://corefork.telegram.org/api/business#away-messages">away </a> and <a href="https://corefork.telegram.org/api/business#greeting-messages">greeting </a> messages.If <code>exclude_selected</code> is set, specifies all chats that <strong>cannot</strong> receive Telegram Business <a href="https://corefork.telegram.org/api/business#away-messages">away </a> and <a href="https://corefork.telegram.org/api/business#greeting-messages">greeting </a> messages.
/// See <a href="https://corefork.telegram.org/constructor/InputBusinessRecipients" />
///</summary>
[JsonDerivedType(typeof(TInputBusinessRecipients), nameof(TInputBusinessRecipients))]
public interface IInputBusinessRecipients : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// All existing private chats.
    ///</summary>
    bool ExistingChats { get; set; }

    ///<summary>
    /// All new private chats.
    ///</summary>
    bool NewChats { get; set; }

    ///<summary>
    /// All private chats with contacts.
    ///</summary>
    bool Contacts { get; set; }

    ///<summary>
    /// All private chats with non-contacts.
    ///</summary>
    bool NonContacts { get; set; }

    ///<summary>
    /// If set, inverts the selection.
    ///</summary>
    bool ExcludeSelected { get; set; }

    ///<summary>
    /// Only private chats with the specified users.
    /// See <a href="https://corefork.telegram.org/type/InputUser" />
    ///</summary>
    TVector<MyTelegram.Schema.IInputUser>? Users { get; set; }
}
