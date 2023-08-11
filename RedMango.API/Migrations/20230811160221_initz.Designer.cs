﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RedMango.API.Data;

#nullable disable

namespace RedMango.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230811160221_initz")]
    partial class initz
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("RedMango.API.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("RedMango.API.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("ShoppingCartId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("RedMango.API.Models.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("SpecialTag")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Appetizer",
                            Description = "Spring Roll Description",
                            Image = "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg",
                            Name = "Spring Roll",
                            Price = 7.9900000000000002,
                            SpecialTag = ""
                        },
                        new
                        {
                            Id = 2,
                            Category = "Appetizer",
                            Description = "Spring Roll Description",
                            Image = "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg",
                            Name = "Spring Roll 2",
                            Price = 7.9900000000000002,
                            SpecialTag = ""
                        },
                        new
                        {
                            Id = 3,
                            Category = "Appetizer",
                            Description = "Spring Roll Description",
                            Image = "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg",
                            Name = "Spring Roll 3",
                            Price = 7.9900000000000002,
                            SpecialTag = ""
                        },
                        new
                        {
                            Id = 4,
                            Category = "Appetizer",
                            Description = "Spring Roll Description",
                            Image = "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg",
                            Name = "Spring Roll 4",
                            Price = 7.9900000000000002,
                            SpecialTag = ""
                        },
                        new
                        {
                            Id = 5,
                            Category = "Appetizer",
                            Description = "Spring Roll Description",
                            Image = "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg",
                            Name = "Spring Roll 5",
                            Price = 7.9900000000000002,
                            SpecialTag = ""
                        },
                        new
                        {
                            Id = 6,
                            Category = "Appetizer",
                            Description = "Spring Roll Description",
                            Image = "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg",
                            Name = "Spring Roll 6",
                            Price = 7.9900000000000002,
                            SpecialTag = ""
                        },
                        new
                        {
                            Id = 7,
                            Category = "Appetizer",
                            Description = "Spring Roll Description",
                            Image = "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg",
                            Name = "Spring Roll 7",
                            Price = 7.9900000000000002,
                            SpecialTag = ""
                        },
                        new
                        {
                            Id = 8,
                            Category = "Appetizer",
                            Description = "Spring Roll Description",
                            Image = "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg",
                            Name = "Spring Roll 8",
                            Price = 7.9900000000000002,
                            SpecialTag = ""
                        },
                        new
                        {
                            Id = 9,
                            Category = "Appetizer",
                            Description = "Spring Roll Description",
                            Image = "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg",
                            Name = "Spring Roll 9",
                            Price = 7.9900000000000002,
                            SpecialTag = ""
                        },
                        new
                        {
                            Id = 10,
                            Category = "Appetizer",
                            Description = "Spring Roll Description",
                            Image = "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg",
                            Name = "Spring Roll 10",
                            Price = 7.9900000000000002,
                            SpecialTag = ""
                        });
                });

            modelBuilder.Entity("RedMango.API.Models.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RedMango.API.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RedMango.API.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RedMango.API.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RedMango.API.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RedMango.API.Models.CartItem", b =>
                {
                    b.HasOne("RedMango.API.Models.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RedMango.API.Models.ShoppingCart", null)
                        .WithMany("CartItems")
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");
                });

            modelBuilder.Entity("RedMango.API.Models.ShoppingCart", b =>
                {
                    b.Navigation("CartItems");
                });
#pragma warning restore 612, 618
        }
    }
}