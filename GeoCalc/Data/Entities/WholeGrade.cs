using BrainDump.Clients;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrainDump.Data.Entities;

[Table("Grade")]
public class WholeGrade
{
    [Key]
    [Required]
    public Guid Id { init; get; }
    [Required]
    public string Grade { init; get; }
    public List<Class>? Classes { get; set; }
}