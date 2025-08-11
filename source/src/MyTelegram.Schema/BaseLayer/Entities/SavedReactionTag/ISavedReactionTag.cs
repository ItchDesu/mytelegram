// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Info about a <a href="https://corefork.telegram.org/api/saved-messages#tags">saved message reaction tag </a>.
/// See <a href="https://corefork.telegram.org/constructor/SavedReactionTag" />
///</summary>
[JsonDerivedType(typeof(TSavedReactionTag), nameof(TSavedReactionTag))]
public interface ISavedReactionTag : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/reactions">Reaction</a> associated to the tag.
    /// See <a href="https://corefork.telegram.org/type/Reaction" />
    ///</summary>
    MyTelegram.Schema.IReaction Reaction { get; set; }

    ///<summary>
    /// Custom tag name assigned by the user (max 12 UTF-8 chars).
    ///</summary>
    string? Title { get; set; }

    ///<summary>
    /// Number of messages tagged with this tag.
    ///</summary>
    int Count { get; set; }
}
