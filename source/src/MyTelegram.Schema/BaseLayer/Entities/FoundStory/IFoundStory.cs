// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// A story found using <a href="https://corefork.telegram.org/api/stories#searching-stories">global story search </a>.
/// See <a href="https://corefork.telegram.org/constructor/FoundStory" />
///</summary>
[JsonDerivedType(typeof(TFoundStory), nameof(TFoundStory))]
public interface IFoundStory : IObject
{
    ///<summary>
    /// The peer that posted the story.
    /// See <a href="https://corefork.telegram.org/type/Peer" />
    ///</summary>
    MyTelegram.Schema.IPeer Peer { get; set; }

    ///<summary>
    /// The story.
    /// See <a href="https://corefork.telegram.org/type/StoryItem" />
    ///</summary>
    MyTelegram.Schema.IStoryItem Story { get; set; }
}
