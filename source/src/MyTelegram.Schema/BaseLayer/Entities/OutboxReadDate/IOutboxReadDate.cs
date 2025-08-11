// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Exact read date of a private message we sent to another user.
/// See <a href="https://corefork.telegram.org/constructor/OutboxReadDate" />
///</summary>
[JsonDerivedType(typeof(TOutboxReadDate), nameof(TOutboxReadDate))]
public interface IOutboxReadDate : IObject
{
    ///<summary>
    /// UNIX timestamp with the read date.
    ///</summary>
    int Date { get; set; }
}
