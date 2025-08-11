// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Info about an SMS job.
/// See <a href="https://corefork.telegram.org/constructor/SmsJob" />
///</summary>
[JsonDerivedType(typeof(TSmsJob), nameof(TSmsJob))]
public interface ISmsJob : IObject
{
    ///<summary>
    /// Job ID
    ///</summary>
    string JobId { get; set; }

    ///<summary>
    /// Destination phone number
    ///</summary>
    string PhoneNumber { get; set; }

    ///<summary>
    /// Text
    ///</summary>
    string Text { get; set; }
}
