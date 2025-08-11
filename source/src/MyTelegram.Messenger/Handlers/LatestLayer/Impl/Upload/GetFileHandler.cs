// ReSharper disable All

using System;
using System.IO;
using System.Linq;
using MyTelegram.Messenger.Handlers.LatestLayer.Impl.Messages;
using MyTelegram.Schema;

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Upload;

///<summary>
/// Returns content of a whole file or its part.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 CHANNEL_INVALID The provided channel is invalid.
/// 400 CHANNEL_PRIVATE You haven't joined this channel/supergroup.
/// 400 FILE_REFERENCE_* The file reference expired, it <a href="https://corefork.telegram.org/api/file_reference">must be refreshed</a>.
/// 406 FILEREF_UPGRADE_NEEDED The client has to be updated in order to support <a href="https://corefork.telegram.org/api/file_reference">file references</a>.
/// 400 FILE_ID_INVALID The provided file id is invalid.
/// 400 FILE_REFERENCE_EXPIRED File reference expired, it must be refetched as described in <a href="https://corefork.telegram.org/api/file_reference">the documentation</a>.
/// 400 LIMIT_INVALID The provided limit is invalid.
/// 400 LOCATION_INVALID The provided location is invalid.
/// 400 MSG_ID_INVALID Invalid message ID provided.
/// 400 OFFSET_INVALID The provided offset is invalid.
/// 400 PEER_ID_INVALID The provided peer id is invalid.
/// See <a href="https://corefork.telegram.org/method/upload.getFile" />
///</summary>
internal sealed class GetFileHandler :
    RpcResultObjectHandler<MyTelegram.Schema.Upload.RequestGetFile, MyTelegram.Schema.Upload.IFile>,
    Upload.IGetFileHandler
{
    protected override Task<MyTelegram.Schema.Upload.IFile> HandleCoreAsync(
        IRequestInput input,
        MyTelegram.Schema.Upload.RequestGetFile obj)
    {
        if (obj.Location is TInputDocumentFileLocation docLocation)
        {
            // Determine the absolute path to the sticker files. Sticker assets are expected under
            // <base>/downloads/stickersets/bin_vk. The actual path is resolved by StickerData,
            // allowing the directory to be overridden via the MYTELEGRAM_STICKER_DIR environment
            // variable for flexibility during deployment.
            var dir = StickerData.StickerDir;

            var info = StickerData.StickerInfos.FirstOrDefault(x => x.Id == docLocation.Id);
            if (info == null)
            {
                throw new FileNotFoundException("Sticker not found", docLocation.Id.ToString());
            }

            var filePath = Path.Combine(dir, info.File);
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Sticker not found", filePath);
            }

            var fileInfo = new FileInfo(filePath);
            var offset = Math.Max(obj.Offset, 0);
            if (offset > fileInfo.Length)
            {
                offset = fileInfo.Length;
            }

            var remaining = (int)(fileInfo.Length - offset);
            var limit = obj.Limit > 0 ? Math.Min(obj.Limit, remaining) : remaining;
            var buffer = new byte[limit];
            using (var fs = File.OpenRead(filePath))
            {
                fs.Seek(offset, SeekOrigin.Begin);
                fs.Read(buffer, 0, limit);
            }

            var fileType = Path.GetExtension(info.File).Equals(".tgs", StringComparison.OrdinalIgnoreCase)
                ? (MyTelegram.Schema.Storage.IFileType)new MyTelegram.Schema.Storage.TFileUnknown()
                : new MyTelegram.Schema.Storage.TFileWebp();

            var result = new MyTelegram.Schema.Upload.TFile
            {
                Type = fileType,
                Mtime = (int)new DateTimeOffset(fileInfo.LastWriteTimeUtc).ToUnixTimeSeconds(),
                Bytes = buffer
            };

            return Task.FromResult<MyTelegram.Schema.Upload.IFile>(result);
        }

        throw new NotImplementedException();
    }
}