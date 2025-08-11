// ReSharper disable All

namespace MyTelegram.Schema.Auth;

///<summary>
/// Contains info on a confirmation code message sent via SMS, phone call or Telegram.
/// See <a href="https://corefork.telegram.org/constructor/auth.SentCode" />
///</summary>
[JsonDerivedType(typeof(TSentCode), nameof(TSentCode))]
[JsonDerivedType(typeof(TSentCodeSuccess), nameof(TSentCodeSuccess))]
[JsonDerivedType(typeof(TSentCodePaymentRequired), nameof(TSentCodePaymentRequired))]
[JsonDerivedType(typeof(MyTelegram.Schema.Auth.LayerN.TSentCode), "TSentCodeLayerN")]
public interface ISentCode : IObject
{

}
