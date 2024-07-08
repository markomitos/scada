using Scada.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Scada.interfaces;
using Scada.models;
using Scada.repositories.implementations;
using Scada.services;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using Scada.callbacks;

namespace Scada
{
    public class AlarmService : IAlarmService1
    {
        private readonly AlarmRepository _alarmRepository;
        private readonly AlarmValueRepository _alarmValueRepository;
        private readonly Dictionary<Guid, ITagServiceCallback> _callbacks = new Dictionary<Guid, ITagServiceCallback>();

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
