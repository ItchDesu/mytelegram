// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// <a href="https://corefork.telegram.org/api/stories">Story</a> view date and reaction information
/// See <a href="https://corefork.telegram.org/constructor/StoryView" />
///</summary>
[JsonDerivedType(typeof(TStoryView), nameof(TStoryView))]
[JsonDerivedType(typeof(TStoryViewPublicForward), nameof(TStoryViewPublicForward))]
[JsonDerivedType(typeof(TStoryViewPublicRepost), nameof(TStoryViewPublicRepost))]
public interface IStoryView : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// Whether we have <a href="https://corefork.telegram.org/api/block">completely blocked</a> this user, including from viewing more of our stories.
    ///</summary>
    bool Blocked { get; set; }

    ///<summary>
    /// Whether we have <a href="https://corefork.telegram.org/api/block">blocked</a> this user from viewing more of our stories.
    ///</summary>
    bool BlockedMyStoriesFrom { get; set; }
}
