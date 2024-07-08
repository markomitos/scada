using Scada.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Scada.repositories.implementations
{
    public class AlarmRepository
    {
        private List<Alarm> alarms = new List<Alarm>();
        private string file = HttpContext.Current.Server.MapPath("~/Resources/alarmConfig.xml");

        public AlarmRepository() 
        {
            LoadAlarms();
        }

        private void LoadAlarms()
        {
            if (File.Exists(file))
            {
                try
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Alarm>), new XmlRootAttribute("Alarms"));
                    using (FileStream fs = new FileStream(file, FileMode.Open))
                    {
                        alarms = (List<Alarm>)xmlSerializer.Deserialize(fs);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while loading: " + ex.Message);
                }
            }
        }

        public void AddAlarm(Alarm alarm)
        {
            alarms.Add(alarm);
            Save();
        }

        public List<Alarm> GetAllAlarms()
        {
            return alarms;
        }

        public bool RemoveAlarm (string name)
        {
            Alarm alarmToRemove = alarms.FirstOrDefault(alarm => alarm.Name == name);

            if (alarmToRemove != null)
            {
                alarms.Remove(alarmToRemove);
                Save();
                return true;
            }

            return false;
        }

        private void Save()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Alarm>), new XmlRootAttribute("Alarms"));
                using (TextWriter writer = new StreamWriter(file))
                {
                    xmlSerializer.Serialize(writer, alarms);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while saving: " + ex.Message);
            }
        }
    }
}