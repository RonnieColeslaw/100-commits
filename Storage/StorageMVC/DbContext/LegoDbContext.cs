using LegoMVC.Models;
using Microsoft.EntityFrameworkCore;

public class LegoDbContext : DbContext
{
    public LegoDbContext(DbContextOptions<LegoDbContext> options) : base(options)
    {
    }

    public DbSet<LegoModel> LegoSets { get; set; }
}
