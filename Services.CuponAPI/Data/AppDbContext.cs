using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Services.CuponAPI.Models;

namespace Services.CuponAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
        {
            public AppDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                optionsBuilder.UseNpgsql("DefaultConnection");

                return new AppDbContext(optionsBuilder.Options);
            }
        }

        public DbSet<Coupon> Coupons { get; set; }
    }
}
