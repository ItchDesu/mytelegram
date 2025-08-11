using System;
using System.IO;
using System.Linq;
using MyTelegram.Schema;

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Messages;

///<summary>
/// Get info about a stickerset
/// <para>Possible errors</para>
/// Code Type Description
/// 400 EMOTICON_STICKERPACK_MISSING inputStickerSetDice.emoji cannot be empty.
/// 406 STICKERSET_INVALID The provided sticker set is invalid.
/// See <a href="https://corefork.telegram.org/method/messages.getStickerSet" />
///</summary>
internal sealed class GetStickerSetHandler : RpcResultObjectHandler<MyTelegram.Schema.Messages.RequestGetStickerSet, MyTelegram.Schema.Messages.IStickerSet>,
    Messages.IGetStickerSetHandler
{
    protected override Task<MyTelegram.Schema.Messages.IStickerSet> HandleCoreAsync(
        IRequestInput input,
        MyTelegram.Schema.Messages.RequestGetStickerSet obj)
    {
        // Build sticker documents based on metadata loaded by StickerData. StickerData resolves
        // the sticker directory and allows overriding it via the MYTELEGRAM_STICKER_DIR
        // environment variable.
        var dir = StickerData.StickerDir;

        var documents = new TVector<IDocument>();
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
            documents.Add(doc);
        }

        var set = new MyTelegram.Schema.TStickerSet
        {
            Id = StickerData.StickerSetId,
            AccessHash = StickerData.StickerSetAccessHash,
            Title = StickerData.StickerSetTitle,
            ShortName = StickerData.StickerSetShortName,
            Count = documents.Count,
            Hash = 0
        };

        var result = new MyTelegram.Schema.Messages.TStickerSet
        {
            Set = set,
            Packs = new TVector<IStickerPack>(),
            Keywords = new TVector<IStickerKeyword>(),
            Documents = documents
        };

        return Task.FromResult<MyTelegram.Schema.Messages.IStickerSet>(result);
    }
}