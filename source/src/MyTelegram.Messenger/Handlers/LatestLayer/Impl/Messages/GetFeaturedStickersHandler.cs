using System;
using System.IO;
using System.Linq;
using MyTelegram.Schema;

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Messages;

///<summary>
/// Get featured stickers
/// See <a href="https://corefork.telegram.org/method/messages.getFeaturedStickers" />
///</summary>
internal sealed class GetFeaturedStickersHandler :
    RpcResultObjectHandler<MyTelegram.Schema.Messages.RequestGetFeaturedStickers, MyTelegram.Schema.Messages.IFeaturedStickers>,
    Messages.IGetFeaturedStickersHandler
{
    protected override Task<MyTelegram.Schema.Messages.IFeaturedStickers> HandleCoreAsync(
        IRequestInput input,
        MyTelegram.Schema.Messages.RequestGetFeaturedStickers obj)
    {
        // Resolve sticker directory via StickerData to allow custom locations using the
        // MYTELEGRAM_STICKER_DIR environment variable.
        var dir = StickerData.StickerDir;

        IDocument cover;
        var first = StickerData.StickerInfos.FirstOrDefault();
        if (first != null)
        {
            var filePath = Path.Combine(dir, first.File);
            var fi = new FileInfo(filePath);
            var mimeType = Path.GetExtension(first.File).Equals(".tgs", StringComparison.OrdinalIgnoreCase)
                ? "application/x-tgsticker"
                : "image/webp";

            cover = new TDocument
            {
                Id = first.Id,
                AccessHash = 0,
                FileReference = ReadOnlyMemory<byte>.Empty,
                Date = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                MimeType = mimeType,
                Size = fi.Exists ? fi.Length : 0,
                DcId = 0,
                Attributes = new TVector<IDocumentAttribute>(
                    new TDocumentAttributeSticker
                    {
                        Stickerset = new TInputStickerSetID
                        {
                            Id = StickerData.StickerSetId,
                            AccessHash = StickerData.StickerSetAccessHash
                        },
                        Alt = string.Empty
                    },
                    new TDocumentAttributeImageSize { W = 512, H = 512 })
            };
        }
        else
        {
            cover = new TDocumentEmpty { Id = 0 };
        }

        var set = new MyTelegram.Schema.TStickerSet
        {
            Id = StickerData.StickerSetId,
            AccessHash = StickerData.StickerSetAccessHash,
            Title = StickerData.StickerSetTitle,
            ShortName = StickerData.StickerSetShortName,
            Count = StickerData.DefaultStickerIds.Count,
            Hash = 0
        };

        var covered = new MyTelegram.Schema.TStickerSetCovered { Set = set, Cover = cover };

        return Task.FromResult<MyTelegram.Schema.Messages.IFeaturedStickers>(new TFeaturedStickers
        {
            Hash = 0,
            Count = 1,
            Sets = new TVector<MyTelegram.Schema.IStickerSetCovered>(covered),
            Unread = new TVector<long>()
        });
    }
}