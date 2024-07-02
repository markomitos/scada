using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Scada.models
{
    public class OutputTag : Tag
    {
        [XmlAttribute("InitialValue")]
        [Required]
        public double InitialValue { get; set; }
    }
}
