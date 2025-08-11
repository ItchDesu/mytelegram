// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// List of <a href="https://corefork.telegram.org/api/saved-messages#tags">reaction tag </a> names assigned by the user.
/// See <a href="https://corefork.telegram.org/constructor/messages.SavedReactionTags" />
///</summary>
[JsonDerivedType(typeof(TSavedReactionTagsNotModified), nameof(TSavedReactionTagsNotModified))]
[JsonDerivedType(typeof(TSavedReactionTags), nameof(TSavedReactionTags))]
public interface ISavedReactionTags : IObject
{

}
