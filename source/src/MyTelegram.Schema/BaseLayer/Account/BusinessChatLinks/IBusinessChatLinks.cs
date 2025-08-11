// ReSharper disable All

namespace MyTelegram.Schema.Account;

///<summary>
/// Contains info about <a href="https://corefork.telegram.org/api/business#business-chat-links">business chat deep links </a> created by the current account.
/// See <a href="https://corefork.telegram.org/constructor/account.BusinessChatLinks" />
///</summary>
[JsonDerivedType(typeof(TBusinessChatLinks), nameof(TBusinessChatLinks))]
public interface IBusinessChatLinks : IObject
{
    ///<summary>
    /// Links
    /// See <a href="https://corefork.telegram.org/type/BusinessChatLink" />
    ///</summary>
    TVector<MyTelegram.Schema.IBusinessChatLink> Links { get; set; }

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
