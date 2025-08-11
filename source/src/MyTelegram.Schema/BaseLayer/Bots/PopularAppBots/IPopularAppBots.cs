// ReSharper disable All

namespace MyTelegram.Schema.Bots;

///<summary>
/// Popular <a href="https://corefork.telegram.org/api/bots/webapps#main-mini-apps">Main Mini Apps</a>, to be used in the <a href="https://corefork.telegram.org/api/search#apps-tab">apps tab of global search </a>.
/// See <a href="https://corefork.telegram.org/constructor/bots.PopularAppBots" />
///</summary>
[JsonDerivedType(typeof(TPopularAppBots), nameof(TPopularAppBots))]
public interface IPopularAppBots : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// Offset for <a href="https://corefork.telegram.org/api/offsets">pagination</a>.
    ///</summary>
    string? NextOffset { get; set; }

    ///<summary>
    /// The bots associated to each <a href="https://corefork.telegram.org/api/bots/webapps#main-mini-apps">Main Mini App, see here </a> for more info.
    /// See <a href="https://corefork.telegram.org/type/User" />
    ///</summary>
    TVector<MyTelegram.Schema.IUser> Users { get; set; }
}
