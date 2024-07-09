using Scada.callbacks;
using Scada.interfaces;
using Scada.models;
using Scada.repositories.implementations;
using Scada.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Scada
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AlarmService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AlarmService.svc or AlarmService.svc.cs at the Solution Explorer and start debugging.
    public class AlarmService : IAlarmService
    {
        private readonly AlarmRepository _alarmRepository;
        private readonly AlarmValueRepository _alarmValueRepository;

        public AlarmService()
        {
            _alarmRepository = new AlarmRepository();
            _alarmValueRepository = new AlarmValueRepository();
        }

        private bool Authenticate(string token)
        {
            return AuthenticationService.AuthenticateToken(token);
        }

        public List<Alarm> GetAllAlarms()
        {
            return _alarmRepository.GetAllAlarms();
        }

        public void AddAlarm(string token, Alarm alarm)
        {
            if (!Authenticate(token)) throw new UnauthorizedAccessException("Invalid token");
            _alarmRepository.AddAlarm(alarm);
        }


        public bool RemoveAlarm(string token, string name)
        {
            if (!Authenticate(token)) throw new UnauthorizedAccessException("Invalid token");
            return _alarmRepository.RemoveAlarm(name);
        }



    }
}
