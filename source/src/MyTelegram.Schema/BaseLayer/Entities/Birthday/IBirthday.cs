// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// <a href="https://corefork.telegram.org/api/profile#birthday">Birthday</a> information for a user.
/// See <a href="https://corefork.telegram.org/constructor/Birthday" />
///</summary>
[JsonDerivedType(typeof(TBirthday), nameof(TBirthday))]
public interface IBirthday : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// Birth day
    ///</summary>
    int Day { get; set; }

    ///<summary>
    /// Birth month
    ///</summary>
    int Month { get; set; }

    ///<summary>
    /// (Optional) birth year.
    ///</summary>
    int? Year { get; set; }
}
