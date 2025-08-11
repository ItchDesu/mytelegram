// ReSharper disable once CheckNamespace

namespace MyTelegram;

public enum IdType
{
    DialogId = 1,
    MessageId = 2,

    //ChannelMessageId = 3,
    UserId = 4,
    ChannelId = 5,
    ChatId = 6,
    PrivacyId = 7,
    MessageFwdHeaderId = 8,
    MessageMediaId = 9,
    BotId = 10,
    BotUserId = 11,
    BotUpdateId = 12,
    ReplyToMsgId = 13,
    Pts = 14,
    GlobalMessageId = 15,
    Qts = 16,
    PushSeqNo = 17,
    GlobalSeqNo = 18,
    NextHiLoHighValue = 19,
    InviteId = 20,
    SecretChatId = 21,
    QuickReplyShortcutId = 22,
    QuickReplyMessageId = 23,
    ScheduleMessageId = 24,
    StoryId = 25,
    FolderId = 26,
}