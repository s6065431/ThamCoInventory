using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventorydata.data
{
    public class InventoryDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Permissions> Permission { get; set; }

        public DbSet<StockRequest> StockRequests { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Permissions>(x =>
            {
                x.Property(p => p.ID).IsRequired();
                x.Property(p => p.Title).IsRequired();
            });

            modelBuilder.Entity<Staff>(x =>
            {
                x.Property(s => s.ID).IsRequired();
                x.HasOne(s => s.Permissions).WithMany().HasForeignKey(s => s.PermissionsID).IsRequired();
            });

            modelBuilder.Entity<Product>(x =>
            {
                x.Property(p => p.ID).IsRequired();
                x.Property(p => p.Name).IsRequired();
                x.Property(p => p.Quantity).IsRequired();
            });

            modelBuilder.Entity<StockRequest>(x =>
            {
                x.Property(s => s.ID).IsRequired();
                x.Property(s => s.ApprovalStatus).IsRequired();
                x.Property(s => s.RequestedQuantity).IsRequired();
                x.HasOne(s => s.Product).WithMany().HasForeignKey(s => s.ProductID).IsRequired();
                x.HasOne(s => s.Staff).WithMany().HasForeignKey(s => s.StaffID).IsRequired();
            });
        }
    }
}
