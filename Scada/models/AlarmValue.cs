using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace Scada.models
{
    [DataContract]
    public class AlarmValue
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public AlarmType Type { get; set; }
        [DataMember]
        public int Priority { get; set; }
        [DataMember]
        public Double Threshold { get; set; }
        [DataMember]
        public string Unit { get; set; }
        [DataMember]
        public string TagName { get; set; }
        [DataMember]
        public double Value { get; set; }
        [DataMember]
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