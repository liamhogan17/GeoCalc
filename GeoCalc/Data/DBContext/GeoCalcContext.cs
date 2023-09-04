
using GeoCalc.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeoCalc.Data.DBContext;

public class GeoCalcContext : DbContext
{    
    public GeoCalcContext(DbContextOptions<GeoCalcContext> options, ILogger<GeoCalcContext> logger) : base(options)
    {
        //try
        //{
        //    Database.Migrate();
        //}
        //catch (Exception e)
        //{
        //    logger.LogError(e, "Unable to migrate. Consider manual migration");
        //}
    }

    public DbSet<Class> ClassSet { get; set; }
    public DbSet<WholeGrade> GradeSet { get; set; }
    public DbSet<User> UserSet { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>().HasIndex(c => new { c.Id, c.Name, c.Subject, c.Grade, c.Description });
        modelBuilder.Entity<WholeGrade>().HasIndex(c => new { c.Id, c.Grade });
        modelBuilder.Entity<User>().HasIndex(c => new { c.Id, c.Name });
    }
}
