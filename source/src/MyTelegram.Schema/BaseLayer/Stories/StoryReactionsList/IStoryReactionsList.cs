// ReSharper disable All

namespace MyTelegram.Schema.Stories;

///<summary>
/// List of peers that reacted to a specific <a href="https://corefork.telegram.org/api/stories">story</a>
/// See <a href="https://corefork.telegram.org/constructor/stories.StoryReactionsList" />
///</summary>
[JsonDerivedType(typeof(TStoryReactionsList), nameof(TStoryReactionsList))]
public interface IStoryReactionsList : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// Total number of reactions matching query
    ///</summary>
    int Count { get; set; }

    ///<summary>
    /// List of peers that reacted to or interacted with a specific story
    /// See <a href="https://corefork.telegram.org/type/StoryReaction" />
    ///</summary>
    TVector<MyTelegram.Schema.IStoryReaction> Reactions { get; set; }

    ///<summary>
    /// Mentioned chats
    /// See <a href="https://corefork.telegram.org/type/Chat" />
    ///</summary>
    TVector<MyTelegram.Schema.IChat> Chats { get; set; }

    ///<summary>
    /// Mentioned users
    /// See <a href="https://corefork.telegram.org/type/User" />
    ///</summary>
    TVector<MyTelegram.Schema.IUser> Users { get; set; }

    ///<summary>
    /// If set, indicates the next offset to use to load more results by invoking <a href="https://corefork.telegram.org/method/stories.getStoryReactionsList">stories.getStoryReactionsList</a>.
    ///</summary>
    string? NextOffset { get; set; }
}
