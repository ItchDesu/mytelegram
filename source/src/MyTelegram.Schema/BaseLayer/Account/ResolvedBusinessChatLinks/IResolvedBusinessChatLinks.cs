// ReSharper disable All

namespace MyTelegram.Schema.Account;

///<summary>
/// Contains info about a single resolved <a href="https://corefork.telegram.org/api/business#business-chat-links">business chat deep link </a>.
/// See <a href="https://corefork.telegram.org/constructor/account.ResolvedBusinessChatLinks" />
///</summary>
[JsonDerivedType(typeof(TResolvedBusinessChatLinks), nameof(TResolvedBusinessChatLinks))]
public interface IResolvedBusinessChatLinks : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// Destination peer
    /// See <a href="https://corefork.telegram.org/type/Peer" />
    ///</summary>
    MyTelegram.Schema.IPeer Peer { get; set; }

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
    /// Mentioned chats
    /// See <a href="https://corefork.telegram.org/type/Chat" />
    ///</summary>
    TVector<MyTelegram.Schema.IChat> Chats { get; set; }

    ///<summary>
    /// Mentioned users
    /// See <a href="https://corefork.telegram.org/type/User" />
    ///</summary>
    TVector<MyTelegram.Schema.IUser> Users { get; set; }
}
