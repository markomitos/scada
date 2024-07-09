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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAlarmValueService" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IAlarmCallback))]
    public interface IAlarmValueService
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        void SubOnAlarmDisplay();
        [OperationContract]
        void LogAlarmValue(AlarmValue alarmValue);

    }
}
