﻿// <auto-generated />
using Inventorydata.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Inventorydata.data.Migrations
{
    [DbContext(typeof(InventoryDbContext))]
    [Migration("20200106191852_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Inventorydata.data.Permissions", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("Inventorydata.data.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Quantity");

                    b.HasKey("ID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Inventorydata.data.Staff", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PermissionsID");

                    b.HasKey("ID");

                    b.HasIndex("PermissionsID");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("Inventorydata.data.StockRequest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ApprovalStatus");

                    b.Property<int>("ProductID");

                    b.Property<int>("RequestedQuantity");

                    b.Property<int>("StaffID");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.HasIndex("StaffID");

                    b.ToTable("StockRequests");
                });

            modelBuilder.Entity("Inventorydata.data.Staff", b =>
                {
                    b.HasOne("Inventorydata.data.Permissions", "Permissions")
                        .WithMany()
                        .HasForeignKey("PermissionsID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Inventorydata.data.StockRequest", b =>
                {
                    b.HasOne("Inventorydata.data.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Inventorydata.data.Staff", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
