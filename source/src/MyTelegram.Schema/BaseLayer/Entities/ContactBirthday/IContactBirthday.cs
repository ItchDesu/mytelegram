// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Birthday information of a contact.
/// See <a href="https://corefork.telegram.org/constructor/ContactBirthday" />
///</summary>
[JsonDerivedType(typeof(TContactBirthday), nameof(TContactBirthday))]
public interface IContactBirthday : IObject
{
    ///<summary>
    /// User ID.
    ///</summary>
    long ContactId { get; set; }

    ///<summary>
    /// Birthday information.
    /// See <a href="https://corefork.telegram.org/type/Birthday" />
    ///</summary>
    MyTelegram.Schema.IBirthday Birthday { get; set; }
}
