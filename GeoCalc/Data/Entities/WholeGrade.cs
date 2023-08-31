using GeoCalc.Clients;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeoCalc.Data.Entities;

[Table("Grade")]
public class WholeGrade
{
    [Key]
    public int Id { init; get; }
    [Required] public string Grade { init; get; } = string.Empty;
    public List<Class>? Classes { get; set; }
}