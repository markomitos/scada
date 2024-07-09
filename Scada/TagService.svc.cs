using Scada.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Scada.interfaces;
using Scada.models;
using Scada.repositories.implementations;
using Scada.services;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using Scada.callbacks;

namespace Scada
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class TagService : IAlarmService, ITagService,  IAlarmValueService
    {
        private readonly TagRepository _tagRepository;
        private readonly TagValueRepository _tagValueRepository;
        private readonly TagProcessing _tagProcessing;
        private readonly Dictionary<Guid,ITagServiceCallback> _callbacks = new Dictionary<Guid, ITagServiceCallback>();
        public List<IAlarmCallback> alarmCallbacks = new List<IAlarmCallback>();

        public IAlarmService alarmService;
        public IAlarmValueService alarmValueService;


        public TagService()
        {
            _tagRepository = new TagRepository();
            _tagValueRepository = new TagValueRepository();
            _tagProcessing = new TagProcessing(this);
            alarmService = new services.AlarmService(new AlarmRepository());
            alarmValueService = new services.AlarmValueService(new AlarmValueRepository());
        }

        private bool Authenticate(string token)
        {
            return AuthenticationService.AuthenticateToken(token);
        }

        public void Hello()
        { }

        public void InitTrending(Guid id)
        {
            _tagProcessing.InitTrending(id, OperationContext.Current.GetCallbackChannel<ITagServiceCallback>());
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

        public void AddAnalogInputTag(string token, AnalogInputTag analogInputTag)
        {
            if (!Authenticate(token)) throw new UnauthorizedAccessException("Invalid token");
            _tagRepository.AddAnalogInputTag(analogInputTag);
            _tagProcessing.processAnalogTag(analogInputTag);
        }

        public AnalogInputTag UpdateAnalogInputTag(string token, AnalogInputTag analogInput)
        {
            if (!Authenticate(token)) throw new UnauthorizedAccessException("Invalid token");
            var updatedTag = _tagRepository.UpdateAnalogInputTag(analogInput);
            if (!updatedTag.OnOffScan)
            {
                _tagProcessing.removeTag(updatedTag.Name);
            }
            else
            {
                _tagProcessing.processAnalogTag(updatedTag);
            }
            return updatedTag;
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

        public DigitalInputTag GetDigitalInputTag(string name)
        {
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
            var updatedTag = _tagRepository.UpdateDigitalInputTag(digitalInput);
            if (!updatedTag.OnOffScan)
            {
                _tagProcessing.removeTag(updatedTag.Name);
            }
            else
            {
                _tagProcessing.processDigitalTag(updatedTag);
            }
            return updatedTag;
            
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

        public void setRTUValue(string address, double value, string signatureBase64, string hashValueBase64)
        {
            byte[] signature = Convert.FromBase64String(signatureBase64);
            byte[] hashValue = Convert.FromBase64String(hashValueBase64);
            string message = value.ToString();

            if (verifySignature(message, signature, hashValue))
            {
                RealTimeDriver.setValue(address, value);
            }
            else
            {
                throw new Exception("Invalid signature");
            }
        }

        private bool verifySignature(string message, byte[] signature, byte[] hashValue)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] computedHash = sha.ComputeHash(Encoding.UTF8.GetBytes(message));
                if (!computedHash.SequenceEqual(hashValue))
                {
                    return false;
                }

                CspParameters csp = new CspParameters
                {
                    KeyContainerName = "KeyContainer"
                };
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(csp))
                {
                    var deformatter = new RSAPKCS1SignatureDeformatter(rsa);
                    deformatter.SetHashAlgorithm("SHA256");
                    return deformatter.VerifySignature(hashValue, signature);
                }
            }
        }

        public bool AddAlarm(string token, Alarm alarm)
        {
            return alarmService.AddAlarm(token, alarm);
        }

        public List<Alarm> GetAllAlarms()
        {
            return alarmService.GetAllAlarms();
        }

        public bool RemoveAlarm(string token, string name)
        {
            return alarmService.RemoveAlarm(token, name);
        }

        public List<Alarm> GetAlarmsByName(string tagName)
        {
            return alarmService.GetAlarmsByName(tagName);
        }

        public void DoWork()
        {
            
        }

        public void SubOnAlarmDisplay()
        {
            alarmValueService.SubOnAlarmDisplay();
        }

        public void LogAlarmValue(AlarmValue alarmValue)
        {
            alarmValueService.LogAlarmValue(alarmValue);
            
        }
    }
}
