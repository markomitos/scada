using Scada.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Scada.interfaces;
using Scada.models;
using Scada.repositories.implementations;
using Scada.services;

namespace Scada
{
    public class TagService : ITagService
    {
        private readonly TagRepository _tagRepository;
        private readonly TagValueRepository _tagValueRepository;
        private readonly TagProcessing _tagProcessing;

        public TagService()
        {
            _tagRepository = new TagRepository();
            _tagValueRepository = new TagValueRepository();
            _tagProcessing = new TagProcessing(this);
        }

        private bool Authenticate(string token)
        {
            return AuthenticationService.AuthenticateToken(token);
        }

        public void Hello()
        { }

        // Methods for AnalogInputTag
        public List<AnalogInputTag> GetAllAnalogInputTags()
        {
            return _tagRepository.GetAllAnalogInputTags();
        }

        public AnalogInputTag GetAnalogInputTag(string token, string name)
        {
            if (!Authenticate(token)) throw new UnauthorizedAccessException("Invalid token");
            return _tagRepository.GetAnalogInputTag(name);
        }

        public void AddAnalogInputTag(string token, AnalogInputTag analogInputTag)
        {
            if (!Authenticate(token)) throw new UnauthorizedAccessException("Invalid token");
            _tagRepository.AddAnalogInputTag(analogInputTag);
            _tagProcessing.processAnalogTag(analogInputTag);
        }

        public AnalogInputTag UpdateAnalogInputTag(string token, AnalogInputTag analogInput)
        {
            if (!Authenticate(token)) throw new UnauthorizedAccessException("Invalid token");
            return _tagRepository.UpdateAnalogInputTag(analogInput);
        }

        // Methods for AnalogOutputTag
        public List<AnalogOutputTag> GetAllAnalogOutputTags(string token)
        {
            if (!Authenticate(token)) throw new UnauthorizedAccessException("Invalid token");
            return _tagRepository.GetAllAnalogOutputTags();
        }

        public AnalogOutputTag GetAnalogOutputTag(string token, string name)
        {
            if (!Authenticate(token)) throw new UnauthorizedAccessException("Invalid token");
            return _tagRepository.GetAnalogOutputTag(name);
        }

        public void AddAnalogOutputTag(string token, AnalogOutputTag analogOutputTag)
        {
            if (!Authenticate(token)) throw new UnauthorizedAccessException("Invalid token");
            _tagRepository.AddAnalogOutputTag(analogOutputTag);
        }

        public AnalogOutputTag UpdateAnalogOutputTag(string token, AnalogOutputTag analogOutput)
        {
            if (!Authenticate(token)) throw new UnauthorizedAccessException("Invalid token");
            return _tagRepository.UpdateAnalogOutputTag(analogOutput);
        }

        // Methods for DigitalInputTag
        public List<DigitalInputTag> GetAllDigitalInputTags()
        {
            return _tagRepository.GetAllDigitalInputTags();
        }

        public DigitalInputTag GetDigitalInputTag(string token, string name)
        {
            if (!Authenticate(token)) throw new UnauthorizedAccessException("Invalid token");
            return _tagRepository.GetDigitalInputTag(name);
        }

        public void AddDigitalInputTag(string token, DigitalInputTag digitalInputTag)
        {
            if (!Authenticate(token)) throw new UnauthorizedAccessException("Invalid token");
            _tagRepository.AddDigitalInputTag(digitalInputTag);
            _tagProcessing.processDigitalTag(digitalInputTag);
        }

        public DigitalInputTag UpdateDigitalInputTag(string token, DigitalInputTag digitalInput)
        {
            if (!Authenticate(token)) throw new UnauthorizedAccessException("Invalid token");
            return _tagRepository.UpdateDigitalInputTag(digitalInput);
        }

        // Methods for DigitalOutputTag
        public List<DigitalOutputTag> GetAllDigitalOutputTags(string token)
        {
            if (!Authenticate(token)) throw new UnauthorizedAccessException("Invalid token");
            return _tagRepository.GetAllDigitalOutputTags();
        }

        public DigitalOutputTag GetDigitalOutputTag(string token, string name)
        {
            if (!Authenticate(token)) throw new UnauthorizedAccessException("Invalid token");
            return _tagRepository.GetDigitalOutputTag(name);
        }

        public void AddDigitalOutputTag(string token, DigitalOutputTag digitalOutputTag)
        {
            if (!Authenticate(token)) throw new UnauthorizedAccessException("Invalid token");
            _tagRepository.AddDigitalOutputTag(digitalOutputTag);
        }

        public DigitalOutputTag UpdateDigitalOutputTag(string token, DigitalOutputTag digitalOutput)
        {
            if (!Authenticate(token)) throw new UnauthorizedAccessException("Invalid token");
            return _tagRepository.UpdateDigitalOutputTag(digitalOutput);
        }

        // Universal remove
        public bool RemoveTag(string token, string name)
        {
            if (!Authenticate(token)) throw new UnauthorizedAccessException("Invalid token");
            _tagProcessing.removeTag(name);
            return _tagRepository.RemoveTag(name);
        }

        public bool IsTagNameUnique(string token, string name)
        {
            if (!Authenticate(token)) throw new UnauthorizedAccessException("Invalid token");
            return _tagRepository.IsTagNameUnique(name);
        }

        // VALUES
        public void AddTagValue(TagValue tagValue)
        {
            _tagValueRepository.AddTagValue(tagValue);
        }

        public void RemoveTagValue(string token, string tagValueId)
        {
            if (!Authenticate(token)) throw new UnauthorizedAccessException("Invalid token");
            _tagValueRepository.RemoveTagValue(tagValueId);
        }

        public void UpdateTagValue(string token, TagValue tagValue)
        {
            if (!Authenticate(token)) throw new UnauthorizedAccessException("Invalid token");
            _tagValueRepository.UpdateTagValue(tagValue);
        }

        public TagValue GetTagValue(string token, string tagValueId)
        {
            if (!Authenticate(token)) throw new UnauthorizedAccessException("Invalid token");
            return _tagValueRepository.GetTagValue(tagValueId);
        }

        public List<TagValue> GetAllTagValues(string token)
        {
            if (!Authenticate(token)) throw new UnauthorizedAccessException("Invalid token");
            return _tagValueRepository.GetAllTagValues();
        }

        public TagValue GetLastTagValue(string token, string tagName)
        {
            if (!Authenticate(token)) throw new UnauthorizedAccessException("Invalid token");
            return _tagValueRepository.GetLastTagValue(tagName);
        }

        // RTU
        public double getRTUValue(string address)
        {
            return RealTimeDriver.getValue(address);
        }

        public void setRTUValue(string address, double value)
        {
            RealTimeDriver.setValue(address, value);
        }
    }
}
