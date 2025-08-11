// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Specifies when should the <a href="https://corefork.telegram.org/api/business#away-messages">Telegram Business away messages</a> be sent.
/// See <a href="https://corefork.telegram.org/constructor/BusinessAwayMessageSchedule" />
///</summary>
[JsonDerivedType(typeof(TBusinessAwayMessageScheduleAlways), nameof(TBusinessAwayMessageScheduleAlways))]
[JsonDerivedType(typeof(TBusinessAwayMessageScheduleOutsideWorkHours), nameof(TBusinessAwayMessageScheduleOutsideWorkHours))]
[JsonDerivedType(typeof(TBusinessAwayMessageScheduleCustom), nameof(TBusinessAwayMessageScheduleCustom))]
public interface IBusinessAwayMessageSchedule : IObject
{

}
