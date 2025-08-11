// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Contains info about a <a href="https://corefork.telegram.org/api/business#connected-bots">bot business connection</a>.
/// See <a href="https://corefork.telegram.org/constructor/BotBusinessConnection" />
///</summary>
[JsonDerivedType(typeof(TBotBusinessConnection), nameof(TBotBusinessConnection))]
public interface IBotBusinessConnection : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// Whether this business connection is currently disabled
    ///</summary>
    bool Disabled { get; set; }

    ///<summary>
    /// Business connection ID, used to identify messages coming from the connection and to reply to them as specified <a href="https://corefork.telegram.org/api/business#connected-bots">here </a>.
    ///</summary>
    string ConnectionId { get; set; }

    ///<summary>
    /// ID of the user that the bot is connected to via this connection.
    ///</summary>
    long UserId { get; set; }

    ///<summary>
    /// ID of the datacenter where to send queries wrapped in a <a href="https://corefork.telegram.org/method/invokeWithBusinessConnection">invokeWithBusinessConnection</a> as specified <a href="https://corefork.telegram.org/api/business#connected-bots">here </a>.
    ///</summary>
    int DcId { get; set; }

    ///<summary>
    /// When was the connection created.
    ///</summary>
    int Date { get; set; }
    MyTelegram.Schema.IBusinessBotRights? Rights { get; set; }
}
