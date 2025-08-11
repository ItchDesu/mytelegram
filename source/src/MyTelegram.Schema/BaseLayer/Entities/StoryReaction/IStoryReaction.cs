// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// How a certain peer reacted to or interacted with a story
/// See <a href="https://corefork.telegram.org/constructor/StoryReaction" />
///</summary>
[JsonDerivedType(typeof(TStoryReaction), nameof(TStoryReaction))]
[JsonDerivedType(typeof(TStoryReactionPublicForward), nameof(TStoryReactionPublicForward))]
[JsonDerivedType(typeof(TStoryReactionPublicRepost), nameof(TStoryReactionPublicRepost))]
public interface IStoryReaction : IObject
{

}
