// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// Contains info about successfully or unsuccessfully <a href="https://corefork.telegram.org/api/invites#direct-invites">invited </a> users.
/// See <a href="https://corefork.telegram.org/constructor/messages.InvitedUsers" />
///</summary>
[JsonDerivedType(typeof(TInvitedUsers), nameof(TInvitedUsers))]
public interface IInvitedUsers : IObject
{
    ///<summary>
    /// List of updates about successfully invited users (and eventually info about the created group)
    /// See <a href="https://corefork.telegram.org/type/Updates" />
    ///</summary>
    MyTelegram.Schema.IUpdates Updates { get; set; }

    ///<summary>
    /// A list of users that could not be invited, along with the reason why they couldn't be invited.
    /// See <a href="https://corefork.telegram.org/type/MissingInvitee" />
    ///</summary>
    TVector<MyTelegram.Schema.IMissingInvitee> MissingInvitees { get; set; }
}
