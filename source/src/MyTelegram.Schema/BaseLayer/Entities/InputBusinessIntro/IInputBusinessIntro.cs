// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// <a href="https://corefork.telegram.org/api/business#business-introduction">Telegram Business introduction </a>.
/// See <a href="https://corefork.telegram.org/constructor/InputBusinessIntro" />
///</summary>
[JsonDerivedType(typeof(TInputBusinessIntro), nameof(TInputBusinessIntro))]
public interface IInputBusinessIntro : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// Title of the introduction message
    ///</summary>
    string Title { get; set; }

    ///<summary>
    /// Profile introduction
    ///</summary>
    string Description { get; set; }

    ///<summary>
    /// Optional introduction <a href="https://corefork.telegram.org/api/stickers">sticker</a>.
    /// See <a href="https://corefork.telegram.org/type/InputDocument" />
    ///</summary>
    MyTelegram.Schema.IInputDocument? Sticker { get; set; }
}
