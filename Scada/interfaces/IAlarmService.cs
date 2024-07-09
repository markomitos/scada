using Scada.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Scada.interfaces
{
    public interface IAlarmCallback
    {
        [OperationContract(IsOneWay = true)]
        void NotifyAlarmTriggered(string message);
    }

    [ServiceContract(CallbackContract = typeof(IAlarmCallback))]
    public interface IAlarmService
    {
        [OperationContract]
        void AddAlarm(string token, Alarm alarm);
        [OperationContract]
        List<Alarm> GetAllAlarms();
        [OperationContract]
        bool RemoveAlarm(string token, string name);
        [OperationContract]
        List<Alarm> GetAlarmsByName(string tagName);
        [OperationContract]
        void LogAlarmValue(AlarmValue alarmValue);
    }
}
