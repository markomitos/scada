using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using Scada.interfaces;
using Scada.models;
using Scada.callbacks;
using System.Numerics;
using Google.Protobuf.WellKnownTypes;
using System.Web.ApplicationServices;
using System.Web;

namespace Scada.services
{
    public class TagProcessing
    {
        private static Dictionary<string, CancellationTokenSource> processingTags = new Dictionary<string, CancellationTokenSource>();
        private readonly object _lockObject = new object();
        private readonly object _lockObjectDict = new object();
        private readonly object _lockObjectCallback = new object();
        private readonly ITagService _tagService;
        private readonly Dictionary<Guid,ITagServiceCallback> _callbacks = new Dictionary<Guid, ITagServiceCallback>();

        public TagProcessing(ITagService tagService)
        {
            _tagService = tagService;
            StartProcessing();
        }

        public void InitTrending(Guid id, ITagServiceCallback callback)
        {
            
            lock (_lockObjectCallback)
            {
                _callbacks[id] = callback;
            }
        }

        public void NotifyCallbacks(TagValue tagValue)
        {
            lock (_lockObjectCallback)
            {
                foreach (var callback in _callbacks.Values)
                {
                    callback.NotifyValueChanged(tagValue);
                }
            }
        }

        private void processAnalogInputs(object t)
        {
            AnalogInputTag tag = (AnalogInputTag)t;
            CancellationToken cancellationToken = processingTags[tag.Name].Token;

            while (!cancellationToken.IsCancellationRequested)
            {
                double value = 0;
                tag = _tagService.GetAnalogInputTag(tag.Name);

                if (!tag.OnOffScan)
                {
                    lock (_lockObjectDict)
                    {
                        if (processingTags.ContainsKey(tag.Name))
                        {
                            processingTags[tag.Name].Cancel();
                            processingTags.Remove(tag.Name);
                        }
                    }
                    break;
                }

                switch (tag.Driver)
                {
                    case "SIM":
                        value = SimulationDriver.SimulationDriver.ReturnValue(tag.IoAddress);
                        break;
                    case "RTD":
                        value = _tagService.getRTUValue(tag.IoAddress);
                        break;
                    default:
                        break;
                }

                if (value == double.NegativeInfinity)
                {
                    Thread.Sleep((int)tag.ScanTime);
                    continue;
                }

                if (value > tag.HighLimit)
                {
                    value = tag.HighLimit;
                }
                else if (value < tag.LowLimit)
                {
                    value = tag.LowLimit;
                }

                TagValue tagValue = new TagValue(tag.IoAddress, tag.Name, value, Scada.models.ValueType.ANALOG);
                lock (_lockObject)
                {
                    _tagService.AddTagValue(tagValue);
                    NotifyCallbacks(tagValue);
                    checkAlarms(value, tag.Name);
                }

                Thread.Sleep((int)tag.ScanTime);
            }
        }

        private void checkAlarms(double tagValue, string tagName)
        {
            if (HttpContext.Current == null)
            {
                return;
            }
            AlarmValueService alarmValueService = new AlarmValueService();
            AlarmService alarmService = new AlarmService();

            List<Alarm> tagsAlarms = alarmService.GetAlarmsByName(tagName);

            if (tagsAlarms == null) return;

            foreach (Alarm a in tagsAlarms)
            {
                if (tagValue > a.Threshold)
                {
                    alarmValueService.LogAlarmValue(new AlarmValue(a.Name, a.Type, a.Priority, a.Threshold, a.Unit, tagName, tagValue, DateTime.Now));
                }
            }
        }

        private void processDigitalInputs(object t)
        {
            DigitalInputTag tag = (DigitalInputTag)t;
            CancellationToken cancellationToken = processingTags[tag.Name].Token;

            while (!cancellationToken.IsCancellationRequested)
            {
                double value = 0;
                tag = _tagService.GetDigitalInputTag(tag.Name);

                if (!tag.OnOffScan)
                {
                    lock (_lockObjectDict)
                    {
                        if (processingTags.ContainsKey(tag.Name))
                        {
                            processingTags[tag.Name].Cancel();
                            processingTags.Remove(tag.Name);
                        }
                    }
                    break;
                }

                switch (tag.Driver)
                {
                    case "SIM":
                        value = SimulationDriver.SimulationDriver.ReturnValue(tag.IoAddress);
                        break;
                    case "RTD":
                        value = _tagService.getRTUValue(tag.IoAddress);
                        break;
                    default:
                        break;
                }

                if (value == double.NegativeInfinity)
                {
                    Thread.Sleep((int)tag.ScanTime);
                    continue;
                }

                value = value <= 0 ? 0 : 1;

                TagValue tagValue = new TagValue(tag.IoAddress, tag.Name, value, Scada.models.ValueType.DIGITAL);
                lock (_lockObject)
                {
                    _tagService.AddTagValue(tagValue);
                    NotifyCallbacks(tagValue);
                }

                Thread.Sleep((int)tag.ScanTime);
            }
        }


        public void StartProcessing()
        {
            var analogInputTags = _tagService.GetAllAnalogInputTags();
            var digitalInputTags = _tagService.GetAllDigitalInputTags();

            foreach (AnalogInputTag tag in analogInputTags)
            {
                if (!processingTags.ContainsKey(tag.Name))
                {
                    CancellationTokenSource cts = new CancellationTokenSource();
                    lock (_lockObjectDict)
                    {
                        processingTags.Add(tag.Name, cts);
                    }

                    Thread thread = new Thread(processAnalogInputs);
                    thread.Start(tag);
                }
            }

            foreach (DigitalInputTag tag in digitalInputTags)
            {
                if (!processingTags.ContainsKey(tag.Name))
                {
                    CancellationTokenSource cts = new CancellationTokenSource();
                    lock (_lockObjectDict)
                    {
                        processingTags.Add(tag.Name, cts);
                    }

                    Thread thread = new Thread(processDigitalInputs);
                    thread.Start(tag);
                }
            }
        }

        public void processAnalogTag(AnalogInputTag tag)
        {
            if (!processingTags.ContainsKey(tag.Name))
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                lock (_lockObjectDict)
                {
                    processingTags.Add(tag.Name, cts);
                }

                Thread thread = new Thread(processAnalogInputs);
                thread.Start(tag);
            }
        }

        public void processDigitalTag(DigitalInputTag tag)
        {
            if (!processingTags.ContainsKey(tag.Name))
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                lock (_lockObjectDict)
                {
                    processingTags.Add(tag.Name, cts);
                }

                Thread thread = new Thread(processDigitalInputs);
                thread.Start(tag);
            }
        }

        public void removeTag(string tagName)
        {
            if (processingTags.ContainsKey(tagName))
            {
                lock (_lockObjectDict)
                {
                    processingTags[tagName].Cancel();
                    processingTags.Remove(tagName);
                }
            }
        }
    }
}
