using System.ComponentModel.DataAnnotations;

namespace Scada.models
{
    public class AnalogInputTag : InputTag
    {
        [Required]
        public double LowLimit { get; set; }

        [Required]
        public double HighLimit { get; set; }

        [Required]
        public string Units { get; set; }

        [Required]
        public bool Alarms { get; set; }
    }
}