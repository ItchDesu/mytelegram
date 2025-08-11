// ReSharper disable All

using System;
using MyTelegram.Schema.Auth;

namespace MyTelegram.Messenger.Handlers.LatestLayer.Impl.Account;

///<summary>
/// Send the verification phone code for telegram <a href="https://corefork.telegram.org/passport">passport</a>.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 PHONE_NUMBER_INVALID The phone number is invalid.
/// See <a href="https://corefork.telegram.org/method/account.sendVerifyPhoneCode" />
///</summary>
internal sealed class SendVerifyPhoneCodeHandler : RpcResultObjectHandler<MyTelegram.Schema.Account.RequestSendVerifyPhoneCode, MyTelegram.Schema.Auth.ISentCode>,
    Account.ISendVerifyPhoneCodeHandler
{
    protected override Task<MyTelegram.Schema.Auth.ISentCode> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Account.RequestSendVerifyPhoneCode obj)
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
