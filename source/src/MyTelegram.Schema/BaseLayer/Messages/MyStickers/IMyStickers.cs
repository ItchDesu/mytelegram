// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// The list of <a href="https://corefork.telegram.org/api/stickers">stickersets owned by the current account </a>.
/// See <a href="https://corefork.telegram.org/constructor/messages.MyStickers" />
///</summary>
[JsonDerivedType(typeof(TMyStickers), nameof(TMyStickers))]
public interface IMyStickers : IObject
{
    ///<summary>
    /// Total number of owned stickersets.
    ///</summary>
    int Count { get; set; }

    ///<summary>
    /// Stickersets
    /// See <a href="https://corefork.telegram.org/type/StickerSetCovered" />
    ///</summary>
    TVector<MyTelegram.Schema.IStickerSetCovered> Sets { get; set; }
}
