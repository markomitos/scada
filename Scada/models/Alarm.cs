using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Scada.models
{
    public enum AlarmType
    {
        LOW, HIGH
    }
    [XmlRoot("alarm")]
    public class Alarm
    {
        [Key]
        public int Id { get; set; }
        [XmlAttribute("Name")]
        [Required]
        public string Name{ get; set; }
        [XmlAttribute("Type")]
        [Required]
        public AlarmType Type {  get; set; }
        [XmlAttribute("Priority")]
        [Required]
        public int Priority {  get; set; }
        [XmlAttribute("Treshold")]
        [Required]
        public Double Threshold { get; set; }
        [XmlAttribute("Unit")]
        [Required]
        public string Unit { get; set; }
        [XmlAttribute("TagName")]
        [Required] 
        public string TagName { get; set; }

        public override string ToString()
        {
            return $"|{"Id",-5}|{"Name",-20}|{"Type",-5}|{"Priority",-8}|{"Threshold",-10}|{"Unit",-5}|{"TagName",-20}|\n" +
                   $"|{Id,-5}|{Name,-20}|{Type,-5}|{Priority,-8}|{Threshold,-10}|{Unit,-5}|{TagName,-20}|";
        }
    }
}