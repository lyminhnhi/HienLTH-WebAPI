using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<ProductOrderEntity> ProductOrders { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderEntity>(e =>
            {
                e.ToTable("OrderTable");
                e.HasKey(o => o.OrderCode);
                e.Property(o => o.BookingDate).HasDefaultValueSql("getutcdate()");
            });

            modelBuilder.Entity<ProductOrderEntity>(e =>
            {
                e.ToTable("ProductOdersTable");
                e.HasKey(po => new { po.OrderCode, po.ProductCode });

                e.HasOne(po => po.Orders)
                .WithMany(o => o.ProductOrders)
                .HasForeignKey(po => po.OrderCode)
                .HasConstraintName("FK_ProductOder_Order");

                e.HasOne(po => po.Products)
                .WithMany(p => p.ProductOrders)
                .HasForeignKey(po => po.ProductCode)
                .HasConstraintName("FK_ProductOder_Product");
            });
        }
    }
}