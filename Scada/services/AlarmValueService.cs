using Scada.interfaces;
using Scada.models;
using Scada.repositories.implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Web;

namespace Scada.services
{
    public class AlarmValueService : IAlarmValueService
    {
        private readonly IAlarmValueRepository _alarmValueRepository;
        public List<IAlarmCallback> alarmCallbacks = new List<IAlarmCallback>();

        public AlarmValueService(IAlarmValueRepository alarmValueRepository)
        {
            _alarmValueRepository = alarmValueRepository;
        }


        public void DoWork()
        {
        }
        public void SubOnAlarmDisplay()
        {
            var alarmCallback = OperationContext.Current.GetCallbackChannel<IAlarmCallback>();
            alarmCallbacks.Add(alarmCallback);
        }

        public void LogAlarmValue(AlarmValue alarmValue)
        {
            _alarmValueRepository.LogAlarm(alarmValue);
            _alarmValueRepository.AddAlarmValue(alarmValue);

            List<IAlarmCallback> activeCallbacks = new List<IAlarmCallback>();
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= alarmValue.Priority; i++)
            {
                sb.AppendLine($"Alarm has been triggered: \n {alarmValue.ToString()}\n");
            }
            string message = sb.ToString();
            foreach (var callback in alarmCallbacks)
            {
                try
                {
                    callback.NotifyAlarmTriggered(message);
                    activeCallbacks.Add(callback);
                }
                catch (Exception) { }
            }
            alarmCallbacks = activeCallbacks;
        }
    }
}