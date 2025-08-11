// ReSharper disable All

namespace MyTelegram.Schema.Channels;

///<summary>
/// Status of the method call used to report a <a href="https://corefork.telegram.org/api/sponsored-messages">sponsored message </a>.
/// See <a href="https://corefork.telegram.org/constructor/channels.SponsoredMessageReportResult" />
///</summary>
[JsonDerivedType(typeof(TSponsoredMessageReportResultChooseOption), nameof(TSponsoredMessageReportResultChooseOption))]
[JsonDerivedType(typeof(TSponsoredMessageReportResultAdsHidden), nameof(TSponsoredMessageReportResultAdsHidden))]
[JsonDerivedType(typeof(TSponsoredMessageReportResultReported), nameof(TSponsoredMessageReportResultReported))]
public interface ISponsoredMessageReportResult : IObject
{

}
