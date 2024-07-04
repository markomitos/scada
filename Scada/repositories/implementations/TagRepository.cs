using Scada.repositories.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using Scada.models;

namespace Scada.repositories.implementations
{
    public class TagRepository : ITagRepository
    {
        private List<Tag> tags = new List<Tag>();
        private string file = HttpContext.Current.Server.MapPath("~/Resources/tags.xml");

        public TagRepository()
        {
            LoadTags();
        }

        public Tag GetTag(string name)
        {
            return tags.FirstOrDefault(tag => tag.Name == name);
        }

        // Methods for AnalogInputTag
        public List<AnalogInputTag> GetAllAnalogInputTags()
        {
            return tags.OfType<AnalogInputTag>().ToList();
        }
        public AnalogInputTag GetAnalogInputTag(string name)
        {
            return tags.FirstOrDefault(tag => tag.Name == name) as AnalogInputTag;
        }

        public void AddAnalogInputTag(AnalogInputTag analogInputTag)
        {
            tags.Add(analogInputTag);
            SaveTags();
        }

        public AnalogInputTag UpdateAnalogInputTag(AnalogInputTag analogInput)
        {
            AnalogInputTag existingAnalogInputTag = (AnalogInputTag)tags.FirstOrDefault(tag => tag.Name == analogInput.Name);

            if (existingAnalogInputTag != null)
            {
                existingAnalogInputTag.Description = analogInput.Description;
                existingAnalogInputTag.IoAddress = analogInput.IoAddress;
                existingAnalogInputTag.ScanTime = analogInput.ScanTime;
                existingAnalogInputTag.Alarms = analogInput.Alarms;
                existingAnalogInputTag.OnOffScan = analogInput.OnOffScan;
                existingAnalogInputTag.LowLimit = analogInput.LowLimit;
                existingAnalogInputTag.HighLimit = analogInput.HighLimit;
                existingAnalogInputTag.Units = analogInput.Units;
                existingAnalogInputTag.Driver = analogInput.Driver;

                SaveTags();

                return existingAnalogInputTag;
            }

            return null;
        }

        // Methods for AnalogOutputTag
        public List<AnalogOutputTag> GetAllAnalogOutputTags()
        {
            return tags.OfType<AnalogOutputTag>().ToList();
        }

        public AnalogOutputTag GetAnalogOutputTag(string name)
        {
            return tags.FirstOrDefault(tag => tag.Name == name) as AnalogOutputTag;
        }

        public void AddAnalogOutputTag(AnalogOutputTag analogOutputTag)
        {
            tags.Add(analogOutputTag);
            SaveTags();
        }

        public AnalogOutputTag UpdateAnalogOutputTag(AnalogOutputTag analogOutput)
        {
            AnalogOutputTag existingAnalogOutputTag = tags.FirstOrDefault(tag => tag.Name == analogOutput.Name) as AnalogOutputTag;

            if (existingAnalogOutputTag != null)
            {
                existingAnalogOutputTag.Description = analogOutput.Description;
                existingAnalogOutputTag.IoAddress = analogOutput.IoAddress;
                existingAnalogOutputTag.InitialValue = analogOutput.InitialValue;
                existingAnalogOutputTag.LowLimit = analogOutput.LowLimit;
                existingAnalogOutputTag.HighLimit = analogOutput.HighLimit;
                existingAnalogOutputTag.Units = analogOutput.Units;

                SaveTags();

                return existingAnalogOutputTag;
            }

            return null;
        }

        // Methods for DigitalInputTag
        public List<DigitalInputTag> GetAllDigitalInputTags()
        {
            return tags.OfType<DigitalInputTag>().ToList();
        }

        public DigitalInputTag GetDigitalInputTag(string name)
        {
            return tags.FirstOrDefault(tag => tag.Name == name) as DigitalInputTag;
        }

        public void AddDigitalInputTag(DigitalInputTag digitalInputTag)
        {
            tags.Add(digitalInputTag);
            SaveTags();
        }

        public DigitalInputTag UpdateDigitalInputTag(DigitalInputTag digitalInput)
        {
            DigitalInputTag existingDigitalInputTag = tags.FirstOrDefault(tag => tag.Name == digitalInput.Name) as DigitalInputTag;

            if (existingDigitalInputTag != null)
            {
                existingDigitalInputTag.Description = digitalInput.Description;
                existingDigitalInputTag.IoAddress = digitalInput.IoAddress;
                existingDigitalInputTag.ScanTime = digitalInput.ScanTime;
                existingDigitalInputTag.OnOffScan = digitalInput.OnOffScan;
                existingDigitalInputTag.Driver = digitalInput.Driver;

                SaveTags();

                return existingDigitalInputTag;
            }

            return null;
        }

        // Methods for DigitalOutputTag
        public List<DigitalOutputTag> GetAllDigitalOutputTags()
        {
            return tags.OfType<DigitalOutputTag>().ToList();
        }

        public DigitalOutputTag GetDigitalOutputTag(string name)
        {
            return tags.FirstOrDefault(tag => tag.Name == name) as DigitalOutputTag;
        }

        public void AddDigitalOutputTag(DigitalOutputTag digitalOutputTag)
        {
            tags.Add(digitalOutputTag);
            SaveTags();
        }

        public DigitalOutputTag UpdateDigitalOutputTag(DigitalOutputTag digitalOutput)
        {
            DigitalOutputTag existingDigitalOutputTag = tags.FirstOrDefault(tag => tag.Name == digitalOutput.Name) as DigitalOutputTag;

            if (existingDigitalOutputTag != null)
            {
                existingDigitalOutputTag.Description = digitalOutput.Description;
                existingDigitalOutputTag.IoAddress = digitalOutput.IoAddress;
                existingDigitalOutputTag.InitialValue = digitalOutput.InitialValue;

                SaveTags();

                return existingDigitalOutputTag;
            }

            return null;
        }

        //Universal remove
        public bool RemoveTag(string name)
        {
            Tag tagToRemove = tags.FirstOrDefault(tag => tag.Name == name);

            if (tagToRemove != null)
            {
                tags.Remove(tagToRemove);
                SaveTags();
                return true;
            }

            return false;
        }


        public bool IsTagNameUnique(string name)
        {
            Tag result = tags.FirstOrDefault(tag => tag.Name == name);
            return result == null;
        }


        private void LoadTags()
        {
            if (File.Exists(file))
            {
                try
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Tag>), new XmlRootAttribute("Tags"));
                    using (FileStream fs = new FileStream(file, FileMode.Open))
                    {
                        tags = (List<Tag>)xmlSerializer.Deserialize(fs);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while loading: " + ex.Message);
                }
            }
        }
        private void SaveTags()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Tag>), new XmlRootAttribute("Tags"));
                using (TextWriter writer = new StreamWriter(file))
                {
                    xmlSerializer.Serialize(writer, tags);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while saving: " + ex.Message);
            }
        }
    }
}