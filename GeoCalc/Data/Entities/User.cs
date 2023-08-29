using BrainDump.Clients;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;

namespace BrainDump.Data.Entities;

[Table("User")]
public class User
{
    [Key]
    [Required]
    public Guid Id { init; get; }
    [Required]
    public string Name { get; set; }
    private List<Class> Classes { get; set; }
    private Statistics Stats { get; }
}
