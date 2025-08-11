using System;
using System.Collections.Generic;
using System.Linq;
// Use System.Text.Json's JsonSerializer explicitly to avoid ambiguity
using SystemTextJson = System.Text.Json.JsonSerializer;
using MyTelegram.ReadModel.Interfaces;
using MyTelegram.Schema;
using MyTelegram.Messenger.Services.Interfaces;

namespace MyTelegram.Messenger.Services.Impl;

public class PrivacyAppService(
    ICacheManager<GlobalPrivacySettingsCacheItem> cacheManager,
    IQueryProcessor queryProcessor,
    IPrivacyHelper privacyHelper)
    : BaseAppService, IPrivacyAppService, ITransientDependency
{
    private readonly Dictionary<(long UserId, PrivacyType PrivacyType), List<PrivacyValueData>> _privacyStore = new();
    private readonly Dictionary<long, GlobalPrivacySettingsCacheItem> _globalPrivacyStore = new();
    private readonly IPrivacyHelper _privacyHelper = privacyHelper;
    public Task<IReadOnlyCollection<IPrivacyReadModel>> GetPrivacyListAsync(
        IReadOnlyList<long> userIds)
    {
        var list = new List<IPrivacyReadModel>();
        foreach (var kv in _privacyStore)
        {
            if (userIds.Contains(kv.Key.UserId))
            {
                list.Add(new PrivacyReadModelImpl(kv.Key.UserId, kv.Key.PrivacyType, kv.Value));
            }
        }

        return Task.FromResult<IReadOnlyCollection<IPrivacyReadModel>>(list);
    }

    public Task<IReadOnlyCollection<IPrivacyReadModel>> GetPrivacyListAsync(long userId)
    {
        return GetPrivacyListAsync([userId]);
    }

    public Task ApplyPrivacyAsync(
        long selfUserId,
        long targetUserId,
        Action<PrivacyValueType> executeOnPrivacyNotMatch,
        PrivacyType privacyType)
        => ApplyPrivacyAsync(
            selfUserId,
            targetUserId,
            executeOnPrivacyNotMatch,
            new List<PrivacyType> { privacyType });

    public Task ApplyPrivacyAsync(
        long selfUserId,
        long targetUserId,
        Action<PrivacyValueType> executeOnPrivacyNotMatch,
        List<PrivacyType> privacyTypes)
        => ApplyPrivacyInternalAsync(selfUserId, targetUserId, executeOnPrivacyNotMatch, privacyTypes);

    public Task ApplyPrivacyListAsync(
        long selfUserId,
        IReadOnlyList<long> targetUserIdList,
        Action<long> executeOnPrivacyNotMatch,
        List<PrivacyType> privacyTypes)
        => ApplyPrivacyListAsync(
            selfUserId,
            targetUserIdList,
            (_, targetId) => executeOnPrivacyNotMatch(targetId),
            privacyTypes);

    public Task ApplyPrivacyListAsync(
        long selfUserId,
        IReadOnlyList<long> targetUserIdList,
        Action<PrivacyValueType, long> executeOnPrivacyNotMatch,
        List<PrivacyType> privacyTypes)
        => ApplyPrivacyListInternalAsync(selfUserId, targetUserIdList, executeOnPrivacyNotMatch, privacyTypes);

    public Task<IReadOnlyList<IPrivacyRule>> GetPrivacyRulesAsync(
        long selfUserId,
        IInputPrivacyKey key)
    {
        var privacyType = GetPrivacyType(key);
        if (!_privacyStore.TryGetValue((selfUserId, privacyType), out var dataList) || dataList.Count == 0)
        {
            return Task.FromResult<IReadOnlyList<IPrivacyRule>>(new List<IPrivacyRule>
            {
                new TPrivacyValueAllowAll()
            });
        }

        var rules = dataList.Select(ToPrivacyRule).ToList<IPrivacyRule>();
        return Task.FromResult<IReadOnlyList<IPrivacyRule>>(rules);
    }

    public Task SetGlobalPrivacySettingsAsync(
        long selfUserId,
        GlobalPrivacySettings globalPrivacySettings)
    {
        var item = new GlobalPrivacySettingsCacheItem(
            globalPrivacySettings.ArchiveAndMuteNewNoncontactPeers,
            globalPrivacySettings.KeepArchivedUnmuted,
            globalPrivacySettings.KeepArchivedFolders,
            globalPrivacySettings.HideReadMarks,
            globalPrivacySettings.NewNoncontactPeersRequirePremium);

        _globalPrivacyStore[selfUserId] = item;
        return cacheManager.SetAsync(GlobalPrivacySettingsCacheItem.GetCacheKey(selfUserId), item);
    }

    public async Task<GlobalPrivacySettingsCacheItem?> GetGlobalPrivacySettingsAsync(long userId)
    {
        var cacheKey = GlobalPrivacySettingsCacheItem.GetCacheKey(userId);
        var item = await cacheManager.GetAsync(cacheKey);
        if (item != null)
        {
            return item;
        }

        if (_globalPrivacyStore.TryGetValue(userId, out var local))
        {
            await cacheManager.SetAsync(cacheKey, local);
            return local;
        }

        var globalPrivacySettings =
            await queryProcessor.ProcessAsync(new GetGlobalPrivacySettingsQuery(userId));
        if (globalPrivacySettings != null)
        {
            item = new GlobalPrivacySettingsCacheItem(
                globalPrivacySettings.ArchiveAndMuteNewNoncontactPeers,
                globalPrivacySettings.KeepArchivedUnmuted,
                globalPrivacySettings.KeepArchivedFolders,
                globalPrivacySettings.HideReadMarks,
                globalPrivacySettings.NewNoncontactPeersRequirePremium);
            await cacheManager.SetAsync(cacheKey, item);
            return item;
        }

        return null;
    }

    public PrivacyValueData GetPrivacyValueData(IInputPrivacyRule rule)
    {
        return rule switch
        {
            TInputPrivacyValueAllowContacts =>
                new PrivacyValueData(PrivacyValueType.AllowContacts),
            TInputPrivacyValueAllowAll =>
                new PrivacyValueData(PrivacyValueType.AllowAll),
            TInputPrivacyValueAllowUsers allowUsers =>
                new PrivacyValueData(PrivacyValueType.AllowUsers,
                    SystemTextJson.Serialize(allowUsers.Users)),
            TInputPrivacyValueDisallowContacts =>
                new PrivacyValueData(PrivacyValueType.DisallowContacts),
            TInputPrivacyValueDisallowAll =>
                new PrivacyValueData(PrivacyValueType.DisallowAll),
            TInputPrivacyValueDisallowUsers disallowUsers =>
                new PrivacyValueData(PrivacyValueType.DisallowUsers,
                    SystemTextJson.Serialize(disallowUsers.Users)),
            TInputPrivacyValueAllowChatParticipants allowChat =>
                new PrivacyValueData(PrivacyValueType.AllowChatParticipants,
                    SystemTextJson.Serialize(allowChat.Chats)),
            TInputPrivacyValueDisallowChatParticipants disallowChat =>
                new PrivacyValueData(PrivacyValueType.DisallowChatParticipants,
                    SystemTextJson.Serialize(disallowChat.Chats)),
            TInputPrivacyValueAllowBots =>
                new PrivacyValueData(PrivacyValueType.AllowBots),
            TInputPrivacyValueDisallowBots =>
                new PrivacyValueData(PrivacyValueType.DisallowBots),
            TInputPrivacyValueAllowCloseFriends =>
                new PrivacyValueData(PrivacyValueType.AllowCloseFriends),
            TInputPrivacyValueAllowPremium =>
                new PrivacyValueData(PrivacyValueType.AllowPremium),
            _ => new PrivacyValueData(PrivacyValueType.Unknown)
        };
    }

    public List<PrivacyValueData> GetPrivacyValueDataList(IList<IInputPrivacyRule> rules)
    {
        var list = new List<PrivacyValueData>();
        foreach (var rule in rules)
        {
            list.Add(GetPrivacyValueData(rule));
        }

        return list;
    }

    public Task<SetPrivacyOutput> SetPrivacyAsync(
        RequestInfo requestInfo,
        long selfUserId,
        IInputPrivacyKey key,
        IReadOnlyList<IInputPrivacyRule> ruleList)
    {
        var privacyType = GetPrivacyType(key);
        var dataList = GetPrivacyValueDataList(ruleList.ToList());
        _privacyStore[(selfUserId, privacyType)] = dataList;

        var rules = dataList.Select(ToPrivacyRule).ToList<IPrivacyRule>();
        return Task.FromResult(new SetPrivacyOutput(rules));
    }

    private async Task ApplyPrivacyInternalAsync(
        long selfUserId,
        long targetUserId,
        Action<PrivacyValueType> executeOnPrivacyNotMatch,
        List<PrivacyType> privacyTypes)
    {
        var privacyList = await GetPrivacyListAsync(targetUserId);
        foreach (var type in privacyTypes)
        {
            var model = privacyList.FirstOrDefault(p => p.PrivacyType == type);
            if (!_privacyHelper.IsAllowedByPrivacy(selfUserId, model, ContactType.None))
            {
                var valueType = model?.PrivacyValueDataList.FirstOrDefault()?.PrivacyValueType ??
                                 PrivacyValueType.Unknown;
                executeOnPrivacyNotMatch(valueType);
                break;
            }
        }
    }

    private async Task ApplyPrivacyListInternalAsync(
        long selfUserId,
        IReadOnlyList<long> targetUserIdList,
        Action<PrivacyValueType, long> executeOnPrivacyNotMatch,
        List<PrivacyType> privacyTypes)
    {
        foreach (var targetId in targetUserIdList)
        {
            await ApplyPrivacyInternalAsync(selfUserId, targetId, t => executeOnPrivacyNotMatch(t, targetId), privacyTypes);
        }
    }

    private static PrivacyType GetPrivacyType(IInputPrivacyKey key) => key switch
    {
        TInputPrivacyKeyStatusTimestamp => PrivacyType.StatusTimestamp,
        TInputPrivacyKeyChatInvite => PrivacyType.ChatInvite,
        TInputPrivacyKeyPhoneCall => PrivacyType.PhoneCall,
        TInputPrivacyKeyPhoneP2P => PrivacyType.PhoneP2P,
        TInputPrivacyKeyForwards => PrivacyType.Forwards,
        TInputPrivacyKeyProfilePhoto => PrivacyType.ProfilePhoto,
        TInputPrivacyKeyPhoneNumber => PrivacyType.PhoneNumber,
        TInputPrivacyKeyAddedByPhone => PrivacyType.AddedByPhone,
        _ => PrivacyType.Unknown
    };

    private static IPrivacyRule ToPrivacyRule(PrivacyValueData data) => data.PrivacyValueType switch
    {
        PrivacyValueType.AllowContacts => new TPrivacyValueAllowContacts(),
        PrivacyValueType.AllowAll => new TPrivacyValueAllowAll(),
        PrivacyValueType.AllowUsers =>
            new TPrivacyValueAllowUsers
            {
                Users = new TVector<long>(SystemTextJson.Deserialize<List<long>>(data.JsonData ?? "[]") ?? new List<long>())
            },
        PrivacyValueType.DisallowContacts => new TPrivacyValueDisallowContacts(),
        PrivacyValueType.DisallowAll => new TPrivacyValueDisallowAll(),
        PrivacyValueType.DisallowUsers =>
            new TPrivacyValueDisallowUsers
            {
                Users = new TVector<long>(SystemTextJson.Deserialize<List<long>>(data.JsonData ?? "[]") ?? new List<long>())
            },
        PrivacyValueType.AllowChatParticipants =>
            new TPrivacyValueAllowChatParticipants
            {
                Chats = new TVector<long>(SystemTextJson.Deserialize<List<long>>(data.JsonData ?? "[]") ?? new List<long>())
            },
        PrivacyValueType.DisallowChatParticipants =>
            new TPrivacyValueDisallowChatParticipants
            {
                Chats = new TVector<long>(SystemTextJson.Deserialize<List<long>>(data.JsonData ?? "[]") ?? new List<long>())
            },
        PrivacyValueType.AllowBots => new TPrivacyValueAllowBots(),
        PrivacyValueType.DisallowBots => new TPrivacyValueDisallowBots(),
        PrivacyValueType.AllowCloseFriends => new TPrivacyValueAllowCloseFriends(),
        PrivacyValueType.AllowPremium => new TPrivacyValueAllowPremium(),
        _ => new TPrivacyValueAllowAll()
    };

    private class PrivacyReadModelImpl(long userId, PrivacyType privacyType, IReadOnlyList<PrivacyValueData> list) : IPrivacyReadModel
    {
        public string Id { get; } = $"{userId}_{privacyType}";
        public PrivacyType PrivacyType { get; } = privacyType;
        public IReadOnlyList<PrivacyValueData> PrivacyValueDataList { get; } = list;
        public long UserId { get; } = userId;
    }
}