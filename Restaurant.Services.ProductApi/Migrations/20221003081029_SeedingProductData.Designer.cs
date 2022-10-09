﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restaurant.Services.ProductApi.Data;

#nullable disable

namespace Restaurant.Services.ProductApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221003081029_SeedingProductData")]
    partial class SeedingProductData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Restaurant.Services.ProductApi.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 2,
                            CategoryName = "laptop",
                            Description = "new laptop",
                            ImageUrl = "1d54f5ds4fsd54f",
                            Name = "asus r565",
                            Price = 23.300000000000001
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryName = "laptop",
                            Description = "new gaming laptop",
                            ImageUrl = "1d5452hjjhs4fsd54f",
                            Name = "asus tuf",
                            Price = 451.30000000000001
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryName = "laptop",
                            Description = "work laptop",
                            ImageUrl = "1d54f5dpp12",
                            Name = "apple macbook m1",
                            Price = 0.0
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryName = "laptop",
                            Description = "work laptop",
                            ImageUrl = "1d54f5dpp12",
                            Name = "apple macbook m1",
                            Price = 0.0
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryName = "laptop",
                            Description = "student laptop",
                            ImageUrl = "1d522pp12",
                            Name = "lenovo ideapad 5 ",
                            Price = 0.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}