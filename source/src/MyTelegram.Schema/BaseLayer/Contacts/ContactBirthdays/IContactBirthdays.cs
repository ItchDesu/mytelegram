// ReSharper disable All

namespace MyTelegram.Schema.Contacts;

///<summary>
/// Birthday information of our contacts.
/// See <a href="https://corefork.telegram.org/constructor/contacts.ContactBirthdays" />
///</summary>
[JsonDerivedType(typeof(TContactBirthdays), nameof(TContactBirthdays))]
public interface IContactBirthdays : IObject
{
    ///<summary>
    /// Birthday info
    /// See <a href="https://corefork.telegram.org/type/ContactBirthday" />
    ///</summary>
    TVector<MyTelegram.Schema.IContactBirthday> Contacts { get; set; }

    ///<summary>
    /// User information
    /// See <a href="https://corefork.telegram.org/type/User" />
    ///</summary>
    TVector<MyTelegram.Schema.IUser> Users { get; set; }
}
