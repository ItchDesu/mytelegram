using IMessageViews = MyTelegram.Schema.IMessageViews;

namespace MyTelegram.Messenger.Services.Interfaces;

public interface IChannelMessageViewsAppService
{
    Task IncrementViewsIfNotIncrementedAsync(long selfUserId,
        long authKeyId,
        long channelId,
        int messageId);
    Task<IList<IMessageViews>> GetMessageViewsAsync(long selfUserId,
        long authKeyId,
        long channelId,
        List<int> messageIdList);
}