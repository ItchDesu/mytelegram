// ReSharper disable All

namespace MyTelegram.Schema.Smsjobs;

///<summary>
/// Status
/// See <a href="https://corefork.telegram.org/constructor/smsjobs.Status" />
///</summary>
[JsonDerivedType(typeof(TStatus), nameof(TStatus))]
public interface IStatus : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// Allow international numbers
    ///</summary>
    bool AllowInternational { get; set; }

    ///<summary>
    /// Recently sent
    ///</summary>
    int RecentSent { get; set; }

    ///<summary>
    /// Since
    ///</summary>
    int RecentSince { get; set; }

    ///<summary>
    /// Remaining
    ///</summary>
    int RecentRemains { get; set; }

    ///<summary>
    /// Total sent
    ///</summary>
    int TotalSent { get; set; }

    ///<summary>
    /// Total since
    ///</summary>
    int TotalSince { get; set; }

    ///<summary>
    /// Last gift deep link
    ///</summary>
    string? LastGiftSlug { get; set; }

    ///<summary>
    /// Terms of service URL
    ///</summary>
    string TermsUrl { get; set; }
}
