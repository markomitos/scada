using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Scada.models
{
    [XmlRoot("analogInput")]
    public class AnalogInputTag : InputTag
    {
        [XmlAttribute("LowLimit")]
        [Required]
        public double LowLimit { get; set; }

        [XmlAttribute("HighLimit")]
        [Required]
        public double HighLimit { get; set; }

        [XmlAttribute("Units")]
        [Required]
        public string Units { get; set; }

        [XmlElement("Alarm")]
        [Required]
        public bool Alarms { get; set; }
    }
}
