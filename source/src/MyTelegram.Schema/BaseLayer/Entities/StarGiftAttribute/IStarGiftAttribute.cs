// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// See <a href="https://corefork.telegram.org/constructor/StarGiftAttribute" />
///</summary>
[JsonDerivedType(typeof(TStarGiftAttributeModel), nameof(TStarGiftAttributeModel))]
[JsonDerivedType(typeof(TStarGiftAttributePattern), nameof(TStarGiftAttributePattern))]
[JsonDerivedType(typeof(TStarGiftAttributeBackdrop), nameof(TStarGiftAttributeBackdrop))]
[JsonDerivedType(typeof(TStarGiftAttributeOriginalDetails), nameof(TStarGiftAttributeOriginalDetails))]
public interface IStarGiftAttribute : IObject
{

}
