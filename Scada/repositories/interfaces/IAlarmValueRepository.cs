using Scada.models;
using System.Collections.Generic;

namespace Scada.repositories.implementations
{
    public interface IAlarmValueRepository
    {
        void AddAlarmValue(AlarmValue alarmValue);
        AlarmValue GetAlarmValue(string alarmValueId);
        List<AlarmValue> GetAllAlarmValues();
        void LogAlarm(AlarmValue alarm);
        void RemoveAlarmValue(string alarmValueId);
    }
}