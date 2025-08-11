// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// Represents some <a href="https://corefork.telegram.org/api/saved-messages">saved message dialogs </a>.
/// See <a href="https://corefork.telegram.org/constructor/messages.SavedDialogs" />
///</summary>
[JsonDerivedType(typeof(TSavedDialogs), nameof(TSavedDialogs))]
[JsonDerivedType(typeof(TSavedDialogsSlice), nameof(TSavedDialogsSlice))]
[JsonDerivedType(typeof(TSavedDialogsNotModified), nameof(TSavedDialogsNotModified))]
public interface ISavedDialogs : IObject
{

}
