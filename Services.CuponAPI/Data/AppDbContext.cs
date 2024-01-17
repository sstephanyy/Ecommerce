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

        // The ModelBuilder is a helper class provided by Entity Framework Core to define the shape of your entities and the relationships between them.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 1,
                CouponCode = "10OFF",
                DiscontAmount = 10,
                MinAmount = 20
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 2,
                CouponCode = "20OFF",
                DiscontAmount = 20,
                MinAmount = 40
            });
        }

        public DbSet<Coupon> Coupons { get; set; }
    }
}
