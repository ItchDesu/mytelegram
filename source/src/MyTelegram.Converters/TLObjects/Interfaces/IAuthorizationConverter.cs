using IAuthorization = MyTelegram.Schema.Auth.IAuthorization;

namespace MyTelegram.Converters.TLObjects.Interfaces;

public interface IAuthorizationConverter : ILayeredConverter
{
    IAuthorization CreateAuthorization(IUser? user, bool setupPasswordRequired = false);
    IAuthorization CreateSignUpAuthorization();
    Schema.IAuthorization ToAuthorization(IDeviceReadModel deviceReadModel, long selfPermAuthKeyId = -1);
    IWebAuthorization ToWebAuthorization(IDeviceReadModel deviceReadModel, long selfPermAuthKeyId = -1);

    IReadOnlyList<Schema.IAuthorization> ToAuthorizations(IReadOnlyCollection<IDeviceReadModel> deviceReadModels,
        long selfPermAuthKeyId = -1);

    IReadOnlyList<IWebAuthorization> ToWebAuthorizations(IReadOnlyCollection<IDeviceReadModel> deviceReadModels,
        long selfPermAuthKeyId = -1);
}