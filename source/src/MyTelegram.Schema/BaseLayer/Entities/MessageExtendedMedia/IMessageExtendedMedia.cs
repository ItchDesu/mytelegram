// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// <a href="https://corefork.telegram.org/api/paid-media">Paid media, see here </a> for more info.
/// See <a href="https://corefork.telegram.org/constructor/MessageExtendedMedia" />
///</summary>
[JsonDerivedType(typeof(TMessageExtendedMediaPreview), nameof(TMessageExtendedMediaPreview))]
[JsonDerivedType(typeof(TMessageExtendedMedia), nameof(TMessageExtendedMedia))]
public interface IMessageExtendedMedia : IObject
{

}
