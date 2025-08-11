// ReSharper disable All

namespace MyTelegram.Schema.Account;

///<summary>
/// Info about currently connected <a href="https://corefork.telegram.org/api/business#connected-bots">business bots</a>.
/// See <a href="https://corefork.telegram.org/constructor/account.ConnectedBots" />
///</summary>
[JsonDerivedType(typeof(TConnectedBots), nameof(TConnectedBots))]
public interface IConnectedBots : IObject
{
    ///<summary>
    /// Info about the connected bots
    /// See <a href="https://corefork.telegram.org/type/ConnectedBot" />
    ///</summary>
    TVector<MyTelegram.Schema.IConnectedBot> ConnectedBots { get; set; }

    ///<summary>
    /// Bot information
    /// See <a href="https://corefork.telegram.org/type/User" />
    ///</summary>
    TVector<MyTelegram.Schema.IUser> Users { get; set; }
}
