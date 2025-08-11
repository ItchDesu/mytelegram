// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Secure value hash
/// See <a href="https://corefork.telegram.org/constructor/SecureValueHash" />
///</summary>
[JsonDerivedType(typeof(TSecureValueHash), nameof(TSecureValueHash))]
public interface ISecureValueHash : IObject
{
    ///<summary>
    /// Secure value type
    /// See <a href="https://corefork.telegram.org/type/SecureValueType" />
    ///</summary>
    MyTelegram.Schema.ISecureValueType Type { get; set; }

    ///<summary>
    /// Hash
    ///</summary>
    ReadOnlyMemory<byte> Hash { get; set; }
}
