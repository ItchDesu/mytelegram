// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Represents a message <a href="https://corefork.telegram.org/api/drafts">draft</a>.
/// See <a href="https://corefork.telegram.org/constructor/DraftMessage" />
///</summary>
[JsonDerivedType(typeof(TDraftMessageEmpty), nameof(TDraftMessageEmpty))]
[JsonDerivedType(typeof(TDraftMessage), nameof(TDraftMessage))]
public interface IDraftMessage : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// Media.
    /// See <a href="https://corefork.telegram.org/type/InputMedia" />
    ///</summary>
    MyTelegram.Schema.IInputMedia? Media { get; set; }
}
