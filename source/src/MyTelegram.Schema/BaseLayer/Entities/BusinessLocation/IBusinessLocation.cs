// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Represents the location of a <a href="https://corefork.telegram.org/api/business#location">Telegram Business </a>.
/// See <a href="https://corefork.telegram.org/constructor/BusinessLocation" />
///</summary>
[JsonDerivedType(typeof(TBusinessLocation), nameof(TBusinessLocation))]
public interface IBusinessLocation : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// Geographical coordinates (optional).
    /// See <a href="https://corefork.telegram.org/type/GeoPoint" />
    ///</summary>
    MyTelegram.Schema.IGeoPoint? GeoPoint { get; set; }

    ///<summary>
    /// Textual description of the address (mandatory).
    ///</summary>
    string Address { get; set; }
}
