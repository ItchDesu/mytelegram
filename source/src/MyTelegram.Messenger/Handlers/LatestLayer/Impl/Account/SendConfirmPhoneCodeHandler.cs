// ReSharper disable All

using System;
using MyTelegram.Schema.Auth;

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Account;

///<summary>
/// Send confirmation code to cancel account deletion, for more info <a href="https://corefork.telegram.org/api/account-deletion">click here </a>
/// <para>Possible errors</para>
/// Code Type Description
/// 400 HASH_INVALID The provided hash is invalid.
/// See <a href="https://corefork.telegram.org/method/account.sendConfirmPhoneCode" />
///</summary>
internal sealed class SendConfirmPhoneCodeHandler : RpcResultObjectHandler<MyTelegram.Schema.Account.RequestSendConfirmPhoneCode, MyTelegram.Schema.Auth.ISentCode>,
    Account.ISendConfirmPhoneCodeHandler
{
    protected override Task<MyTelegram.Schema.Auth.ISentCode> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Account.RequestSendConfirmPhoneCode obj)
    {
        var sentCode = new TSentCode
        {
            Type = new TSentCodeTypeSms { Length = 5 },
            PhoneCodeHash = Guid.NewGuid().ToString("N"),
            Timeout = 60
        };
        return Task.FromResult<ISentCode>(sentCode);
    }
}
