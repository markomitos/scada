using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Scada.models;
using Scada.services;

namespace Scada.interfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITagService" in both code and config file together.
    [ServiceContract]
    public interface ITagService
    {
        // Methods for AnalogInputTag
        [OperationContract]
        List<AnalogInputTag> GetAllAnalogInputTags();

        [OperationContract]
        AnalogInputTag GetAnalogInputTag(string name);

        [OperationContract]
        void AddAnalogInputTag(AnalogInputTag analogInputTag);

        [OperationContract]
        AnalogInputTag UpdateAnalogInputTag(AnalogInputTag analogInput);


        // Methods for AnalogOutputTag
        [OperationContract]
        List<AnalogOutputTag> GetAllAnalogOutputTags();

        [OperationContract]
        AnalogOutputTag GetAnalogOutputTag(string name);

        [OperationContract]
        void AddAnalogOutputTag(AnalogOutputTag analogOutputTag);

        [OperationContract]
        AnalogOutputTag UpdateAnalogOutputTag(AnalogOutputTag analogOutput);


        // Methods for DigitalInputTag
        [OperationContract]
        List<DigitalInputTag> GetAllDigitalInputTags();

        [OperationContract]
        DigitalInputTag GetDigitalInputTag(string name);

        [OperationContract]
        void AddDigitalInputTag(DigitalInputTag digitalInputTag);

        [OperationContract]
        DigitalInputTag UpdateDigitalInputTag(DigitalInputTag digitalInput);


        // Methods for DigitalOutputTag
        [OperationContract]
        List<DigitalOutputTag> GetAllDigitalOutputTags();

        [OperationContract]
        DigitalOutputTag GetDigitalOutputTag(string name);

        [OperationContract]
        void AddDigitalOutputTag(DigitalOutputTag digitalOutputTag);

        [OperationContract]
        DigitalOutputTag UpdateDigitalOutputTag(DigitalOutputTag digitalOutput);


        // Universal remove
        [OperationContract]
        bool RemoveTag(string name);

        [OperationContract]
        bool IsTagNameUnique(string name);

        //Values
        [OperationContract]
        void AddTagValue(TagValue tagValue);
        [OperationContract]
        void RemoveTagValue(string tagValueId);
        [OperationContract]
        void UpdateTagValue(TagValue tagValue);
        [OperationContract]
        TagValue GetTagValue(string tagValueId);
        [OperationContract]
        List<TagValue> GetAllTagValues();
        [OperationContract]
        TagValue GetLastTagValue(string tagName);

        //RTU
        [OperationContract]
        double getRTUValue(string address);
        [OperationContract]
        void setRTUValue(string address, double value);
    }

}
