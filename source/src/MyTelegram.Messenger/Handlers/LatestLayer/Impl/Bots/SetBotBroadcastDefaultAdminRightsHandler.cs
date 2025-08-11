// ReSharper disable All

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Bots;

///<summary>
/// Set the default <a href="https://corefork.telegram.org/api/rights#suggested-bot-rights">suggested admin rights</a> for bots being added as admins to channels, see <a href="https://corefork.telegram.org/api/rights#suggested-bot-rights">here for more info on how to handle them </a>.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 RIGHTS_NOT_MODIFIED The new admin rights are equal to the old rights, no change was made.
/// See <a href="https://corefork.telegram.org/method/bots.setBotBroadcastDefaultAdminRights" />
///</summary>
internal sealed class SetBotBroadcastDefaultAdminRightsHandler : RpcResultObjectHandler<MyTelegram.Schema.Bots.RequestSetBotBroadcastDefaultAdminRights, IBool>,
    Bots.ISetBotBroadcastDefaultAdminRightsHandler
{
    protected override Task<IBool> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Bots.RequestSetBotBroadcastDefaultAdminRights obj)
    {
        return Task.FromResult<IBool>(new TBoolTrue());
    }
}
