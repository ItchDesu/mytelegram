// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Secure <a href="https://corefork.telegram.org/passport">passport</a> data, for more info <a href="https://corefork.telegram.org/passport/encryption#securedata">see the passport docs </a>
/// See <a href="https://corefork.telegram.org/constructor/SecureData" />
///</summary>
[JsonDerivedType(typeof(TSecureData), nameof(TSecureData))]
public interface ISecureData : IObject
{
    ///<summary>
    /// Data
    ///</summary>
    ReadOnlyMemory<byte> Data { get; set; }

    ///<summary>
    /// Data hash
    ///</summary>
    ReadOnlyMemory<byte> DataHash { get; set; }

    ///<summary>
    /// Secret
    ///</summary>
    ReadOnlyMemory<byte> Secret { get; set; }
}
