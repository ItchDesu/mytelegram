// ReSharper disable All

namespace MyTelegram.Schema.Bots;

///<summary>
/// Contains info about <a href="https://corefork.telegram.org/api/bots/webapps#main-mini-app-previews">Main Mini App previews, see here </a> for more info.
/// See <a href="https://corefork.telegram.org/constructor/bots.PreviewInfo" />
///</summary>
[JsonDerivedType(typeof(TPreviewInfo), nameof(TPreviewInfo))]
public interface IPreviewInfo : IObject
{
    ///<summary>
    /// All preview medias for the language code passed to <a href="https://corefork.telegram.org/method/bots.getPreviewInfo">bots.getPreviewInfo</a>.
    /// See <a href="https://corefork.telegram.org/type/BotPreviewMedia" />
    ///</summary>
    TVector<MyTelegram.Schema.IBotPreviewMedia> Media { get; set; }

    ///<summary>
    /// All available language codes for which preview medias were uploaded (regardless of the language code passed to <a href="https://corefork.telegram.org/method/bots.getPreviewInfo">bots.getPreviewInfo</a>).
    ///</summary>
    TVector<string> LangCodes { get; set; }
}
