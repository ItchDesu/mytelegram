// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// A set of <a href="https://core.telegram.org/api/sponsored-messages">sponsored messages</a> associated with a channel
/// See <a href="https://corefork.telegram.org/constructor/messages.SponsoredMessages" />
///</summary>
[JsonDerivedType(typeof(TSponsoredMessages), nameof(TSponsoredMessages))]
[JsonDerivedType(typeof(TSponsoredMessagesEmpty), nameof(TSponsoredMessagesEmpty))]
public interface ISponsoredMessages : IObject
{

}
