// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// Info about <a href="https://corefork.telegram.org/api/business#quick-reply-shortcuts">quick reply shortcuts </a>.
/// See <a href="https://corefork.telegram.org/constructor/messages.QuickReplies" />
///</summary>
[JsonDerivedType(typeof(TQuickReplies), nameof(TQuickReplies))]
[JsonDerivedType(typeof(TQuickRepliesNotModified), nameof(TQuickRepliesNotModified))]
public interface IQuickReplies : IObject
{

}
