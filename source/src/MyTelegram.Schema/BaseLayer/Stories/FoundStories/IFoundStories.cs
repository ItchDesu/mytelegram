// ReSharper disable All

namespace MyTelegram.Schema.Stories;

///<summary>
/// Stories found using <a href="https://corefork.telegram.org/api/stories#searching-stories">global story search </a>.
/// See <a href="https://corefork.telegram.org/constructor/stories.FoundStories" />
///</summary>
[JsonDerivedType(typeof(TFoundStories), nameof(TFoundStories))]
public interface IFoundStories : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// Total number of results found for the query.
    ///</summary>
    int Count { get; set; }

    ///<summary>
    /// Matching stories.
    /// See <a href="https://corefork.telegram.org/type/FoundStory" />
    ///</summary>
    TVector<MyTelegram.Schema.IFoundStory> Stories { get; set; }

    ///<summary>
    /// Offset used to fetch the next page, if not set this is the final page.
    ///</summary>
    string? NextOffset { get; set; }

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
}
