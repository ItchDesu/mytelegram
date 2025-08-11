// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// Contains information about a <a href="https://corefork.telegram.org/api/bots/webapps#direct-link-mini-apps">direct link Mini App</a>
/// See <a href="https://corefork.telegram.org/constructor/messages.BotApp" />
///</summary>
[JsonDerivedType(typeof(TBotApp), nameof(TBotApp))]
public interface IBotApp : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// Whether the web app was never used by the user, and confirmation must be asked from the user before opening it.
    ///</summary>
    bool Inactive { get; set; }

    ///<summary>
    /// The bot is asking permission to send messages to the user: if the user agrees, set the <code>write_allowed</code> flag when invoking <a href="https://corefork.telegram.org/method/messages.requestAppWebView">messages.requestAppWebView</a>.
    ///</summary>
    bool RequestWriteAccess { get; set; }

    ///<summary>
    /// Deprecated flag, can be ignored.
    ///</summary>
    bool HasSettings { get; set; }

    ///<summary>
    /// Bot app information
    /// See <a href="https://corefork.telegram.org/type/BotApp" />
    ///</summary>
    MyTelegram.Schema.IBotApp App { get; set; }
}
