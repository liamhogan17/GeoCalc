using GeoCalc.Clients;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;

namespace GeoCalc.Data.Entities;

[Table("User")]
public class User
{
    [Key]
    public int Id { init; get; }
    [Required] public string Name { get; set; } = string.Empty; 
    public List<Class>? Classes { get; set; }
}

