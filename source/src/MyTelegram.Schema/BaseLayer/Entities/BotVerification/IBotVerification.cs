// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// See <a href="https://corefork.telegram.org/constructor/BotVerification" />
///</summary>
[JsonDerivedType(typeof(TBotVerification), nameof(TBotVerification))]
public interface IBotVerification : IObject
{
    long BotId { get; set; }
    long Icon { get; set; }
    string Description { get; set; }
}
