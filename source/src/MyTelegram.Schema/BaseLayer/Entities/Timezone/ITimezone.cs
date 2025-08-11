// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Timezone information.
/// See <a href="https://corefork.telegram.org/constructor/Timezone" />
///</summary>
[JsonDerivedType(typeof(TTimezone), nameof(TTimezone))]
public interface ITimezone : IObject
{
    ///<summary>
    /// Unique timezone ID.
    ///</summary>
    string Id { get; set; }

    ///<summary>
    /// Human-readable and localized timezone name.
    ///</summary>
    string Name { get; set; }

    ///<summary>
    /// UTC offset in seconds, which may be displayed in hh:mm format by the client together with the human-readable name (i.e. <code>$name UTC -01:00</code>).
    ///</summary>
    int UtcOffset { get; set; }
}
