// ReSharper disable All

namespace MyTelegram.Schema.Updates;

///<summary>
/// Contains the difference (new messages) between our local channel state and the remote state
/// See <a href="https://corefork.telegram.org/constructor/updates.ChannelDifference" />
///</summary>
[JsonDerivedType(typeof(TChannelDifferenceEmpty), nameof(TChannelDifferenceEmpty))]
[JsonDerivedType(typeof(TChannelDifferenceTooLong), nameof(TChannelDifferenceTooLong))]
[JsonDerivedType(typeof(TChannelDifference), nameof(TChannelDifference))]
public interface IChannelDifference : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// Whether there are more updates to be fetched using getDifference, starting from the provided <code>pts</code>
    ///</summary>
    bool Final { get; set; }

    ///<summary>
    /// Clients are supposed to refetch the channel difference after timeout seconds have elapsed, if the user is <a href="https://corefork.telegram.org/api/updates#subscribing-to-updates-of-channels-supergroups">currently viewing the chat, see here </a> for more info.
    ///</summary>
    int? Timeout { get; set; }
}
