// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// See <a href="https://corefork.telegram.org/constructor/InputSavedStarGift" />
///</summary>
[JsonDerivedType(typeof(TInputSavedStarGiftUser), nameof(TInputSavedStarGiftUser))]
[JsonDerivedType(typeof(TInputSavedStarGiftChat), nameof(TInputSavedStarGiftChat))]
[JsonDerivedType(typeof(TInputSavedStarGiftSlug), nameof(TInputSavedStarGiftSlug))]
public interface IInputSavedStarGift : IObject
{

}
