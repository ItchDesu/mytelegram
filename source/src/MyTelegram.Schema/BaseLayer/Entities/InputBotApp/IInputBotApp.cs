// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Used to fetch information about a <a href="https://corefork.telegram.org/api/bots/webapps#direct-link-mini-apps">direct link Mini App</a>
/// See <a href="https://corefork.telegram.org/constructor/InputBotApp" />
///</summary>
[JsonDerivedType(typeof(TInputBotAppID), nameof(TInputBotAppID))]
[JsonDerivedType(typeof(TInputBotAppShortName), nameof(TInputBotAppShortName))]
public interface IInputBotApp : IObject
{

}
