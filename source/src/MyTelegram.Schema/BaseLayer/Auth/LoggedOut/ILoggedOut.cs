// ReSharper disable All

namespace MyTelegram.Schema.Auth;

///<summary>
/// <a href="https://corefork.telegram.org/api/auth#future-auth-tokens">Future auth token </a> to be used on subsequent authorizations
/// See <a href="https://corefork.telegram.org/constructor/auth.LoggedOut" />
///</summary>
[JsonDerivedType(typeof(TLoggedOut), nameof(TLoggedOut))]
public interface ILoggedOut : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/auth#future-auth-tokens">Future auth token </a> to be used on subsequent authorizations
    ///</summary>
    ReadOnlyMemory<byte>? FutureAuthToken { get; set; }
}
