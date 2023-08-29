using BrainDump.Clients;
using BrainDump.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrainDump.Data.Entities;

[Table("Class")]
public class Class
{
    [Key]
    [Required]
    public Guid Id { init; get; }
    [Required]
    public string Name { init; get; }
    [Required]
    public string Subject { init; get; }
    [Required]
    public int Grade { init; get; }
    public string? Description { get; set; }

    private Statistics? Marks;
    private IFileClient? Export;
}
