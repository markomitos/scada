using System.ComponentModel.DataAnnotations;

namespace Scada.models
{
    public abstract class InputTag : Tag
    {
        [Required] public string Driver { get; set; }

        [Required] public int ScanTime { get; set; }

        [Required] public bool OnOffScan { get; set; }
    }
}