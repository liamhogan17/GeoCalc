
using BrainDump.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrainDump.Data.DBContext;

public class BrainDumpContext : DbContext
{    
    public BrainDumpContext(DbContextOptions<BrainDumpContext> options, ILogger<BrainDumpContext> logger) : base(options)
    {
        try
        {
            Database.Migrate();
        }
        catch (Exception e)
        {
            logger.LogError(e, "Unable to migrate. Consider manual migration");
        }
    }

    public DbSet<Class> ClassSet { get; set; }
    public DbSet<WholeGrade> GradeSet { get; set; }
    public DbSet<User> UserSet { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>().HasIndex(c => new { c.Id, c.Name, c.Subject, c.Grade }).IsUnique();
        modelBuilder.Entity<WholeGrade>().HasIndex(c => new { c.Id, c.Grade }).IsUnique();
        modelBuilder.Entity<User>().HasIndex(c => new { c.Id, c.Name }).IsUnique();
    }
}
