using Microsoft.EntityFrameworkCore;

public class LegoContext : DbContext
{
    public DbSet<LegoSet> LegoStorage { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LegoSet>().ToTable("LegoStorage");
    }
}