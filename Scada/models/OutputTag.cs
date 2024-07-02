using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

public class OutputTag: Tag
{
    [XmlAttribute("InitialValue")]
    [Required]
    public double InitialValue { get; set; }
}