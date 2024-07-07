using System.ComponentModel.DataAnnotations;
using System;

namespace Scada.models
{
    public enum ValueType
    {
        ANALOG, DIGITAL
    }
    public class TagValue
    {
        [Key]
        public int Id { get; set; }
        public string IOAddress { get; set; }
        public string TagName { get; set; }
        public DateTime TimeStamp { get; set; }
        public double Value { get; set; }
        public ValueType ValueType { get; set; }

        public TagValue() { }

        public TagValue(string address, string tagName, double value, ValueType valueType)
        {
            IOAddress = address;
            TagName = tagName;
            TimeStamp = DateTime.Now;
            Value = value;
            ValueType = valueType;
        }

        public override string ToString()
        {
            return "TagName: " + TagName + ", Value: " + Value + ", Timestamp:" + TimeStamp;
        }
    }
}