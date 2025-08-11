namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Messages;

///<summary>
/// Send a media
/// <para>Possible errors</para>
/// Code Type Description
/// 400 BOT_GAMES_DISABLED Games can't be sent to channels.
/// 400 BOT_PAYMENTS_DISABLED Please enable bot payments in botfather before calling this method.
/// 400 BROADCAST_PUBLIC_VOTERS_FORBIDDEN You can't forward polls with public voters.
/// 400 BUTTON_DATA_INVALID The data of one or more of the buttons you provided is invalid.
/// 400 BUTTON_POS_INVALID The position of one of the keyboard buttons is invalid (i.e. a Game or Pay button not in the first position, and so on...).
/// 400 BUTTON_TYPE_INVALID The type of one or more of the buttons you provided is invalid.
/// 400 BUTTON_URL_INVALID Button URL invalid.
/// 400 CHANNEL_INVALID The provided channel is invalid.
/// 406 CHANNEL_PRIVATE You haven't joined this channel/supergroup.
/// 403 CHAT_ADMIN_REQUIRED You must be an admin in this chat to do this.
/// 400 CHAT_FORWARDS_RESTRICTED You can't forward messages from a protected chat.
/// 403 CHAT_GUEST_SEND_FORBIDDEN You join the discussion group before commenting, see <a href="https://corefork.telegram.org/api/discussion#requiring-users-to-join-the-group">here</a> for more info.
/// 400 CHAT_RESTRICTED You can't send messages in this chat, you were restricted.
/// 403 CHAT_SEND_AUDIOS_FORBIDDEN You can't send audio messages in this chat.
/// 403 CHAT_SEND_DOCS_FORBIDDEN You can't send documents in this chat.
/// 403 CHAT_SEND_GIFS_FORBIDDEN You can't send gifs in this chat.
/// 403 CHAT_SEND_MEDIA_FORBIDDEN You can't send media in this chat.
/// 403 CHAT_SEND_PHOTOS_FORBIDDEN You can't send photos in this chat.
/// 403 CHAT_SEND_PLAIN_FORBIDDEN You can't send non-media (text) messages in this chat.
/// 403 CHAT_SEND_POLL_FORBIDDEN You can't send polls in this chat.
/// 403 CHAT_SEND_ROUNDVIDEOS_FORBIDDEN You can't send round videos to this chat.
/// 403 CHAT_SEND_STICKERS_FORBIDDEN You can't send stickers in this chat.
/// 403 CHAT_SEND_VIDEOS_FORBIDDEN You can't send videos in this chat.
/// 403 CHAT_SEND_VOICES_FORBIDDEN You can't send voice recordings in this chat.
/// 403 CHAT_WRITE_FORBIDDEN You can't write in this chat.
/// 400 CURRENCY_TOTAL_AMOUNT_INVALID The total amount of all prices is invalid.
/// 400 DOCUMENT_INVALID The specified document is invalid.
/// 400 EMOTICON_INVALID The specified emoji is invalid.
/// 400 ENTITY_BOUNDS_INVALID A specified <a href="https://corefork.telegram.org/api/entities#entity-length">entity offset or length</a> is invalid, see <a href="https://corefork.telegram.org/api/entities#entity-length">here</a> for info on how to properly compute the entity offset/length.
/// 400 EXTERNAL_URL_INVALID External URL invalid.
/// 400 FILE_PARTS_INVALID The number of file parts is invalid.
/// 400 FILE_PART_LENGTH_INVALID The length of a file part is invalid.
/// 400 FILE_REFERENCE_EMPTY An empty <a href="https://corefork.telegram.org/api/file_reference">file reference</a> was specified.
/// 400 FILE_REFERENCE_EXPIRED File reference expired, it must be refetched as described in <a href="https://corefork.telegram.org/api/file_reference">the documentation</a>.
/// 400 GAME_BOT_INVALID Bots can't send another bot's game.
/// 400 IMAGE_PROCESS_FAILED Failure while processing image.
/// 400 INPUT_FILE_INVALID The specified <a href="https://corefork.telegram.org/type/InputFile">InputFile</a> is invalid.
/// 400 INPUT_USER_DEACTIVATED The specified user was deleted.
/// 400 MD5_CHECKSUM_INVALID The MD5 checksums do not match.
/// 400 MEDIA_CAPTION_TOO_LONG The caption is too long.
/// 400 MEDIA_EMPTY The provided media object is invalid.
/// 400 MEDIA_INVALID Media invalid.
/// 400 MESSAGE_EMPTY The provided message is empty.
/// 400 MSG_ID_INVALID Invalid message ID provided.
/// 400 PAYMENT_PROVIDER_INVALID The specified payment provider is invalid.
/// 400 PEER_ID_INVALID The provided peer id is invalid.
/// 400 PHOTO_EXT_INVALID The extension of the photo is invalid.
/// 400 PHOTO_INVALID_DIMENSIONS The photo dimensions are invalid.
/// 400 PHOTO_SAVE_FILE_INVALID Internal issues, try again later.
/// 400 POLL_ANSWERS_INVALID Invalid poll answers were provided.
/// 400 POLL_ANSWER_INVALID One of the poll answers is not acceptable.
/// 400 POLL_OPTION_DUPLICATE Duplicate poll options provided.
/// 400 POLL_OPTION_INVALID Invalid poll option provided.
/// 400 POLL_QUESTION_INVALID One of the poll questions is not acceptable.
/// 403 PREMIUM_ACCOUNT_REQUIRED A premium account is required to execute this action.
/// 403 PRIVACY_PREMIUM_REQUIRED You need a <a href="https://corefork.telegram.org/api/premium">Telegram Premium subscription</a> to send a message to this user.
/// 400 QUICK_REPLIES_TOO_MUCH A maximum of <a href="https://corefork.telegram.org/api/config#quick-replies-limit">appConfig.<code>quick_replies_limit</code></a> shortcuts may be created, the limit was reached.
/// 400 QUIZ_CORRECT_ANSWERS_EMPTY No correct quiz answer was specified.
/// 400 QUIZ_CORRECT_ANSWERS_TOO_MUCH You specified too many correct answers in a quiz, quizzes can only have one right answer!
/// 400 QUIZ_CORRECT_ANSWER_INVALID An invalid value was provided to the correct_answers field.
/// 400 QUIZ_MULTIPLE_INVALID Quizzes can't have the multiple_choice flag set!
/// 500 RANDOM_ID_DUPLICATE You provided a random ID that was already used.
/// 400 REPLY_MARKUP_BUY_EMPTY Reply markup for buy button empty.
/// 400 REPLY_MARKUP_GAME_EMPTY A game message is being edited, but the newly provided keyboard doesn't have a keyboardButtonGame button.
/// 400 REPLY_MARKUP_INVALID The provided reply markup is invalid.
/// 400 REPLY_MARKUP_TOO_LONG The specified reply_markup is too long.
/// 400 REPLY_MESSAGES_TOO_MUCH Each shortcut can contain a maximum of <a href="https://corefork.telegram.org/api/config#quick-reply-messages-limit">appConfig.<code>quick_reply_messages_limit</code></a> messages, the limit was reached.
/// 400 SCHEDULE_BOT_NOT_ALLOWED Bots cannot schedule messages.
/// 400 SCHEDULE_DATE_TOO_LATE You can't schedule a message this far in the future.
/// 400 SCHEDULE_TOO_MUCH There are too many scheduled messages.
/// 400 SEND_AS_PEER_INVALID You can't send messages as the specified peer.
/// 420 SLOWMODE_WAIT_%d Slowmode is enabled in this chat: wait %d seconds before sending another message to this chat.
/// 400 STORY_ID_INVALID The specified story ID is invalid.
/// 406 TOPIC_CLOSED This topic was closed, you can't send messages to it anymore.
/// 406 TOPIC_DELETED The specified topic was deleted.
/// 400 TTL_MEDIA_INVALID Invalid media Time To Live was provided.
/// 400 USER_BANNED_IN_CHANNEL You're banned from sending messages in supergroups/channels.
/// 403 USER_IS_BLOCKED You were blocked by this user.
/// 400 USER_IS_BOT Bots can't send messages to other bots.
/// 400 VIDEO_CONTENT_TYPE_INVALID The video's content type is invalid.
/// 400 VOICE_MESSAGES_FORBIDDEN This user's privacy settings forbid you from sending voice messages.
/// 400 WEBDOCUMENT_MIME_INVALID Invalid webdocument mime type provided.
/// 400 WEBPAGE_CURL_FAILED Failure while fetching the webpage with cURL.
/// 400 WEBPAGE_MEDIA_EMPTY Webpage media empty.
/// 400 WEBPAGE_NOT_FOUND A preview for the specified webpage <code>url</code> could not be generated.
/// 400 WEBPAGE_URL_INVALID The specified webpage <code>url</code> is invalid.
/// 400 YOU_BLOCKED_USER You blocked this user.
/// See <a href="https://corefork.telegram.org/method/messages.sendMedia" />
///</summary>
internal sealed class SendMediaHandler(
    IMediaHelper mediaHelper,
    IMessageAppService messageAppService,
    IPeerHelper peerHelper,
    IRandomHelper randomHelper,
    ICommandBus commandBus,
    IAccessHashHelper accessHashHelper,
    IPrivacyAppService privacyAppService
)
    : RpcResultObjectHandler<
        MyTelegram.Schema.Messages.RequestSendMedia,
        MyTelegram.Schema.IUpdates
    >,
        Messages.ISendMediaHandler
{
    protected override async Task<IUpdates> HandleCoreAsync(
        IRequestInput input,
        RequestSendMedia obj
    )
    {
        await accessHashHelper.CheckAccessHashAsync(input, obj.Peer);
        await accessHashHelper.CheckAccessHashAsync(input, obj.SendAs);
        var needCheckAudioMessagePrivacy = false;
        switch (obj.Media)
        {
            case Schema.TInputMediaUploadedDocument inputMediaUploadedDocument:
                if (inputMediaUploadedDocument.Attributes.Any(p => p is TDocumentAttributeAudio))
                {
                    needCheckAudioMessagePrivacy = true;
                }
                break;
                //case Schema.Layer197.TInputMediaUploadedDocument inputMediaUploadedDocumentLayer197:
                //    if (inputMediaUploadedDocumentLayer197.Attributes.Any(p => p is TDocumentAttributeAudio))
                //    {
                //        needCheckAudioMessagePrivacy = true;
                //    }
                //    break;
        }

        if (needCheckAudioMessagePrivacy && obj.Peer is TInputPeerUser inputPeerUser)
        {
            await privacyAppService.ApplyPrivacyAsync(
                input.UserId,
                inputPeerUser.UserId,
                (_) =>
                {
                    //ThrowHelper.ThrowUserFriendlyException(RpcErrorMessages.ChatSendVoicesForbidden);
                    RpcErrors.RpcErrors403.ChatSendVoicesForbidden.ThrowRpcError();
                },
                [PrivacyType.VoiceMessages]
            );
        }

        var toPeer = peerHelper.GetPeer(obj.Peer, input.UserId);
        long? pollId = null;
        if (obj.Media is TInputMediaPoll inputMediaPoll)
        {
            pollId = randomHelper.NextInt64();
            inputMediaPoll.Poll.Id = pollId.Value;

            await CreatePollAsync(toPeer, inputMediaPoll);
        }

        var media = await mediaHelper.SaveMediaAsync(obj.Media);
        int? replyToMsgId = null;
        int? topMsgId = null;
        if (obj.ReplyTo is TInputReplyToMessage replyToMessage)
        {
            replyToMsgId = replyToMessage.ReplyToMsgId;
            topMsgId = replyToMessage.TopMsgId;
        }

        var sendMessageInput = new SendMessageInput(
            input.ToRequestInfo(),
            input.UserId,
            peerHelper.GetPeer(obj.Peer, input.UserId),
            obj.Message,
            obj.RandomId,
            clearDraft: obj.ClearDraft,
            entities: obj.Entities,
            media: media,
            //replyToMsgId: replyToMsgId,
            inputReplyTo: obj.ReplyTo,
            sendMessageType: SendMessageType.Media,
            messageType: mediaHelper.GeMessageType(media),
            pollId: pollId,
            topMsgId: topMsgId,
            sendAs: peerHelper.GetPeer(obj.SendAs, input.UserId),
            effect: obj.Effect,
            inputQuickReplyShortcut: obj.QuickReplyShortcut,
            replyMarkup: obj.ReplyMarkup,
            silent: obj.Silent,
            scheduleDate: obj.ScheduleDate,
            invertMedia: obj.InvertMedia
        );
        await messageAppService.SendMessageAsync([sendMessageInput]);

        return null!;
    }

    private async Task CreatePollAsync(Peer toPeer, TInputMediaPoll inputMediaPoll)
    {
        var poll = inputMediaPoll.Poll;
        var solutionEntities = inputMediaPoll.SolutionEntities;
        if (solutionEntities == null && !string.IsNullOrEmpty(inputMediaPoll.Solution))
        {
            solutionEntities = [];
        }

        var command = new CreatePollCommand(
            PollId.Create(toPeer.PeerId, poll.Id),
            toPeer,
            poll.Id,
            poll.MultipleChoice,
            poll.Quiz,
            inputMediaPoll.Poll.PublicVoters,
            poll.Question.Text,
            poll.Answers.Select(p => new PollAnswer(
                    p.Text.Text,
                    p.Option,
                    p.Text.Entities.ToBytes()
                ))
                .ToList(),
            inputMediaPoll.CorrectAnswers?.ToList(),
            inputMediaPoll.Solution,
            solutionEntities,
            poll.Question.Entities
        );
        await commandBus.PublishAsync(command, default);
    }
}
