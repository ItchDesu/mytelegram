// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// <a href="https://corefork.telegram.org/api/emoji-status">Emoji status</a>
/// See <a href="https://corefork.telegram.org/constructor/EmojiStatus" />
///</summary>
[JsonDerivedType(typeof(TEmojiStatusEmpty), nameof(TEmojiStatusEmpty))]
[JsonDerivedType(typeof(TEmojiStatus), nameof(TEmojiStatus))]
[JsonDerivedType(typeof(TEmojiStatusCollectible), nameof(TEmojiStatusCollectible))]
[JsonDerivedType(typeof(TInputEmojiStatusCollectible), nameof(TInputEmojiStatusCollectible))]
public interface IEmojiStatus : IObject
{

}
