// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// A <a href="https://corefork.telegram.org/api/sponsored-messages#reporting-sponsored-messages">report option for a sponsored message </a>.
/// See <a href="https://corefork.telegram.org/constructor/SponsoredMessageReportOption" />
///</summary>
[JsonDerivedType(typeof(TSponsoredMessageReportOption), nameof(TSponsoredMessageReportOption))]
public interface ISponsoredMessageReportOption : IObject
{
    ///<summary>
    /// Localized description of the option.
    ///</summary>
    string Text { get; set; }

    ///<summary>
    /// Option identifier to pass to <a href="https://corefork.telegram.org/method/channels.reportSponsoredMessage">channels.reportSponsoredMessage</a>.
    ///</summary>
    ReadOnlyMemory<byte> Option { get; set; }
}
