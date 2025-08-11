// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Represents a <a href="https://corefork.telegram.org/api/fragment">Fragment collectible </a>.
/// See <a href="https://corefork.telegram.org/constructor/InputCollectible" />
///</summary>
[JsonDerivedType(typeof(TInputCollectibleUsername), nameof(TInputCollectibleUsername))]
[JsonDerivedType(typeof(TInputCollectiblePhone), nameof(TInputCollectiblePhone))]
public interface IInputCollectible : IObject
{

}
