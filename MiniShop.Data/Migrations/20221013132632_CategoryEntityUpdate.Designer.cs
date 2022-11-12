﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniShop.Data.Concreate;

#nullable disable

namespace MiniShop.Data.Migrations
{
    [DbContext(typeof(Context_MiniShop))]
    [Migration("20221013132632_CategoryEntityUpdate")]
    partial class CategoryEntityUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("MiniShop.Entity.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Description = "Phone Category",
                            IsDeleted = false,
                            Name = "Phone",
                            Url = "phone"
                        },
                        new
                        {
                            CategoryId = 2,
                            Description = "Computer Category",
                            IsDeleted = false,
                            Name = "Computer",
                            Url = "computer"
                        },
                        new
                        {
                            CategoryId = 3,
                            Description = "Electronic Category",
                            IsDeleted = false,
                            Name = "Electronic",
                            Url = "electronic"
                        },
                        new
                        {
                            CategoryId = 4,
                            Description = "Household Appliances Category",
                            IsDeleted = false,
                            Name = "Household Appliances",
                            Url = "household-appliances"
                        });
                });

            modelBuilder.Entity("MiniShop.Entity.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsHome")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "128 Gb",
                            ImageUrl = "1.png",
                            IsApproved = true,
                            IsDeleted = false,
                            IsHome = true,
                            Name = "IPhone 13",
                            Price = 24000m,
                            Url = "iphone-13"
                        },
                        new
                        {
                            ProductId = 2,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "256 Gb",
                            ImageUrl = "2.png",
                            IsApproved = true,
                            IsDeleted = false,
                            IsHome = true,
                            Name = "IPhone 13 Pro",
                            Price = 28000m,
                            Url = "iphone-13-pro"
                        },
                        new
                        {
                            ProductId = 3,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "128 Gb",
                            ImageUrl = "3.png",
                            IsApproved = true,
                            IsDeleted = false,
                            IsHome = true,
                            Name = "Samsung S21",
                            Price = 22000m,
                            Url = "samsung-s21"
                        },
                        new
                        {
                            ProductId = 4,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Full Automatic Washing Machine",
                            ImageUrl = "4.png",
                            IsApproved = true,
                            IsDeleted = false,
                            IsHome = false,
                            Name = "Vestel CM125",
                            Price = 18000m,
                            Url = "vestel-cm-125"
                        },
                        new
                        {
                            ProductId = 5,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "102 inch smart tv",
                            ImageUrl = "5.png",
                            IsApproved = true,
                            IsDeleted = false,
                            IsHome = false,
                            Name = "Arcelik TV-102 Smart TV",
                            Price = 24000m,
                            Url = "arcelik-tv-102-smart-tv"
                        },
                        new
                        {
                            ProductId = 6,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "102 inch smart tv",
                            ImageUrl = "5.png",
                            IsApproved = false,
                            IsDeleted = false,
                            IsHome = true,
                            Name = "LG TV-102 Smart TV",
                            Price = 24000m,
                            Url = "lg-tv-102-smart-tv"
                        },
                        new
                        {
                            ProductId = 7,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "102 inch smart tv",
                            ImageUrl = "5.png",
                            IsApproved = true,
                            IsDeleted = false,
                            IsHome = false,
                            Name = "Sony TV-102 Smart TV",
                            Price = 24000m,
                            Url = "sony-tv-102-smart-tv"
                        },
                        new
                        {
                            ProductId = 8,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "102 inç smart tv",
                            ImageUrl = "5.png",
                            IsApproved = true,
                            IsDeleted = false,
                            IsHome = false,
                            Name = "Arcelik TV-102 Smart TV",
                            Price = 24000m,
                            Url = "arcelik-tv-102-smart-tv"
                        },
                        new
                        {
                            ProductId = 9,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "102 inç smart tv",
                            ImageUrl = "5.png",
                            IsApproved = true,
                            IsDeleted = false,
                            IsHome = false,
                            Name = "Arcelik TV-102 Smart TV",
                            Price = 24000m,
                            Url = "arcelik-tv-102-smart-tv"
                        },
                        new
                        {
                            ProductId = 10,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "102 inç smart tv",
                            ImageUrl = "5.png",
                            IsApproved = true,
                            IsDeleted = false,
                            IsHome = false,
                            Name = "Arcelik TV-102 Smart TV",
                            Price = 24000m,
                            Url = "arcelik-tv-102-smart-tv"
                        });
                });

            modelBuilder.Entity("MiniShop.Entity.ProductCategory", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategories");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 1
                        },
                        new
                        {
                            ProductId = 1,
                            CategoryId = 3
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 3
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 3
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 3
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 4
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 3
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 3
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 3
                        },
                        new
                        {
                            ProductId = 8,
                            CategoryId = 3
                        },
                        new
                        {
                            ProductId = 9,
                            CategoryId = 3
                        },
                        new
                        {
                            ProductId = 10,
                            CategoryId = 3
                        });
                });

            modelBuilder.Entity("MiniShop.Entity.ProductCategory", b =>
                {
                    b.HasOne("MiniShop.Entity.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniShop.Entity.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MiniShop.Entity.Category", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("MiniShop.Entity.Product", b =>
                {
                    b.Navigation("ProductCategories");
                });
#pragma warning restore 612, 618
        }
    }
}