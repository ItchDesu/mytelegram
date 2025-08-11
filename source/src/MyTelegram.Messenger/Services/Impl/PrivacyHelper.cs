using System;
using System.Collections.Generic;
using System.Linq;
// Avoid ambiguity between System.Text.Json.JsonSerializer and EventFlow.Core.JsonSerializer
using SystemTextJson = System.Text.Json.JsonSerializer;

namespace MyTelegram.Messenger.Services.Impl;

public class PrivacyHelper : IPrivacyHelper, ITransientDependency
{
    public void ApplyPrivacy(
        IPrivacyReadModel? privacyReadModel,
        Action executeOnPrivacyNotMatch,
        long selfUserId,
        bool isContact)
    {
        var contactType = isContact ? ContactType.TargetUserIsMyContact : ContactType.None;
        if (!IsAllowedByPrivacy(selfUserId, privacyReadModel, contactType))
        {
            executeOnPrivacyNotMatch();
        }
    }

    public void ApplyPrivacy(
        IPrivacyReadModel? privacyReadModel,
        Action<PrivacyValueType> executeOnPrivacyNotMatch,
        long selfUserId,
        ContactType contactType)
    {
        if (!IsAllowedByPrivacy(selfUserId, privacyReadModel, contactType))
        {
            var value = privacyReadModel?.PrivacyValueDataList.FirstOrDefault()?.PrivacyValueType ??
                        PrivacyValueType.Unknown;
            executeOnPrivacyNotMatch(value);
        }
    }

    public bool IsAllowedByPrivacy(long selfUserId, IPrivacyReadModel? privacyReadModel, ContactType contactType)
    {
        if (privacyReadModel == null || privacyReadModel.PrivacyValueDataList.Count == 0)
        {
            return true;
        }

        foreach (var data in privacyReadModel.PrivacyValueDataList)
        {
            switch (data.PrivacyValueType)
            {
                case PrivacyValueType.AllowAll:
                    return true;
                case PrivacyValueType.DisallowAll:
                    return false;
                case PrivacyValueType.AllowContacts:
                    return contactType is ContactType.TargetUserIsMyContact or ContactType.Mutual;
                case PrivacyValueType.DisallowContacts:
                    return !(contactType is ContactType.TargetUserIsMyContact or ContactType.Mutual);
                case PrivacyValueType.AllowUsers:
                {
                    var ids = SystemTextJson.Deserialize<List<long>>(data.JsonData ?? "[]") ?? new List<long>();
                    if (ids.Contains(selfUserId))
                    {
                        return true;
                    }
                    break;
                }
                case PrivacyValueType.DisallowUsers:
                {
                    var ids = SystemTextJson.Deserialize<List<long>>(data.JsonData ?? "[]") ?? new List<long>();
                    if (ids.Contains(selfUserId))
                    {
                        return false;
                    }
                    break;
                }
            }
        }

        return true;
    }
}