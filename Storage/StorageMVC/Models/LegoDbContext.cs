using LegoMVC.Models;
using Microsoft.EntityFrameworkCore;
using Storage.Model;

public class LegoDbContext : DbContext
{
    public LegoDbContext(DbContextOptions<LegoDbContext> options) : base(options)
    {
    }

    public DbSet<LegoModel> LegoModel { get; set; }

    public DbSet<Warehouse> Warehouse { get; set; }

    public DbSet<Serie> Serie { get; set; }
}

