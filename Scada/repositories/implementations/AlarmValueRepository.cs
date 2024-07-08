using Scada.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Scada.repositories.implementations
{
    public class AlarmValueRepository
    {
        private readonly string logFilePath = HttpContext.Current.Server.MapPath("~/AppData/alarmsLog.txt");

        public void AddAlarmValue(AlarmValue alarmValue)
        {
            using (var context = new ScadaContext())
            {
                context.AlarmValues.Add(alarmValue);
                context.SaveChanges();
            }
        }

        public void RemoveAlarmValue(string alarmValueId)
        {
            using (var context = new ScadaContext())
            {
                var alarmValue = context.AlarmValues.Find(alarmValueId);
                if (alarmValue != null)
                {
                    context.AlarmValues.Remove(alarmValue);
                    context.SaveChanges();
                }
            }
        }

        public AlarmValue GetAlarmValue(string alarmValueId)
        {
            using (var context = new ScadaContext())
            {
                return context.AlarmValues.Find(alarmValueId);
            }
        }

        public List<AlarmValue> GetAllAlarmValues()
        {
            using (var context = new ScadaContext())
            {
                return context.AlarmValues.ToList();
            }
        }

        public void LogAlarm(AlarmValue alarm)
        {
            var logMessage = $"Alarm with value triggered: Id={alarm.Id},Tag={alarm.TagName},Tag value= {alarm.Value}, Priority={alarm.Priority}, Type={alarm.Type}, Threshold={alarm.Threshold}, Timestamp={alarm.Timestamp}";
            File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
        }

    }
}