
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

[XmlRoot("analogOutput")]
public class AnalogOutputTag : OutputTag
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
}