﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyWebAPI.Data;

namespace MyWebAPI.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20220316085841_AddNewSchema")]
    partial class AddNewSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyWebAPI.Data.CategoryEntity", b =>
                {
                    b.Property<int>("CategoryCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryCode");

                    b.ToTable("CategoryTable");
                });

            modelBuilder.Entity("MyWebAPI.Data.OrderEntity", b =>
                {
                    b.Property<Guid>("OrderCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BookingDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("RecipientAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipientPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ShippingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusOrder")
                        .HasColumnType("int");

                    b.HasKey("OrderCode");

                    b.ToTable("OrderTable");
                });

            modelBuilder.Entity("MyWebAPI.Data.ProductEntity", b =>
                {
                    b.Property<Guid>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("CategoryCode")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<byte>("Promotion")
                        .HasColumnType("tinyint");

                    b.HasKey("Code");

                    b.HasIndex("CategoryCode");

                    b.ToTable("ProductTable");
                });

            modelBuilder.Entity("MyWebAPI.Data.ProductOrderEntity", b =>
                {
                    b.Property<Guid>("OrderCode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductCode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<double>("PriceForSale")
                        .HasColumnType("float");

                    b.Property<byte>("PromotionForSale")
                        .HasColumnType("tinyint");

                    b.HasKey("OrderCode", "ProductCode");

                    b.HasIndex("ProductCode");

                    b.ToTable("ProductOdersTable");
                });

            modelBuilder.Entity("MyWebAPI.Data.ProductEntity", b =>
                {
                    b.HasOne("MyWebAPI.Data.CategoryEntity", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryCode");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MyWebAPI.Data.ProductOrderEntity", b =>
                {
                    b.HasOne("MyWebAPI.Data.OrderEntity", "Orders")
                        .WithMany("ProductOrders")
                        .HasForeignKey("OrderCode")
                        .HasConstraintName("FK_ProductOder_Order")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyWebAPI.Data.ProductEntity", "Products")
                        .WithMany("ProductOrders")
                        .HasForeignKey("ProductCode")
                        .HasConstraintName("FK_ProductOder_Product")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("MyWebAPI.Data.CategoryEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("MyWebAPI.Data.OrderEntity", b =>
                {
                    b.Navigation("ProductOrders");
                });

            modelBuilder.Entity("MyWebAPI.Data.ProductEntity", b =>
                {
                    b.Navigation("ProductOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
