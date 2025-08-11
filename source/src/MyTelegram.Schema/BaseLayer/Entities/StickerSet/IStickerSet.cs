// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Represents a stickerset (stickerpack)
/// See <a href="https://corefork.telegram.org/constructor/StickerSet" />
///</summary>
[JsonDerivedType(typeof(TStickerSet), nameof(TStickerSet))]
public interface IStickerSet : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// Whether this stickerset was archived (due to too many saved stickers in the current account)
    ///</summary>
    bool Archived { get; set; }

    ///<summary>
    /// Is this stickerset official
    ///</summary>
    bool Official { get; set; }

    ///<summary>
    /// Is this a mask stickerset
    ///</summary>
    bool Masks { get; set; }

    ///<summary>
    /// This is a custom emoji stickerset
    ///</summary>
    bool Emojis { get; set; }

    ///<summary>
    /// Whether the color of this TGS custom emoji stickerset should be changed to the text color when used in messages, the accent color if used as emoji status, white on chat photos, or another appropriate color based on context.
    ///</summary>
    bool TextColor { get; set; }

    ///<summary>
    /// If set, this custom emoji stickerset can be used in <a href="https://corefork.telegram.org/api/emoji-status">channel/supergroup emoji statuses</a>.
    ///</summary>
    bool ChannelEmojiStatus { get; set; }

    ///<summary>
    /// Whether we created this stickerset
    ///</summary>
    bool Creator { get; set; }

    ///<summary>
    /// When was this stickerset installed
    ///</summary>
    int? InstalledDate { get; set; }

    ///<summary>
    /// ID of the stickerset
    ///</summary>
    long Id { get; set; }

    ///<summary>
    /// Access hash of stickerset
    ///</summary>
    long AccessHash { get; set; }

    ///<summary>
    /// Title of stickerset
    ///</summary>
    string Title { get; set; }

    ///<summary>
    /// Short name of stickerset, used when sharing stickerset using <a href="https://corefork.telegram.org/api/links#stickerset-links">stickerset deep links</a>.
    ///</summary>
    string ShortName { get; set; }

    ///<summary>
    /// Stickerset thumbnail
    /// See <a href="https://corefork.telegram.org/type/PhotoSize" />
    ///</summary>
    TVector<MyTelegram.Schema.IPhotoSize>? Thumbs { get; set; }

    ///<summary>
    /// DC ID of thumbnail
    ///</summary>
    int? ThumbDcId { get; set; }

    ///<summary>
    /// Thumbnail version
    ///</summary>
    int? ThumbVersion { get; set; }

    ///<summary>
    /// Document ID of custom emoji thumbnail, fetch the document using <a href="https://corefork.telegram.org/method/messages.getCustomEmojiDocuments">messages.getCustomEmojiDocuments</a>
    ///</summary>
    long? ThumbDocumentId { get; set; }

    ///<summary>
    /// Number of stickers in pack
    ///</summary>
    int Count { get; set; }

    ///<summary>
    /// Hash
    ///</summary>
    int Hash { get; set; }
}
