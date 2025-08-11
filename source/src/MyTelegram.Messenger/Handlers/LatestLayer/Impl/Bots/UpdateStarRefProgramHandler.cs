// ReSharper disable All

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Bots;

///<summary>
/// See <a href="https://corefork.telegram.org/method/bots.updateStarRefProgram" />
///</summary>
internal sealed class UpdateStarRefProgramHandler : RpcResultObjectHandler<MyTelegram.Schema.Bots.RequestUpdateStarRefProgram, MyTelegram.Schema.IStarRefProgram>,
    Bots.IUpdateStarRefProgramHandler
{
    protected override Task<MyTelegram.Schema.IStarRefProgram> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Bots.RequestUpdateStarRefProgram obj)
    {
        return Task.FromResult<MyTelegram.Schema.IStarRefProgram>(new MyTelegram.Schema.TStarRefProgram
        {
            BotId = 0,
            CommissionPermille = 0
        });
    }
}
