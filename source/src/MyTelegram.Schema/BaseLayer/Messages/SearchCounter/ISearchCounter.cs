// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// Number of results that would be returned by a search
/// See <a href="https://corefork.telegram.org/constructor/messages.SearchCounter" />
///</summary>
[JsonDerivedType(typeof(TSearchCounter), nameof(TSearchCounter))]
public interface ISearchCounter : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// If set, the results may be inexact
    ///</summary>
    bool Inexact { get; set; }

    ///<summary>
    /// Provided message filter
    /// See <a href="https://corefork.telegram.org/type/MessagesFilter" />
    ///</summary>
    MyTelegram.Schema.IMessagesFilter Filter { get; set; }

    ///<summary>
    /// Number of results that were found server-side
    ///</summary>
    int Count { get; set; }
}
