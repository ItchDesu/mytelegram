// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Represents a <a href="https://corefork.telegram.org/api/bots/webapps#main-mini-app-previews">Main Mini App preview media, see here </a> for more info.
/// See <a href="https://corefork.telegram.org/constructor/BotPreviewMedia" />
///</summary>
[JsonDerivedType(typeof(TBotPreviewMedia), nameof(TBotPreviewMedia))]
public interface IBotPreviewMedia : IObject
{
    ///<summary>
    /// When was this media last updated.
    ///</summary>
    int Date { get; set; }

    ///<summary>
    /// The actual photo/video.
    /// See <a href="https://corefork.telegram.org/type/MessageMedia" />
    ///</summary>
    MyTelegram.Schema.IMessageMedia Media { get; set; }
}
