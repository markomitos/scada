using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scada.models
{
    public enum AlarmType
    {
        LOW, HIGH
    }
    public class Alarm
    {
        public AlarmType Type {  get; set; }
        public int Priority {  get; set; }
        public Double Treshold { get; set; }
        public string Unit { get; set; }

    }
}