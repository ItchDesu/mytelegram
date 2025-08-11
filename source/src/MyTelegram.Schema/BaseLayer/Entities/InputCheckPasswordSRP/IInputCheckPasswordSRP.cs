// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Constructors for checking the validity of a <a href="https://corefork.telegram.org/api/srp">2FA SRP password</a>.See <a href="https://corefork.telegram.org/api/srp#using-the-2fa-password">here </a> for more info on the 2FA authentication flow for methods that require it, before and after login.
/// See <a href="https://corefork.telegram.org/constructor/InputCheckPasswordSRP" />
///</summary>
[JsonDerivedType(typeof(TInputCheckPasswordEmpty), nameof(TInputCheckPasswordEmpty))]
[JsonDerivedType(typeof(TInputCheckPasswordSRP), nameof(TInputCheckPasswordSRP))]
public interface IInputCheckPasswordSRP : IObject
{

}
