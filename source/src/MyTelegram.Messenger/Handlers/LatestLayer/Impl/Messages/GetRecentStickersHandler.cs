using System;
using System.IO;
using System.Linq;
using MyTelegram.Schema;

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Messages;

///<summary>
/// Get recent stickers
/// See <a href="https://corefork.telegram.org/method/messages.getRecentStickers" />
///</summary>
internal sealed class GetRecentStickersHandler :
    RpcResultObjectHandler<MyTelegram.Schema.Messages.RequestGetRecentStickers, MyTelegram.Schema.Messages.IRecentStickers>,
    Messages.IGetRecentStickersHandler
{
    protected override Task<MyTelegram.Schema.Messages.IRecentStickers> HandleCoreAsync(
        IRequestInput input,
        MyTelegram.Schema.Messages.RequestGetRecentStickers obj)
    {
        // Sticker files are resolved via StickerData to support overriding the base directory
        // using the MYTELEGRAM_STICKER_DIR environment variable.
        var dir = StickerData.StickerDir;

        var docs = new TVector<IDocument>();
        foreach (var info in StickerData.StickerInfos)
        {
            var filePath = Path.Combine(dir, info.File);
            var fi = new FileInfo(filePath);
            var mimeType = Path.GetExtension(info.File).Equals(".tgs", StringComparison.OrdinalIgnoreCase)
                ? "application/x-tgsticker"
                : "image/webp";

            var doc = new TDocument
            {
                Id = info.Id,
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
            docs.Add(doc);
        }

        return Task.FromResult<MyTelegram.Schema.Messages.IRecentStickers>(new TRecentStickers
        {
            Dates = new TVector<int>(),
            Packs = new TVector<IStickerPack>(),
            Stickers = docs
        });
    }
}