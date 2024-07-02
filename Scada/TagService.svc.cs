using Scada.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Scada.models;
using Scada.repositories.implementations;

namespace Scada
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TagService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TagService.svc or TagService.svc.cs at the Solution Explorer and start debugging.
    public class TagService : ITagService
    {
        private readonly TagRepository _tagRepository;
        private readonly TagValueRepository _tagValueRepository;

        public TagService()
        {
            _tagRepository = new TagRepository();
            _tagValueRepository = new TagValueRepository(new ScadaContext());
        }

        // Methods for AnalogInputTag
        public List<AnalogInputTag> GetAllAnalogInputTags()
        {
            return _tagRepository.GetAllAnalogInputTags();
        }

        public AnalogInputTag GetAnalogInputTag(string name)
        {
            return _tagRepository.GetAnalogInputTag(name);
        }

        public void AddAnalogInputTag(AnalogInputTag analogInputTag)
        {
            _tagRepository.AddAnalogInputTag(analogInputTag);
        }

        public AnalogInputTag UpdateAnalogInputTag(AnalogInputTag analogInput)
        {
            return _tagRepository.UpdateAnalogInputTag(analogInput);
        }

        // Methods for AnalogOutputTag
        public List<AnalogOutputTag> GetAllAnalogOutputTags()
        {
            return _tagRepository.GetAllAnalogOutputTags();
        }

        public AnalogOutputTag GetAnalogOutputTag(string name)
        {
            return _tagRepository.GetAnalogOutputTag(name);
        }

        public void AddAnalogOutputTag(AnalogOutputTag analogOutputTag)
        {
            _tagRepository.AddAnalogOutputTag(analogOutputTag);
        }

        public AnalogOutputTag UpdateAnalogOutputTag(AnalogOutputTag analogOutput)
        {
            return _tagRepository.UpdateAnalogOutputTag(analogOutput);
        }

        // Methods for DigitalInputTag
        public List<DigitalInputTag> GetAllDigitalInputTags()
        {
            return _tagRepository.GetAllDigitalInputTags();
        }

        public DigitalInputTag GetDigitalInputTag(string name)
        {
            return _tagRepository.GetDigitalInputTag(name);
        }

        public void AddDigitalInputTag(DigitalInputTag digitalInputTag)
        {
            _tagRepository.AddDigitalInputTag(digitalInputTag);
        }

        public DigitalInputTag UpdateDigitalInputTag(DigitalInputTag digitalInput)
        {
            return _tagRepository.UpdateDigitalInputTag(digitalInput);
        }

        // Methods for DigitalOutputTag
        public List<DigitalOutputTag> GetAllDigitalOutputTags()
        {
            return _tagRepository.GetAllDigitalOutputTags();
        }

        public DigitalOutputTag GetDigitalOutputTag(string name)
        {
            return _tagRepository.GetDigitalOutputTag(name);
        }

        public void AddDigitalOutputTag(DigitalOutputTag digitalOutputTag)
        {
            _tagRepository.AddDigitalOutputTag(digitalOutputTag);
        }

        public DigitalOutputTag UpdateDigitalOutputTag(DigitalOutputTag digitalOutput)
        {
            return _tagRepository.UpdateDigitalOutputTag(digitalOutput);
        }

        // Universal remove
        public bool RemoveTag(string name)
        {
            return _tagRepository.RemoveTag(name);
        }

        public bool IsTagNameUnique(string name)
        {
            return _tagRepository.IsTagNameUnique(name);
        }
    }
}
