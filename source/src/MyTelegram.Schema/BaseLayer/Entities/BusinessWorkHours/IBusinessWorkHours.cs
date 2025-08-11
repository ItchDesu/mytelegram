// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Specifies a set of <a href="https://corefork.telegram.org/api/business#opening-hours">Telegram Business opening hours</a>.
/// See <a href="https://corefork.telegram.org/constructor/BusinessWorkHours" />
///</summary>
[JsonDerivedType(typeof(TBusinessWorkHours), nameof(TBusinessWorkHours))]
public interface IBusinessWorkHours : IObject
{
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    int Flags { get; set; }

    ///<summary>
    /// Ignored if set while invoking <a href="https://corefork.telegram.org/method/account.updateBusinessWorkHours">account.updateBusinessWorkHours</a>, only returned by the server in <a href="https://corefork.telegram.org/constructor/userFull">userFull</a>.<code>business_work_hours</code>, indicating whether the business is currently open according to the current time and the values in <code>weekly_open</code> and <code>timezone</code>.
    ///</summary>
    bool OpenNow { get; set; }

    ///<summary>
    /// An ID of one of the timezones returned by <a href="https://corefork.telegram.org/method/help.getTimezonesList">help.getTimezonesList</a>.  <br>  The timezone ID is contained <a href="https://corefork.telegram.org/constructor/timezone">timezone</a>.<code>id</code>, a human-readable, localized name of the timezone is available in <a href="https://corefork.telegram.org/constructor/timezone">timezone</a>.<code>name</code> and the <a href="https://corefork.telegram.org/constructor/timezone">timezone</a>.<code>utc_offset</code> field contains the UTC offset in seconds, which may be displayed in hh:mm format by the client together with the human-readable name (i.e. <code>$name UTC -01:00</code>).
    ///</summary>
    string TimezoneId { get; set; }

    ///<summary>
    /// A list of time intervals (max 28) represented by <a href="https://corefork.telegram.org/constructor/businessWeeklyOpen">businessWeeklyOpen </a>, indicating the opening hours of their business.
    /// See <a href="https://corefork.telegram.org/type/BusinessWeeklyOpen" />
    ///</summary>
    TVector<MyTelegram.Schema.IBusinessWeeklyOpen> WeeklyOpen { get; set; }
}
