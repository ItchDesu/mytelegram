// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// <a href="https://corefork.telegram.org/api/folders">Folder</a> information
/// See <a href="https://corefork.telegram.org/constructor/messages.DialogFilters" />
///</summary>
[JsonDerivedType(typeof(TDialogFilters), nameof(TDialogFilters))]
public interface IDialogFilters : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// Whether <a href="https://corefork.telegram.org/api/folders#folder-tags">folder tags</a> are enabled.
    ///</summary>
    bool TagsEnabled { get; set; }

    ///<summary>
    /// Folders.
    /// See <a href="https://corefork.telegram.org/type/DialogFilter" />
    ///</summary>
    TVector<MyTelegram.Schema.IDialogFilter> Filters { get; set; }
}
