// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Source of an incoming <a href="https://corefork.telegram.org/api/stars">Telegram Star transaction</a>, or its recipient for outgoing <a href="https://corefork.telegram.org/api/stars">Telegram Star transactions</a>.
/// See <a href="https://corefork.telegram.org/constructor/StarsTransactionPeer" />
///</summary>
[JsonDerivedType(typeof(TStarsTransactionPeerUnsupported), nameof(TStarsTransactionPeerUnsupported))]
[JsonDerivedType(typeof(TStarsTransactionPeerAppStore), nameof(TStarsTransactionPeerAppStore))]
[JsonDerivedType(typeof(TStarsTransactionPeerPlayMarket), nameof(TStarsTransactionPeerPlayMarket))]
[JsonDerivedType(typeof(TStarsTransactionPeerPremiumBot), nameof(TStarsTransactionPeerPremiumBot))]
[JsonDerivedType(typeof(TStarsTransactionPeerFragment), nameof(TStarsTransactionPeerFragment))]
[JsonDerivedType(typeof(TStarsTransactionPeer), nameof(TStarsTransactionPeer))]
[JsonDerivedType(typeof(TStarsTransactionPeerAds), nameof(TStarsTransactionPeerAds))]
[JsonDerivedType(typeof(TStarsTransactionPeerAPI), nameof(TStarsTransactionPeerAPI))]
public interface IStarsTransactionPeer : IObject
{

}
