// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Address optionally associated to a <a href="https://corefork.telegram.org/constructor/geoPoint">geoPoint</a>.
/// See <a href="https://corefork.telegram.org/constructor/GeoPointAddress" />
///</summary>
[JsonDerivedType(typeof(TGeoPointAddress), nameof(TGeoPointAddress))]
public interface IGeoPointAddress : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// Two-letter ISO 3166-1 alpha-2 country code
    ///</summary>
    string CountryIso2 { get; set; }

    ///<summary>
    /// State
    ///</summary>
    string? State { get; set; }

    ///<summary>
    /// City
    ///</summary>
    string? City { get; set; }

    ///<summary>
    /// Street
    ///</summary>
    string? Street { get; set; }
}
