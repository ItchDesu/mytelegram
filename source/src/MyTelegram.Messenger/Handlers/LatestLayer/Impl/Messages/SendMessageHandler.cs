namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Messages;

///<summary>
/// Sends a message to a chat
/// <para>Possible errors</para>
/// Code Type Description
/// 400 ADMIN_RIGHTS_EMPTY The chatAdminRights constructor passed in keyboardButtonRequestPeer.peer_type.user_admin_rights has no rights set (i.e. flags is 0).
/// 400 BOT_DOMAIN_INVALID Bot domain invalid.
/// 400 BOT_INVALID This is not a valid bot.
/// 400 BUSINESS_PEER_INVALID Messages can't be set to the specified peer through the current <a href="https://corefork.telegram.org/api/business#connected-bots">business connection</a>.
/// 400 BUTTON_DATA_INVALID The data of one or more of the buttons you provided is invalid.
/// 400 BUTTON_TYPE_INVALID The type of one or more of the buttons you provided is invalid.
/// 400 BUTTON_URL_INVALID Button URL invalid.
/// 400 BUTTON_USER_INVALID The <code>user_id</code> passed to inputKeyboardButtonUserProfile is invalid!
/// 400 BUTTON_USER_PRIVACY_RESTRICTED The privacy setting of the user specified in a <a href="https://corefork.telegram.org/constructor/inputKeyboardButtonUserProfile">inputKeyboardButtonUserProfile</a> button do not allow creating such a button.
/// 400 CHANNEL_INVALID The provided channel is invalid.
/// 406 CHANNEL_PRIVATE You haven't joined this channel/supergroup.
/// 403 CHAT_ADMIN_REQUIRED You must be an admin in this chat to do this.
/// 403 CHAT_GUEST_SEND_FORBIDDEN You join the discussion group before commenting, see <a href="https://corefork.telegram.org/api/discussion#requiring-users-to-join-the-group">here</a> for more info.
/// 400 CHAT_ID_INVALID The provided chat id is invalid.
/// 400 CHAT_RESTRICTED You can't send messages in this chat, you were restricted.
/// 403 CHAT_SEND_PLAIN_FORBIDDEN You can't send non-media (text) messages in this chat.
/// 403 CHAT_WRITE_FORBIDDEN You can't write in this chat.
/// 400 DOCUMENT_INVALID The specified document is invalid.
/// 400 ENCRYPTION_DECLINED The secret chat was declined.
/// 400 ENTITIES_TOO_LONG You provided too many styled message entities.
/// 400 ENTITY_BOUNDS_INVALID A specified <a href="https://corefork.telegram.org/api/entities#entity-length">entity offset or length</a> is invalid, see <a href="https://corefork.telegram.org/api/entities#entity-length">here</a> for info on how to properly compute the entity offset/length.
/// 400 ENTITY_MENTION_USER_INVALID You mentioned an invalid user.
/// 400 FROM_MESSAGE_BOT_DISABLED Bots can't use fromMessage min constructors.
/// 400 INPUT_USER_DEACTIVATED The specified user was deleted.
/// 400 MESSAGE_EMPTY The provided message is empty.
/// 400 MESSAGE_TOO_LONG The provided message is too long.
/// 400 MSG_ID_INVALID Invalid message ID provided.
/// 500 MSG_WAIT_FAILED A waiting call returned an error.
/// 406 PAYMENT_UNSUPPORTED A detailed description of the error will be received separately as described <a href="https://corefork.telegram.org/api/errors#406-not-acceptable">here</a>.
/// 400 PEER_ID_INVALID The provided peer id is invalid.
/// 400 PINNED_DIALOGS_TOO_MUCH Too many pinned dialogs.
/// 400 POLL_OPTION_INVALID Invalid poll option provided.
/// 406 PRIVACY_PREMIUM_REQUIRED You need a <a href="https://corefork.telegram.org/api/premium">Telegram Premium subscription</a> to send a message to this user.
/// 400 QUICK_REPLIES_TOO_MUCH A maximum of <a href="https://corefork.telegram.org/api/config#quick-replies-limit">appConfig.<code>quick_replies_limit</code></a> shortcuts may be created, the limit was reached.
/// 400 QUOTE_TEXT_INVALID The specified <code>reply_to</code>.<code>quote_text</code> field is invalid.
/// 500 RANDOM_ID_DUPLICATE You provided a random ID that was already used.
/// 400 REPLY_MARKUP_INVALID The provided reply markup is invalid.
/// 400 REPLY_MARKUP_TOO_LONG The specified reply_markup is too long.
/// 400 REPLY_MESSAGES_TOO_MUCH Each shortcut can contain a maximum of <a href="https://corefork.telegram.org/api/config#quick-reply-messages-limit">appConfig.<code>quick_reply_messages_limit</code></a> messages, the limit was reached.
/// 400 REPLY_MESSAGE_ID_INVALID The specified reply-to message ID is invalid.
/// 400 REPLY_TO_INVALID The specified <code>reply_to</code> field is invalid.
/// 400 REPLY_TO_USER_INVALID The replied-to user is invalid.
/// 400 SCHEDULE_BOT_NOT_ALLOWED Bots cannot schedule messages.
/// 400 SCHEDULE_DATE_TOO_LATE You can't schedule a message this far in the future.
/// 400 SCHEDULE_STATUS_PRIVATE Can't schedule until user is online, if the user's last seen timestamp is hidden by their privacy settings.
/// 400 SCHEDULE_TOO_MUCH There are too many scheduled messages.
/// 400 SEND_AS_PEER_INVALID You can't send messages as the specified peer.
/// 420 SLOWMODE_WAIT_%d Slowmode is enabled in this chat: wait %d seconds before sending another message to this chat.
/// 400 STORY_ID_INVALID The specified story ID is invalid.
/// 406 TOPIC_CLOSED This topic was closed, you can't send messages to it anymore.
/// 406 TOPIC_DELETED The specified topic was deleted.
/// 400 USER_BANNED_IN_CHANNEL You're banned from sending messages in supergroups/channels.
/// 403 USER_IS_BLOCKED You were blocked by this user.
/// 400 USER_IS_BOT Bots can't send messages to other bots.
/// 400 WC_CONVERT_URL_INVALID WC convert URL invalid.
/// 400 YOU_BLOCKED_USER You blocked this user.
/// See <a href="https://corefork.telegram.org/method/messages.sendMessage" />
///</summary>
internal sealed class SendMessageHandler(
    IMessageAppService messageAppService,
    IPeerHelper peerHelper,
    IAccessHashHelper accessHashHelper,
    IChannelAppService channelAppService,
    IOptions<MyTelegramMessengerServerOptions> options,
    IQueryProcessor queryProcessor)
    : RpcResultObjectHandler<RequestSendMessage, IUpdates>,
        ISendMessageHandler
{
    protected override async Task<IUpdates> HandleCoreAsync(IRequestInput input,
        RequestSendMessage obj)
    {
        await accessHashHelper.CheckAccessHashAsync(input, obj.Peer);
        await accessHashHelper.CheckAccessHashAsync(input, obj.SendAs);
        var media = await ProcessUrlsInMessageAsync(obj);
        if (obj.Message.StartsWith("/"))
        {
            obj.Entities ??= [];
            obj.Entities.Add(new TMessageEntityBotCommand
            {
                Length = obj.Message.Length,
                Offset = 0
            });
        }

        int? topMsgId = null;

        var sendAs = peerHelper.GetPeer(obj.SendAs, input.UserId);
        var sendMessageInput = new SendMessageInput(input.ToRequestInfo(),
            input.UserId,
            peerHelper.GetPeer(obj.Peer, input.UserId),
            obj.Message,
            obj.RandomId,
            obj.Entities,
            obj.ReplyTo,
            obj.ClearDraft,
            media: media,
            replyMarkup: obj.ReplyMarkup,
            topMsgId: topMsgId,
            sendAs: sendAs,
            effect: obj.Effect,
            inputQuickReplyShortcut: obj.QuickReplyShortcut,
            silent: obj.Silent,
            scheduleDate: obj.ScheduleDate,
            invertMedia: obj.InvertMedia
        );
        await messageAppService.SendMessageAsync([sendMessageInput]);

        return null!;
    }
    private async Task<TMessageMediaWebPage?> ProcessUrlsInMessageAsync(RequestSendMessage obj)
    {
        var pattern = @"(?:^|\s)(https?://[^\s]+)(?=\s|$)";
        var pattern2 = @$"{options.Value.JoinChatDomain}/\+([\S]{{16}})";
        var matches = Regex.Matches(obj.Message, pattern);
        var isInviteUrlAdded = false;
        TMessageMediaWebPage? media = null;
        foreach (Match match in matches)
        {
            obj.Entities ??= [];
            var url = match.Groups[1].Value;
            var m2 = Regex.Match(url, pattern2);
            if (m2.Success && !isInviteUrlAdded)
            {
                var link = m2.Groups[1].Value;
                var chatInvite = await queryProcessor.ProcessAsync(new GetChatInviteByLinkQuery(link));
                if (chatInvite != null)
                {
                    var channelReadModel = await channelAppService.GetAsync(chatInvite.PeerId);
                    // Super group/Public channel
                    if (!channelReadModel.Broadcast ||
                        (channelReadModel.Broadcast && !string.IsNullOrEmpty(channelReadModel.UserName)))
                    {
                        media = new TMessageMediaWebPage
                        {
                            Webpage = new Schema.TWebPage
                            {
                                Id = Random.Shared.NextInt64(),
                                Url = $"{options.Value.JoinChatDomain}/+{link}",
                                DisplayUrl = $"{options.Value.JoinChatDomain}/+{link}",
                                Type = channelReadModel.Broadcast ? "telegram_channel" : "telegram_megagroup",
                                SiteName = "Buzzster",
                                Title = channelReadModel.Title,
                                Description = $"Join this group on Buzzster.",
                            }
                        };
                    }

                    isInviteUrlAdded = true;
                }
            }
        }

        return media;
    }
}
