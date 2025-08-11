// ReSharper disable All

namespace MyTelegram.Schema.Fragment;

///<summary>
/// Info about a <a href="https://corefork.telegram.org/api/fragment">fragment collectible</a>.
/// See <a href="https://corefork.telegram.org/constructor/fragment.CollectibleInfo" />
///</summary>
[JsonDerivedType(typeof(TCollectibleInfo), nameof(TCollectibleInfo))]
public interface ICollectibleInfo : IObject
{
    ///<summary>
    /// Purchase date (unixtime)
    ///</summary>
    int PurchaseDate { get; set; }

    ///<summary>
    /// Three-letter ISO 4217 <a href="https://corefork.telegram.org/bots/payments#supported-currencies">currency</a> code for <code>amount</code>
    ///</summary>
    string Currency { get; set; }

    ///<summary>
    /// Total price in the smallest units of the currency (integer, not float/double). For example, for a price of <code>US$ 1.45</code> pass <code>amount = 145</code>. See the exp parameter in <a href="https://corefork.telegram.org/bots/payments/currencies.json">currencies.json</a>, it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).
    ///</summary>
    long Amount { get; set; }

    ///<summary>
    /// Cryptocurrency name.
    ///</summary>
    string CryptoCurrency { get; set; }

    ///<summary>
    /// Price, in the smallest units of the cryptocurrency.
    ///</summary>
    long CryptoAmount { get; set; }

    ///<summary>
    /// <a href="https://fragment.com/">Fragment</a> URL with more info about the collectible
    ///</summary>
    string Url { get; set; }
}
