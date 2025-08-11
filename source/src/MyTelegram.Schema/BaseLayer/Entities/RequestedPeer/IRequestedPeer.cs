// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Info about a peer, shared by a user with the currently logged in bot using <a href="https://corefork.telegram.org/method/messages.sendBotRequestedPeer">messages.sendBotRequestedPeer</a>.
/// See <a href="https://corefork.telegram.org/constructor/RequestedPeer" />
///</summary>
[JsonDerivedType(typeof(TRequestedPeerUser), nameof(TRequestedPeerUser))]
[JsonDerivedType(typeof(TRequestedPeerChat), nameof(TRequestedPeerChat))]
[JsonDerivedType(typeof(TRequestedPeerChannel), nameof(TRequestedPeerChannel))]
public interface IRequestedPeer : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// Channel/supergroup photo.
    /// See <a href="https://corefork.telegram.org/type/Photo" />
    ///</summary>
    MyTelegram.Schema.IPhoto? Photo { get; set; }
}
