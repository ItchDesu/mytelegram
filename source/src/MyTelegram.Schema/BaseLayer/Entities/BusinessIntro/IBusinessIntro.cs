// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// <a href="https://corefork.telegram.org/api/business#business-introduction">Telegram Business introduction </a>.
/// See <a href="https://corefork.telegram.org/constructor/BusinessIntro" />
///</summary>
[JsonDerivedType(typeof(TBusinessIntro), nameof(TBusinessIntro))]
public interface IBusinessIntro : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// Title of the introduction message (max <a href="https://corefork.telegram.org/api/config#intro-title-length-limit">intro_title_length_limit </a> UTF-8 characters).
    ///</summary>
    string Title { get; set; }

    ///<summary>
    /// Profile introduction (max <a href="https://corefork.telegram.org/api/config#intro-description-length-limit">intro_description_length_limit </a> UTF-8 characters).
    ///</summary>
    string Description { get; set; }

    ///<summary>
    /// Optional introduction <a href="https://corefork.telegram.org/api/stickers">sticker</a>.
    /// See <a href="https://corefork.telegram.org/type/Document" />
    ///</summary>
    MyTelegram.Schema.IDocument? Sticker { get; set; }
}
