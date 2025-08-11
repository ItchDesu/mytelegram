// ReSharper disable All

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Account;

///<summary>
/// Create a <a href="https://corefork.telegram.org/api/business#business-chat-links">business chat deep link </a>.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 CHATLINKS_TOO_MUCH Too many <a href="https://corefork.telegram.org/api/business#business-chat-links">business chat links</a> were created, please delete some older links.
/// 403 PREMIUM_ACCOUNT_REQUIRED A premium account is required to execute this action.
/// See <a href="https://corefork.telegram.org/method/account.createBusinessChatLink" />
///</summary>
internal sealed class CreateBusinessChatLinkHandler : RpcResultObjectHandler<MyTelegram.Schema.Account.RequestCreateBusinessChatLink, MyTelegram.Schema.IBusinessChatLink>,
    Account.ICreateBusinessChatLinkHandler
{
    protected override Task<MyTelegram.Schema.IBusinessChatLink> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Account.RequestCreateBusinessChatLink obj)
    {
        var link = obj.Link as TInputBusinessChatLink;

        var businessLink = new TBusinessChatLink
        {
            Link = $"https://buzzster.io/{input.UserId}/{Guid.NewGuid():N}",
            Message = link?.Message ?? string.Empty,
            Entities = link?.Entities,
            Title = link?.Title,
            Views = 0
        };

        return Task.FromResult<IBusinessChatLink>(businessLink);
    }
}