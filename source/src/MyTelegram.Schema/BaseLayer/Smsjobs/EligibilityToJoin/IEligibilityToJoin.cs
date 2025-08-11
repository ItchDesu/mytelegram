// ReSharper disable All

namespace MyTelegram.Schema.Smsjobs;

///<summary>
/// SMS jobs eligibility
/// See <a href="https://corefork.telegram.org/constructor/smsjobs.EligibilityToJoin" />
///</summary>
[JsonDerivedType(typeof(TEligibleToJoin), nameof(TEligibleToJoin))]
public interface IEligibilityToJoin : IObject
{
    ///<summary>
    /// Terms of service URL
    ///</summary>
    string TermsUrl { get; set; }

    ///<summary>
    /// Monthly sent SMSes
    ///</summary>
    int MonthlySentSms { get; set; }
}
