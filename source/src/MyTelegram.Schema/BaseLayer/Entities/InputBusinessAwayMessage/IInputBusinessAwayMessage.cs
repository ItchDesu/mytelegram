// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Describes a <a href="https://corefork.telegram.org/api/business#away-messages">Telegram Business away message</a>, automatically sent to users writing to us when we're offline, during closing hours, while we're on vacation, or in some other custom time period when we cannot immediately answer to the user.
/// See <a href="https://corefork.telegram.org/constructor/InputBusinessAwayMessage" />
///</summary>
[JsonDerivedType(typeof(TInputBusinessAwayMessage), nameof(TInputBusinessAwayMessage))]
public interface IInputBusinessAwayMessage : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// If set, the messages will not be sent if the account was online in the last 10 minutes.
    ///</summary>
    bool OfflineOnly { get; set; }

    ///<summary>
    /// ID of a <a href="https://corefork.telegram.org/api/business#quick-reply-shortcuts">quick reply shorcut, containing the away messages to send, see here  for more info</a>.
    ///</summary>
    int ShortcutId { get; set; }

    ///<summary>
    /// Specifies when should the away messages be sent.
    /// See <a href="https://corefork.telegram.org/type/BusinessAwayMessageSchedule" />
    ///</summary>
    MyTelegram.Schema.IBusinessAwayMessageSchedule Schedule { get; set; }

    ///<summary>
    /// Allowed recipients for the away messages.
    /// See <a href="https://corefork.telegram.org/type/InputBusinessRecipients" />
    ///</summary>
    MyTelegram.Schema.IInputBusinessRecipients Recipients { get; set; }
}
