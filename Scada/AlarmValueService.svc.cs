using Scada.interfaces;
using Scada.models;
using Scada.repositories.implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Scada
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AlarmValueService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AlarmValueService.svc or AlarmValueService.svc.cs at the Solution Explorer and start debugging.
    public class AlarmValueService : IAlarmValueService
    {
        public IAlarmValueService alarmValueService;

        public void DoWork()
        {
        }

        public void SubOnAlarmDisplay()
        {
            alarmValueService.SubOnAlarmDisplay();
        }

        public void LogAlarmValue(AlarmValue alarmValue)
        {
            alarmValueService.LogAlarmValue(alarmValue);
        }
    }
}
