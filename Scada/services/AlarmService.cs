using Scada.interfaces;
using Scada.models;
using Scada.repositories.implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scada.services
{
    public class AlarmService : IAlarmService
    {
        private readonly IAlarmRepository _alarmRepository;

        public AlarmService(IAlarmRepository alarmRepository)
        {
            _alarmRepository = alarmRepository;
        }

        private bool Authenticate(string token)
        {
            return AuthenticationService.AuthenticateToken(token);
        }

        public List<Alarm> GetAllAlarms()
        {
            return _alarmRepository.GetAllAlarms();
        }

        public List<Alarm> GetAlarmsByName(string tagName)
        {
            return _alarmRepository.GetAllAlarms()
                           .Where(alarm => alarm.TagName == tagName)
                           .ToList();
        }

        public bool AddAlarm(string token, Alarm alarm)
        {
            if (!Authenticate(token)) throw new UnauthorizedAccessException("Invalid token");
            if (_alarmRepository.AlarmExists(alarm.Name)) return false;

            _alarmRepository.AddAlarm(alarm);
            return true;
        }


        public bool RemoveAlarm(string token, string name)
        {
            if (!Authenticate(token)) throw new UnauthorizedAccessException("Invalid token");
            return _alarmRepository.RemoveAlarm(name);
        }
    }
}