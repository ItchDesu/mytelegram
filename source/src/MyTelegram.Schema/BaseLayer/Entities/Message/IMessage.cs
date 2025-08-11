// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Object describing a message.
/// See <a href="https://corefork.telegram.org/constructor/Message" />
///</summary>
[JsonDerivedType(typeof(TMessageEmpty), nameof(TMessageEmpty))]
[JsonDerivedType(typeof(TMessage), nameof(TMessage))]
[JsonDerivedType(typeof(TMessageService), nameof(TMessageService))]
public interface IMessage : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// Message ID
    ///</summary>
    int Id { get; set; }
}
