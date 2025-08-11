using System;
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
            Id = 1,
            AccessHash = 0,
            Title = "Bin",
            ShortName = "bin_vk",
            Count = 0,
            Hash = 0
        };

    public static M.TStickerSet CreateMessagesStickerSet()
        => new M.TStickerSet
        {
            Set = CreateStickerSet(),
            Packs = new TVector<IStickerPack>(),
            Keywords = new TVector<IStickerKeyword>(),
            Documents = new TVector<IDocument>()
        };

    public static TStickerSetCovered CreateStickerSetCovered()
        => new TStickerSetCovered
        {
            Set = CreateStickerSet(),
            Cover = CreateDocument()
        };

    public static TDocument CreateDocument()
        => new TDocument
        {
            Id = 1,
            AccessHash = 0,
            FileReference = ReadOnlyMemory<byte>.Empty,
            Date = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
            MimeType = "image/webp",
            Size = 0,
            DcId = 0,
            Attributes = new TVector<IDocumentAttribute>()
        };
}