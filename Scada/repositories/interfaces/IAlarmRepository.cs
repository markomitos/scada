using Scada.models;
using System.Collections.Generic;

namespace Scada.repositories.implementations
{
    public interface IAlarmRepository
    {
        void AddAlarm(Alarm alarm);
        List<Alarm> GetAllAlarms();
        bool RemoveAlarm(string name);
        bool AlarmExists(string name);
    }
}