using GeoCalc.Clients;
using GeoCalc.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeoCalc.Data.Entities;

[Table("Class")]
public class Class
{
    [Key]
    public int Id { init; get; }
    [Required] public string Name { init; get; } = string.Empty;
    [Required] public string Subject { init; get; } = string.Empty;
    [Required] public string Grade { init; get; } = string.Empty;
    public string? Description { get; set; }
}
