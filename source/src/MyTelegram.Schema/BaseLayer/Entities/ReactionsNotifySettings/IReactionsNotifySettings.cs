// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Reaction notification settings, see <a href="https://corefork.telegram.org/api/reactions#notifications-about-reactions">here </a> for more info.
/// See <a href="https://corefork.telegram.org/constructor/ReactionsNotifySettings" />
///</summary>
[JsonDerivedType(typeof(TReactionsNotifySettings), nameof(TReactionsNotifySettings))]
public interface IReactionsNotifySettings : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// Message reaction notification settings, if not set completely disables notifications/updates about message reactions.
    /// See <a href="https://corefork.telegram.org/type/ReactionNotificationsFrom" />
    ///</summary>
    MyTelegram.Schema.IReactionNotificationsFrom? MessagesNotifyFrom { get; set; }

    ///<summary>
    /// Story reaction notification settings, if not set completely disables notifications/updates about reactions to stories.
    /// See <a href="https://corefork.telegram.org/type/ReactionNotificationsFrom" />
    ///</summary>
    MyTelegram.Schema.IReactionNotificationsFrom? StoriesNotifyFrom { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/ringtones">Notification sound for reactions </a>
    /// See <a href="https://corefork.telegram.org/type/NotificationSound" />
    ///</summary>
    MyTelegram.Schema.INotificationSound Sound { get; set; }

    ///<summary>
    /// If false, <a href="https://corefork.telegram.org/api/push-updates">push notifications </a> about message/story reactions will only be of type <code>REACT_HIDDEN</code>/<code>REACT_STORY_HIDDEN</code>, without any information about the reacted-to story or the reaction itself.
    /// See <a href="https://corefork.telegram.org/type/Bool" />
    ///</summary>
    bool ShowPreviews { get; set; }
}
