using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

public abstract class InputTag : Tag
{
    [XmlAttribute("Driver")]
    [Required] public string Driver { get; set; }

    [XmlAttribute("ScanTime")]
    [Required] public int ScanTime { get; set; }

    [XmlAttribute("OnOffScan")]
    [Required] public bool OnOffScan { get; set; }
}