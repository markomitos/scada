using System.ComponentModel.DataAnnotations;


namespace Scada.models
{
    public abstract class Tag
    {
        [Key]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string IoAddress { get; set; }
    }
}