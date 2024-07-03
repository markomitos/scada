using System;
using System.Collections.Generic;
using System.Threading;
using System.Web.ApplicationServices;
using Scada.models;
using ValueType = Scada.models.ValueType;

namespace Scada.services
{
    public class TagProcessing
    {
        public static Dictionary<string, Thread> processingTags = new Dictionary<string, Thread>();
        private readonly object _lockObject = new object();
        private readonly ITagService _tagService;
        public TagProcessing(ITagService tagService)
        {
            this._tagService = tagService;
            StartProcessing();
        }

        public void processAnalogInputs(Object t)
        {
            AnalogInputTag tag = (AnalogInputTag)t;
            while (true)
            {
                double value = 0;

                if (!tag.OnOffScan)
                {
                    processingTags.Remove(tag.Name);
                    break;
                }

                if (tag.Driver.Equals("SIM"))
                {
                    value = SimulationDriver.SimulationDriver.ReturnValue(tag.IoAddress);
                }
                //else if (tag.Driver.Equals("RTD"))
                //{
                //    value = coreService.GetRealTimeUnitValue(tag.IOAddress);
                //    if (value == Double.NegativeInfinity)
                //    {
                //        Thread.Sleep((int)tag.ScanTime);
                //        continue;
                //    }
                //}
                else
                {
                    break;
                }

                if (value > tag.HighLimit)
                {
                    value = tag.HighLimit;
                }
                else if (value < tag.LowLimit)
                {
                    value = tag.LowLimit;
                }

                TagValue tagValue = new TagValue(tag.IoAddress, tag.Name, value, ValueType.ANALOG);
                lock (_lockObject)
                {
                    _tagService.AddTagValue(tagValue);
                    //processAlarms(value, tag.Alarms, tag.TagName);

                    //Ovo sluzi da se posalje poruka na callback kanal kako bi se u trending aplikaciji printovala izmerena vrednost
                    //_trendingService.addTagValue(tagValue);
                }

                Thread.Sleep((int)tag.ScanTime);
            }
        }

        public void processDigitalInputs(Object t)
        {
            DigitalInputTag tag = (DigitalInputTag)t;
            while (true)
            {
                double value = 0;

                if (!tag.OnOffScan)
                {
                    processingTags.Remove(tag.Name);
                    break;
                }

                if (tag.Driver.Equals("SIM"))
                {
                    value = SimulationDriver.SimulationDriver.ReturnValue(tag.IoAddress);
                }
                //else if (tag.Driver.Equals("RTD"))
                //{
                //    value = coreService.GetRealTimeUnitValue(tag.IOAddress);
                //    if (value == Double.NegativeInfinity)
                //    {
                //        Thread.Sleep((int)tag.ScanTime);
                //        continue;
                //    }
                //}
                else
                {
                    break;
                }

                value = value <= 0 ? 0 : 1;

                TagValue tagValue = new TagValue(tag.IoAddress, tag.Name, value, ValueType.DIGITAL);
                lock (_lockObject)
                {
                    _tagService.AddTagValue(tagValue);

                    //Ovo sluzi da se posalje poruka na callback kanal kako bi se u trending aplikaciji printovala izmerena vrednost
                    //_trendingService.addTagValue(tagValue);
                }

                Thread.Sleep((int)tag.ScanTime);
            }
        }

        public void StartProcessing()
        {
            List<AnalogInputTag> analogInputTags = _tagService.GetAllAnalogInputTags();
            List<DigitalInputTag> digitalInputTags = _tagService.GetAllDigitalInputTags();

            foreach (AnalogInputTag tag in analogInputTags)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(processAnalogInputs));
                thread.Start(tag);

                if (!processingTags.ContainsKey(tag.Name))
                {
                    processingTags.Add(tag.Name, thread);
                }
            }

            foreach (DigitalInputTag tag in digitalInputTags)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(processDigitalInputs));
                thread.Start(tag);

                if (!processingTags.ContainsKey(tag.Name))
                {
                    processingTags.Add(tag.Name, thread);
                }
            }
        }

        public void processAnalogTag(AnalogInputTag tag)
        {
            if (!processingTags.ContainsKey(tag.Name))
            {
                Thread thread = new Thread(new ParameterizedThreadStart(processAnalogInputs));
                thread.Start(tag);

                if (!processingTags.ContainsKey(tag.Name))
                {
                    processingTags.Add(tag.Name, thread);
                }
            }
        }

        public void processDigitalTag(DigitalInputTag tag)
        {
            if (!processingTags.ContainsKey(tag.Name))
            {
                Thread thread = new Thread(new ParameterizedThreadStart(processDigitalInputs));
                thread.Start(tag);

                if (!processingTags.ContainsKey(tag.Name))
                {
                    processingTags.Add(tag.Name, thread);
                }
            }
        }
    }
}