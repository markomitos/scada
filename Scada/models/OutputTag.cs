using System.ComponentModel.DataAnnotations;

public class OutputTag: Tag
{
    [Required]
    public double InitialValue { get; set; }
}