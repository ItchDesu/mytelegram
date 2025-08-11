// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Specifies the chats that <strong>can</strong> receive Telegram Business <a href="https://corefork.telegram.org/api/business#away-messages">away </a> and <a href="https://corefork.telegram.org/api/business#greeting-messages">greeting </a> messages.
/// See <a href="https://corefork.telegram.org/constructor/BusinessRecipients" />
///</summary>
[JsonDerivedType(typeof(TBusinessRecipients), nameof(TBusinessRecipients))]
public interface IBusinessRecipients : IObject
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
    ///</summary>
    TVector<long>? Users { get; set; }
}
