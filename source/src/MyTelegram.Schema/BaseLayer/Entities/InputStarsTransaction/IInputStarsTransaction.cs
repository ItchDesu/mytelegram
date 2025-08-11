// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Used to fetch info about a <a href="https://corefork.telegram.org/api/stars#balance-and-transaction-history">Telegram Star transaction </a>.
/// See <a href="https://corefork.telegram.org/constructor/InputStarsTransaction" />
///</summary>
[JsonDerivedType(typeof(TInputStarsTransaction), nameof(TInputStarsTransaction))]
public interface IInputStarsTransaction : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// If set, fetches info about the refund transaction for this transaction.
    ///</summary>
    bool Refund { get; set; }

    ///<summary>
    /// Transaction ID.
    ///</summary>
    string Id { get; set; }
}
