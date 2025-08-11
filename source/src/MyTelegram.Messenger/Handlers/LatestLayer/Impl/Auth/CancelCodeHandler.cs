namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Auth;

///<summary>
/// Cancel the login verification code
/// <para>Possible errors</para>
/// Code Type Description
/// 400 PHONE_CODE_EXPIRED The phone code you provided has expired.
/// 406 PHONE_NUMBER_INVALID The phone number is invalid.
/// See <a href="https://corefork.telegram.org/method/auth.cancelCode" />
///</summary>
internal sealed class CancelCodeHandler : RpcResultObjectHandler<MyTelegram.Schema.Auth.RequestCancelCode, IBool>,
    Auth.ICancelCodeHandler
{
    protected override Task<IBool> HandleCoreAsync(IRequestInput input,
        RequestCancelCode obj)
    {
        // todo:cancel code
        return Task.FromResult<IBool>(new TBoolTrue());
    }
}
