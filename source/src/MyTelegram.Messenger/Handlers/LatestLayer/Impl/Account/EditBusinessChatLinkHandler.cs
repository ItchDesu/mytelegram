// ReSharper disable All

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Account;

///<summary>
/// Edit a created <a href="https://corefork.telegram.org/api/business#business-chat-links">business chat deep link </a>.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 CHATLINK_SLUG_EMPTY The specified slug is empty.
/// 403 PREMIUM_ACCOUNT_REQUIRED A premium account is required to execute this action.
/// See <a href="https://corefork.telegram.org/method/account.editBusinessChatLink" />
///</summary>
internal sealed class EditBusinessChatLinkHandler : RpcResultObjectHandler<MyTelegram.Schema.Account.RequestEditBusinessChatLink, MyTelegram.Schema.IBusinessChatLink>,
    Account.IEditBusinessChatLinkHandler
{
    protected override Task<MyTelegram.Schema.IBusinessChatLink> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Account.RequestEditBusinessChatLink obj)
    {
        var link = obj.Link as TInputBusinessChatLink;

        var businessLink = new TBusinessChatLink
        {
            Link = $"https://t.me/{obj.Slug}",
            Message = link?.Message ?? string.Empty,
            Entities = link?.Entities,
            Title = link?.Title,
            Views = 0
        };

        return Task.FromResult<IBusinessChatLink>(businessLink);
    }
}