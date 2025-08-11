// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// Full list of usable <a href="https://corefork.telegram.org/api/effects">animated message effects </a>.
/// See <a href="https://corefork.telegram.org/constructor/messages.AvailableEffects" />
///</summary>
[JsonDerivedType(typeof(TAvailableEffectsNotModified), nameof(TAvailableEffectsNotModified))]
[JsonDerivedType(typeof(TAvailableEffects), nameof(TAvailableEffects))]
public interface IAvailableEffects : IObject
{

}
