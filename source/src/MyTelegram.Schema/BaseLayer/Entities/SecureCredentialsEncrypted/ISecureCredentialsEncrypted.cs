// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Encrypted secure credentials
/// See <a href="https://corefork.telegram.org/constructor/SecureCredentialsEncrypted" />
///</summary>
[JsonDerivedType(typeof(TSecureCredentialsEncrypted), nameof(TSecureCredentialsEncrypted))]
public interface ISecureCredentialsEncrypted : IObject
{
    ///<summary>
    /// Encrypted JSON-serialized data with unique user's payload, data hashes and secrets required for EncryptedPassportElement decryption and authentication, as described in <a href="https://corefork.telegram.org/passport#decrypting-data">decrypting data </a>
    ///</summary>
    ReadOnlyMemory<byte> Data { get; set; }

    ///<summary>
    /// Data hash for data authentication as described in <a href="https://corefork.telegram.org/passport#decrypting-data">decrypting data </a>
    ///</summary>
    ReadOnlyMemory<byte> Hash { get; set; }

    ///<summary>
    /// Secret, encrypted with the bot's public RSA key, required for data decryption as described in <a href="https://corefork.telegram.org/passport#decrypting-data">decrypting data </a>
    ///</summary>
    ReadOnlyMemory<byte> Secret { get; set; }
}
