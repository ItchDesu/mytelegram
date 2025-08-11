namespace MyTelegram.QueryHandlers.InMemory.User;

public class GetGlobalPrivacySettingsQueryHandler(IQueryOnlyReadModelStore<UserReadModel> store) : IQueryHandler<GetGlobalPrivacySettingsQuery, GlobalPrivacySettings?>
{
    public async Task<GlobalPrivacySettings?> ExecuteQueryAsync(GetGlobalPrivacySettingsQuery query, CancellationToken cancellationToken)
    {
        return await store.FirstOrDefaultAsync(p => p.UserId == query.UserId, createResult: p => p.GlobalPrivacySettings, cancellationToken: cancellationToken);
    }
}