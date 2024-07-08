﻿using System;
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
        public Double Treshold { get; set; }
        [XmlAttribute("Unit")]
        [Required]
        public string Unit { get; set; }
        [XmlAttribute("TagName")]
        [Required] 
        public int TagName { get; set; }

    }
}