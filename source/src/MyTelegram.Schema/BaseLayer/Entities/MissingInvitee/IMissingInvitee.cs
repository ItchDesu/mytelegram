// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Info about why a specific user could not be <a href="https://corefork.telegram.org/api/invites#direct-invites">invited </a>.
/// See <a href="https://corefork.telegram.org/constructor/MissingInvitee" />
///</summary>
[JsonDerivedType(typeof(TMissingInvitee), nameof(TMissingInvitee))]
public interface IMissingInvitee : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// If set, we could not add the user <em>only because</em> the current account needs to purchase a <a href="https://corefork.telegram.org/api/premium">Telegram Premium</a> subscription to complete the operation.
    ///</summary>
    bool PremiumWouldAllowInvite { get; set; }

    ///<summary>
    /// If set, we could not add the user because of their privacy settings, and additionally, the current account needs to purchase a <a href="https://corefork.telegram.org/api/premium">Telegram Premium</a> subscription to directly share an invite link with the user via a private message.
    ///</summary>
    bool PremiumRequiredForPm { get; set; }

    ///<summary>
    /// ID of the user. If neither of the flags below are set, we could not add the user because of their privacy settings, and we can create and directly share an <a href="https://corefork.telegram.org/api/invites#invite-links">invite link</a> with them using a normal message, instead.
    ///</summary>
    long UserId { get; set; }
}
