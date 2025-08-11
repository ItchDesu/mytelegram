// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Specifies the private chats that a <a href="https://corefork.telegram.org/api/business#connected-bots">connected business bot </a> may receive messages and interact with.
/// See <a href="https://corefork.telegram.org/constructor/BusinessBotRecipients" />
///</summary>
[JsonDerivedType(typeof(TBusinessBotRecipients), nameof(TBusinessBotRecipients))]
public interface IBusinessBotRecipients : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// Selects all existing private chats.
    ///</summary>
    bool ExistingChats { get; set; }

    ///<summary>
    /// Selects all new private chats.
    ///</summary>
    bool NewChats { get; set; }

    ///<summary>
    /// Selects all private chats with contacts.
    ///</summary>
    bool Contacts { get; set; }

    ///<summary>
    /// Selects all private chats with non-contacts.
    ///</summary>
    bool NonContacts { get; set; }

    ///<summary>
    /// If set, then all private chats <em>except</em> the ones selected by <code>existing_chats</code>, <code>new_chats</code>, <code>contacts</code>, <code>non_contacts</code> and <code>users</code> are chosen. <br>Note that if this flag is set, any values passed in <code>exclude_users</code> will be merged and moved into <code>users</code> by the server, thus <code>exclude_users</code> will always be empty.
    ///</summary>
    bool ExcludeSelected { get; set; }

    ///<summary>
    /// Explicitly selected private chats.
    ///</summary>
    TVector<long>? Users { get; set; }

    ///<summary>
    /// Identifiers of private chats that are always excluded.
    ///</summary>
    TVector<long>? ExcludeUsers { get; set; }
}
