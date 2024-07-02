using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

[XmlInclude(typeof(AnalogInputTag))]
[XmlInclude(typeof(DigitalInputTag))]
[XmlInclude(typeof(AnalogOutputTag))]
[XmlInclude(typeof(DigitalOutputTag))]
public abstract class Tag
{
    [Key]
    public int Id { get; set; }

    [XmlAttribute("Name")]
    [Required]
    public string Name { get; set; }

    [XmlAttribute("Description")]
    [Required]
    public string Description { get; set; }

    [XmlAttribute("IoAddress")]
    [Required]
    public string IoAddress { get; set; }
}