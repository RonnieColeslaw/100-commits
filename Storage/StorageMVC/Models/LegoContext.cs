using LegoMVC.Model;
using Microsoft.EntityFrameworkCore;


namespace StorageMVC.Data
{
    public class LegoContext : DbContext
    {
        public DbSet<LegoSet> LegoStorage { get; set; }

        public LegoContext(DbContextOptions<LegoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LegoSet>().ToTable("LegoStorage");

            
        }
    }
}
