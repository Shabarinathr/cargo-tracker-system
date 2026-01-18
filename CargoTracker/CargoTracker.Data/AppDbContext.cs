using Microsoft.EntityFrameworkCore;
using CargoTracker.Models;

namespace CargoTracker.Data;

public class AppDbContext : DbContext
{
    public DbSet<Vessel> Vessels { get; set; }
    public DbSet<Container> Containers { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vessel>()
            .HasIndex(v => v.IMO)
            .IsUnique();
            
        // Seed real maritime data
        modelBuilder.Entity<Vessel>().HasData(
            new Vessel { Id = 1, IMO = "IMO9125050", Name = "EVER ACE", CapacityTEU = 23800, CurrentPort = "Singapore", Status = VesselStatus.AtSea },
            new Vessel { Id = 2, IMO = "IMO9787301", Name = "HMM ALGEBRAS", CapacityTEU = 15800, CurrentPort = "Mumbai", Status = VesselStatus.InPort }
        );
    }
}
