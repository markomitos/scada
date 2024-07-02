using System.ComponentModel.DataAnnotations;

namespace Scada.models
{
    public class OutputTag : Tag
    {
        [Required]
        public double InitialValue { get; set; }
    }
}