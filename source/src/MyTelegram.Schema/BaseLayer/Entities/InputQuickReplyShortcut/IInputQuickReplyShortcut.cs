// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Represents a <a href="https://corefork.telegram.org/api/business#quick-reply-shortcuts">quick reply shortcut </a>.
/// See <a href="https://corefork.telegram.org/constructor/InputQuickReplyShortcut" />
///</summary>
[JsonDerivedType(typeof(TInputQuickReplyShortcut), nameof(TInputQuickReplyShortcut))]
[JsonDerivedType(typeof(TInputQuickReplyShortcutId), nameof(TInputQuickReplyShortcutId))]
public interface IInputQuickReplyShortcut : IObject
{

}
