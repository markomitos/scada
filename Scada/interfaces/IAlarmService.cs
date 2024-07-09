using Scada.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Scada.interfaces
{
    [ServiceContract]
    public interface IAlarmService
    {
        [OperationContract]
        void AddAlarm(string token, Alarm alarm);
        [OperationContract]
        List<Alarm> GetAllAlarms();
        [OperationContract]
        bool RemoveAlarm(string token, string name);
    }
}
