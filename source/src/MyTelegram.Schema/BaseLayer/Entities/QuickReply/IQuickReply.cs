// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// A <a href="https://corefork.telegram.org/api/business#quick-reply-shortcuts">quick reply shortcut</a>.
/// See <a href="https://corefork.telegram.org/constructor/QuickReply" />
///</summary>
[JsonDerivedType(typeof(TQuickReply), nameof(TQuickReply))]
public interface IQuickReply : IObject
{
    ///<summary>
    /// Unique shortcut ID.
    ///</summary>
    int ShortcutId { get; set; }

    ///<summary>
    /// Shortcut name.
    ///</summary>
    string Shortcut { get; set; }

    ///<summary>
    /// ID of the last message in the shortcut.
    ///</summary>
    int TopMessage { get; set; }

    ///<summary>
    /// Total number of messages in the shortcut.
    ///</summary>
    int Count { get; set; }
}
