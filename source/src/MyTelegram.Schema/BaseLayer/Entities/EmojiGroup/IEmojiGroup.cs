// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Represents an <a href="https://corefork.telegram.org/api/emoji-categories">emoji category</a>.
/// See <a href="https://corefork.telegram.org/constructor/EmojiGroup" />
///</summary>
[JsonDerivedType(typeof(TEmojiGroup), nameof(TEmojiGroup))]
[JsonDerivedType(typeof(TEmojiGroupGreeting), nameof(TEmojiGroupGreeting))]
[JsonDerivedType(typeof(TEmojiGroupPremium), nameof(TEmojiGroupPremium))]
public interface IEmojiGroup : IObject
{
    ///<summary>
    /// Category name, i.e. "Animals", "Flags", "Faces" and so on...
    ///</summary>
    string Title { get; set; }

    ///<summary>
    /// A single custom emoji used as preview for the category.
    ///</summary>
    long IconEmojiId { get; set; }
}
