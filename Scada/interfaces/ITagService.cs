using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Scada.callbacks;
using Scada.models;
using Scada.services;

namespace Scada.interfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITagService" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(ITagServiceCallback))]
    public interface ITagService
    {
        [OperationContract]
        void Hello();

        [OperationContract]
        void InitTrending(Guid id);

        // Methods for AnalogInputTag
        [OperationContract]
        List<AnalogInputTag> GetAllAnalogInputTags();

        [OperationContract]
        AnalogInputTag GetAnalogInputTag(string name);

        [OperationContract]
        void AddAnalogInputTag(string token, AnalogInputTag analogInputTag);

        [OperationContract]
        AnalogInputTag UpdateAnalogInputTag(string token, AnalogInputTag analogInput);


        // Methods for AnalogOutputTag
        [OperationContract]
        List<AnalogOutputTag> GetAllAnalogOutputTags(string token);

        [OperationContract]
        AnalogOutputTag GetAnalogOutputTag(string token, string name);

        [OperationContract]
        void AddAnalogOutputTag(string token, AnalogOutputTag analogOutputTag);

        [OperationContract]
        AnalogOutputTag UpdateAnalogOutputTag(string token, AnalogOutputTag analogOutput);


        // Methods for DigitalInputTag
        [OperationContract]
        List<DigitalInputTag> GetAllDigitalInputTags();

        [OperationContract]
        DigitalInputTag GetDigitalInputTag(string name);

        [OperationContract]
        void AddDigitalInputTag(string token, DigitalInputTag digitalInputTag);

        [OperationContract]
        DigitalInputTag UpdateDigitalInputTag(string token, DigitalInputTag digitalInput);


        // Methods for DigitalOutputTag
        [OperationContract]
        List<DigitalOutputTag> GetAllDigitalOutputTags(string token);

        [OperationContract]
        DigitalOutputTag GetDigitalOutputTag(string token, string name);

        [OperationContract]
        void AddDigitalOutputTag(string token, DigitalOutputTag digitalOutputTag);

        [OperationContract]
        DigitalOutputTag UpdateDigitalOutputTag(string token, DigitalOutputTag digitalOutput);


        // Universal remove
        [OperationContract]
        bool RemoveTag(string token, string name);

        [OperationContract]
        bool IsTagNameUnique(string token, string name);

        // Values
        [OperationContract]
        void AddTagValue(TagValue tagValue);

        [OperationContract]
        void RemoveTagValue(string token, string tagValueId);

        [OperationContract]
        void UpdateTagValue(string token, TagValue tagValue);

        [OperationContract]
        TagValue GetTagValue(string token, string tagValueId);

        [OperationContract]
        List<TagValue> GetAllTagValues(string token);

        [OperationContract]
        TagValue GetLastTagValue(string token, string tagName);

        // RTU
        [OperationContract]
        double getRTUValue(string address);

        [OperationContract]
        void setRTUValue(string address, double value, string signatureBase64, string hashValueBase64);

    }
}
