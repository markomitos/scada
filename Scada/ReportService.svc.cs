using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Scada.interfaces;
using Scada.models;
using Scada.repositories.implementations;
using Scada.repositories.interfaces;

namespace Scada
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ReportService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ReportService.svc or ReportService.svc.cs at the Solution Explorer and start debugging.
    public class ReportService : IReportService
    {
        private readonly TagValueRepository _tagValueRepository = new TagValueRepository();

        public string ShowAllAlarmsInTimePeriod(DateTime startTime, DateTime endTime)
        {
            return "TODO";
        }

        public string ShowAlarmsByPriority(int priority)
        {
            return "TODO";
        }

        public string ShowTagValuesInTimePeriod(DateTime startTime, DateTime endTime)
        {
            List<TagValue> tags = _tagValueRepository.GetAllTagValuesWithinTimeFrame(startTime, endTime);
            StringBuilder builder = new StringBuilder();
            foreach (TagValue tagValue in tags)
            {
                builder.Append("--------------------------------------------------------------------\n");
                builder.Append(tagValue.ToString());
                builder.Append("\n");
            }

            return builder.ToString();
        }

        public string ShowLastValuesOfAITags()
        {
            List<TagValue> tags = _tagValueRepository.GetAllLatestAnalogTagValues();
            StringBuilder builder = new StringBuilder();
            foreach (TagValue tagValue in tags)
            {
                builder.Append("--------------------------------------------------------------------\n");
                builder.Append(tagValue.ToString());
                builder.Append("\n");
            }

            return builder.ToString();
        }

        public string ShowLastValuesOfDITags()
        {
            List<TagValue> tags = _tagValueRepository.GetAllLatestDigitalTagValues();
            StringBuilder builder = new StringBuilder();
            foreach (TagValue tagValue in tags)
            {
                builder.Append("--------------------------------------------------------------------\n");
                builder.Append(tagValue.ToString());
                builder.Append("\n");
            }

            return builder.ToString();
        }

        public string ShowValuesOfTagById(string tagId)
        {
            List<TagValue> tags = _tagValueRepository.GetTagValues(tagId);
            StringBuilder builder = new StringBuilder();
            foreach (TagValue tagValue in tags)
            {
                builder.Append("--------------------------------------------------------------------\n");
                builder.Append(tagValue.ToString());
                builder.Append("\n");
            }

            return builder.ToString();
        }
    }
}
