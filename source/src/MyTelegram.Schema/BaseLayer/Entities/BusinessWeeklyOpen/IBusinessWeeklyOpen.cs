// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// A time interval, indicating the opening hours of a <a href="https://corefork.telegram.org/api/business#opening-hours">Telegram Business</a>.
/// See <a href="https://corefork.telegram.org/constructor/BusinessWeeklyOpen" />
///</summary>
[JsonDerivedType(typeof(TBusinessWeeklyOpen), nameof(TBusinessWeeklyOpen))]
public interface IBusinessWeeklyOpen : IObject
{
    ///<summary>
    /// Start minute in minutes of the week, <code>0</code> to <code>7*24*60</code> inclusively.
    ///</summary>
    int StartMinute { get; set; }

    ///<summary>
    /// End minute in minutes of the week, <code>1</code> to <code>8*24*60</code> inclusively (<code>8</code> and not <code>7</code> because this allows to specify intervals that, for example, start on <code>Sunday 21:00</code> and end on <code>Monday 04:00</code> (<code>6*24*60+21*60</code> to <code>7*24*60+4*60</code>) without passing an invalid <code>end_minute &lt; start_minute</code>). See <a href="https://corefork.telegram.org/api/business#opening-hours">here </a> for more info.
    ///</summary>
    int EndMinute { get; set; }
}
