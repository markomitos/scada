using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Scada.models
{
    public class AlarmValue
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
   
        public AlarmType Type { get; set; }
      
        public int Priority { get; set; }
       
        public Double Threshold { get; set; }
      
        public string Unit { get; set; }
       
        public string TagName { get; set; }

        public double Value { get; set; }
        public DateTime Timestamp { get; set; }


        public AlarmValue(string name, 
                        AlarmType type, 
                        int priority, 
                        double threshold, 
                        string unit, 
                        string tagName, 
                        double value, 
                        DateTime timestamp)
        {
            Id= DateTime.Now.GetHashCode();
            Name=name;
            Type=type;
            Priority=priority;
            Threshold=threshold;
            Unit=unit;
            TagName=tagName;
            Value=value;
            Timestamp=timestamp;
        }
    }
}