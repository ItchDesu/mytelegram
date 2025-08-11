using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using STJ = System.Text.Json;
using System.Text.Json.Serialization;

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Messages;

internal static class StickerData
{
    public static IReadOnlyList<StickerInfo> StickerInfos { get; }
    public static IReadOnlyList<long> DefaultStickerIds { get; }

    // Absolute path to the directory containing sticker assets.
    public static string StickerDir { get; }

    public static long StickerSetId { get; }
    public static long StickerSetAccessHash { get; }
    public static string StickerSetTitle { get; }
    public static string StickerSetShortName { get; }

    static StickerData()
    {
        try
        {
            StickerDir = GetStickerDirectory();
            if (Directory.Exists(StickerDir))
            {
                var data = LoadStickerInfo(StickerDir);
                StickerInfos = data.Stickers ?? new List<StickerInfo>();
                DefaultStickerIds = StickerInfos.Select(x => x.Id).ToList();
                StickerSetId = data.Id ?? 1;
                StickerSetAccessHash = data.AccessHash ?? 0;
                StickerSetTitle = data.Title ?? "Bin";
                StickerSetShortName = data.ShortName ?? Path.GetFileName(StickerDir);
            }
            else
            {
                StickerInfos = Array.Empty<StickerInfo>();
                DefaultStickerIds = Array.Empty<long>();
                StickerSetId = 1;
                StickerSetAccessHash = 0;
                StickerSetTitle = "Bin";
                StickerSetShortName = "bin_vk";
            }
        }
        catch
        {
            StickerDir = Path.Combine(AppContext.BaseDirectory, "downloads", "stickersets", "bin_vk");
            StickerInfos = Array.Empty<StickerInfo>();
            DefaultStickerIds = Array.Empty<long>();
            StickerSetId = 1;
            StickerSetAccessHash = 0;
            StickerSetTitle = "Bin";
            StickerSetShortName = "bin_vk";
        }
    }

    private static string GetStickerDirectory()
    {
        // Allow overriding the sticker directory via environment variable for deployments where
        // the assets are located outside the application base path.
        var envDir = Environment.GetEnvironmentVariable("MYTELEGRAM_STICKER_DIR");
        if (!string.IsNullOrEmpty(envDir) && Directory.Exists(envDir))
        {
            return envDir;
        }

        static string? Search(string start)
        {
            var info = new DirectoryInfo(start);
            while (info != null)
            {
                var candidate = Path.Combine(info.FullName, "downloads", "stickersets", "bin_vk");
                if (Directory.Exists(candidate))
                {
                    return candidate;
                }

                info = info.Parent;
            }

            return null;
        }

        var dir = Search(AppContext.BaseDirectory) ?? Search(Directory.GetCurrentDirectory());
        if (dir != null)
        {
            return dir;
        }

        return Path.Combine(AppContext.BaseDirectory, "downloads", "stickersets", "bin_vk");
    }

    private static StickerFile LoadStickerInfo(string dir)
    {
        var dataFile = Path.Combine(dir, "data.json");
        StickerFile? data = null;

        if (File.Exists(dataFile))
        {
            try
            {
                using var stream = File.OpenRead(dataFile);
                data = STJ.JsonSerializer.Deserialize<StickerFile>(stream, new STJ.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            catch
            {
                data = null;
            }
        }

        if (data?.Stickers == null || data.Stickers.Count == 0)
        {
            var files = Directory.GetFiles(dir)
                .Where(f => f.EndsWith(".tgs", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".webp", StringComparison.OrdinalIgnoreCase))
                .OrderBy(f => f, StringComparer.OrdinalIgnoreCase)
                .ToArray();

            var infos = new List<StickerInfo>(files.Length);
            for (var i = 0; i < files.Length; i++)
            {
                infos.Add(new StickerInfo { Id = i + 1, File = Path.GetFileName(files[i]) });
            }
            try
            {
                data = new StickerFile
                {
                    Stickers = infos,
                    Title = "Bin",
                    ShortName = Path.GetFileName(dir)
                };
                var json = STJ.JsonSerializer.Serialize(data, new STJ.JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(dataFile, json);
            }
            catch
            {
                // Ignore errors caused by read-only filesystems
            }
        }

        return data ?? new StickerFile
        {
            Stickers = new List<StickerInfo>(),
            Title = "Bin",
            ShortName = Path.GetFileName(dir)
        };
    }

    private class StickerFile
    {
        [JsonPropertyName("id")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public long? Id { get; set; }

        [JsonPropertyName("access_hash")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public long? AccessHash { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("short_name")]
        public string? ShortName { get; set; }

        [JsonPropertyName("stickers")]
        public List<StickerInfo>? Stickers { get; set; }
    }

    public class StickerInfo
    {
        [JsonPropertyName("document_id")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public long Id { get; set; }

        [JsonPropertyName("file")]
        public string File { get; set; } = string.Empty;
    }
}