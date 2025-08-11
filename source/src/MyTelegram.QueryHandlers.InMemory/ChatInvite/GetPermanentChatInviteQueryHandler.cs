namespace MyTelegram.QueryHandlers.InMemory.ChatInvite;

public class GetPermanentChatInviteQueryHandler(IQueryOnlyReadModelStore<ChatInviteReadModel> store) : IQueryHandler<GetPermanentChatInviteQuery, IChatInviteReadModel?>
{
    public async Task<IChatInviteReadModel?> ExecuteQueryAsync(GetPermanentChatInviteQuery query, CancellationToken cancellationToken)
    {
        return await store.FirstOrDefaultAsync(p => p.PeerId == query.PeerId && p.Permanent && !p.Revoked, cancellationToken: cancellationToken);
    }
}