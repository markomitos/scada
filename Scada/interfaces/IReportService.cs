using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Scada.interfaces
{
    [ServiceContract]
    public interface IReportService
    {
        [OperationContract]
        string ShowAllAlarmsInTimePeriod(DateTime startTime, DateTime endTime, bool sortByPriority);

        [OperationContract]
        string ShowAlarmsByPriority(int priority);

        [OperationContract]
        string ShowTagValuesInTimePeriod(DateTime startTime, DateTime endTime);

        [OperationContract]
        string ShowLastValuesOfAITags();

        [OperationContract]
        string ShowLastValuesOfDITags();

        [OperationContract]
        string ShowValuesOfTagById(string tagId);
    }
}
