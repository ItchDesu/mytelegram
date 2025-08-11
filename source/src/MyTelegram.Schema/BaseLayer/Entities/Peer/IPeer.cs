// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Identifier of a private chat, basic group, group or channel (see <a href="https://corefork.telegram.org/api/peers">here </a> for more info).
/// See <a href="https://corefork.telegram.org/constructor/Peer" />
///</summary>
[JsonDerivedType(typeof(TPeerUser), nameof(TPeerUser))]
[JsonDerivedType(typeof(TPeerChat), nameof(TPeerChat))]
[JsonDerivedType(typeof(TPeerChannel), nameof(TPeerChannel))]
public interface IPeer : IObject
{

}
