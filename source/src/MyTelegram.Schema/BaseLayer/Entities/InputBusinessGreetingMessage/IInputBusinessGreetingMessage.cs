// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Describes a <a href="https://corefork.telegram.org/api/business#greeting-messages">Telegram Business greeting</a>, automatically sent to new users writing to us in private for the first time, or after a certain inactivity period.
/// See <a href="https://corefork.telegram.org/constructor/InputBusinessGreetingMessage" />
///</summary>
[JsonDerivedType(typeof(TInputBusinessGreetingMessage), nameof(TInputBusinessGreetingMessage))]
public interface IInputBusinessGreetingMessage : IObject
{
    ///<summary>
    /// ID of a <a href="https://corefork.telegram.org/api/business#quick-reply-shortcuts">quick reply shorcut, containing the greeting messages to send, see here  for more info</a>.
    ///</summary>
    int ShortcutId { get; set; }

    ///<summary>
    /// Allowed recipients for the greeting messages.
    /// See <a href="https://corefork.telegram.org/type/InputBusinessRecipients" />
    ///</summary>
    MyTelegram.Schema.IInputBusinessRecipients Recipients { get; set; }

    ///<summary>
    /// The number of days after which a private chat will be considered as inactive; currently, must be one of 7, 14, 21, or 28.
    ///</summary>
    int NoActivityDays { get; set; }
}
