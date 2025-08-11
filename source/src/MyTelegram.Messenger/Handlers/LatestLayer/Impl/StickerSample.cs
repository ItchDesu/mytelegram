using System;
using System.IO;
using System.Linq;
using MyTelegram.Messenger.Handlers.LatestLayer.Impl.Messages;
using Schema = MyTelegram.Schema;
using M = MyTelegram.Schema.Messages;

// Alias schema types to avoid ambiguity with similarly named types
using MessagesTStickerSet = MyTelegram.Schema.Messages.TStickerSet;
using SchemaTStickerSet = MyTelegram.Schema.TStickerSet;

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl;

public static class StickerSample
{
    public static Schema.TStickerSet CreateStickerSet()
        => new Schema.TStickerSet
        {
            Id = StickerData.StickerSetId,
            AccessHash = StickerData.StickerSetAccessHash,
            Title = StickerData.StickerSetTitle,
            ShortName = StickerData.StickerSetShortName,
            Count = StickerData.StickerInfos.Count,
            Hash = 0
        };

    public static M.TStickerSet CreateMessagesStickerSet()
    {
        var docs = new TVector<IDocument>();
        foreach (var info in StickerData.StickerInfos)
        {
            docs.Add(CreateDocument(info));
        }

        return new M.TStickerSet
        {
            Set = CreateStickerSet(),
            Packs = new TVector<IStickerPack>(),
            Keywords = new TVector<IStickerKeyword>(),
            Documents = docs
        };

    public static TStickerSetCovered CreateStickerSetCovered()
    {
        var cover = StickerData.StickerInfos.FirstOrDefault();
        return new TStickerSetCovered
        {
            Set = CreateStickerSet(),
            Cover = cover != null ? CreateDocument(cover) : CreateDocument(new StickerData.StickerInfo { Id = 0, File = string.Empty })
        };
    }

    private static TDocument CreateDocument(StickerData.StickerInfo info)
    {
        var filePath = Path.Combine(StickerData.StickerDir, info.File);
        var fi = new FileInfo(filePath);
        var mimeType = Path.GetExtension(info.File).Equals(".tgs", StringComparison.OrdinalIgnoreCase)
            ? "application/x-tgsticker"
            : "image/webp";

        return new TDocument
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
                    Stickerset = new Schema.TInputStickerSetID
                    {
                        Id = StickerData.StickerSetId,
                        AccessHash = StickerData.StickerSetAccessHash
                    },
                    Alt = string.Empty
                },
                new TDocumentAttributeImageSize { W = 512, H = 512 })
        };
    }
}