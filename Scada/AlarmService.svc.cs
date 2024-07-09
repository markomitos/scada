using Scada.callbacks;
using Scada.interfaces;
using Scada.models;
using Scada.repositories.implementations;
using Scada.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.ServiceModel;
using System.Text;

namespace Scada
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AlarmService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AlarmService.svc or AlarmService.svc.cs at the Solution Explorer and start debugging.
    public class AlarmService : IAlarmService
    {
        public IAlarmService alarmService;

        public AlarmService()
        {
            alarmService = new services.AlarmService(new AlarmRepository());
        }

        public List<Alarm> GetAllAlarms()
        {
            return alarmService.GetAllAlarms();
        }

        public List<Alarm> GetAlarmsByName(string tagName)
        {
            return alarmService.GetAlarmsByName(tagName);
        }

        public void AddAlarm(string token, Alarm alarm)
        {
            alarmService.AddAlarm(token, alarm);
        }


        public bool RemoveAlarm(string token, string name)
        {
            return alarmService.RemoveAlarm(token, name);
        }
        

        
    }
}
