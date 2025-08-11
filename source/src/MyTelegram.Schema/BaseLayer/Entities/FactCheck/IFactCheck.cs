// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Represents a <a href="https://corefork.telegram.org/api/factcheck">fact-check </a> created by an independent fact-checker.
/// See <a href="https://corefork.telegram.org/constructor/FactCheck" />
///</summary>
[JsonDerivedType(typeof(TFactCheck), nameof(TFactCheck))]
public interface IFactCheck : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// If set, the <code>country</code>/<code>text</code> fields will <strong>not</strong> be set, and the fact check must be fetched manually by the client (if it isn't already cached with the key specified in <code>hash</code>) using bundled <a href="https://corefork.telegram.org/method/messages.getFactCheck">messages.getFactCheck</a> requests, when the message with the factcheck scrolls into view.
    ///</summary>
    bool NeedCheck { get; set; }

    ///<summary>
    /// A two-letter ISO 3166-1 alpha-2 country code of the country for which the fact-check should be shown.
    ///</summary>
    string? Country { get; set; }

    ///<summary>
    /// The fact-check.
    /// See <a href="https://corefork.telegram.org/type/TextWithEntities" />
    ///</summary>
    MyTelegram.Schema.ITextWithEntities? Text { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>
    ///</summary>
    long Hash { get; set; }
}
