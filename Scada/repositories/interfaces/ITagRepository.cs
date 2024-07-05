using System.Collections.Generic;
using Scada.models;

namespace Scada.repositories.interfaces
{
    public interface ITagRepository
    {
        Tag GetTag(string name);

        // Methods for AnalogInputTag
        List<AnalogInputTag> GetAllAnalogInputTags();
        AnalogInputTag GetAnalogInputTag(string name);
        void AddAnalogInputTag(AnalogInputTag analogInputTag);
        AnalogInputTag UpdateAnalogInputTag(AnalogInputTag analogInput);


        // Methods for AnalogOutputTag
        List<AnalogOutputTag> GetAllAnalogOutputTags();
        AnalogOutputTag GetAnalogOutputTag(string name);
        void AddAnalogOutputTag(AnalogOutputTag analogOutputTag);
        AnalogOutputTag UpdateAnalogOutputTag(AnalogOutputTag analogOutput);


        // Methods for DigitalInputTag
        List<DigitalInputTag> GetAllDigitalInputTags();
        DigitalInputTag GetDigitalInputTag(string name);
        void AddDigitalInputTag(DigitalInputTag digitalInputTag);
        DigitalInputTag UpdateDigitalInputTag(DigitalInputTag digitalInput);


        // Methods for DigitalOutputTag
        List<DigitalOutputTag> GetAllDigitalOutputTags();
        DigitalOutputTag GetDigitalOutputTag(string name);
        void AddDigitalOutputTag(DigitalOutputTag digitalOutputTag);
        DigitalOutputTag UpdateDigitalOutputTag(DigitalOutputTag digitalOutput);


        // Universal remove
        bool RemoveTag(string name);
    }
}