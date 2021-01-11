﻿// <auto-generated />
using System;
using FollowersPark.DataAccess.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FollowersPark.Migrations
{
    [DbContext(typeof(FollowersParkContext))]
    [Migration("20210110120648_CsrfToken")]
    partial class CsrfToken
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FollowersPark.DataAccess.Tables.BlockList", b =>
                {
                    b.Property<int>("BlockListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("ListName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Usernames")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BlockListId");

                    b.HasIndex("UserId");

                    b.ToTable("BlockLists");
                });

            modelBuilder.Entity("FollowersPark.DataAccess.Tables.DirectMessage", b =>
                {
                    b.Property<int>("DirectMessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("ListName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Messages")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DirectMessageId");

                    b.HasIndex("UserId");

                    b.ToTable("DirectMessages");
                });

            modelBuilder.Entity("FollowersPark.DataAccess.Tables.InstagramAccount", b =>
                {
                    b.Property<int>("InstagramAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CsrfToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<long>("FollowersCount")
                        .HasColumnType("bigint");

                    b.Property<long>("FollowingCount")
                        .HasColumnType("bigint");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("InstagramId")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("InstagramAccountId");

                    b.HasIndex("UserId");

                    b.ToTable("InstagramAccounts");
                });

            modelBuilder.Entity("FollowersPark.DataAccess.Tables.Log", b =>
                {
                    b.Property<int>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("InstagramUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("InstagramUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LogId");

                    b.HasIndex("TaskId");

                    b.HasIndex("UserId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("FollowersPark.DataAccess.Tables.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("AccountsLimit")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PricingId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OrderId");

                    b.HasIndex("PricingId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            AccountsLimit = (byte)255,
                            CreatedDate = new DateTime(2021, 1, 10, 15, 6, 47, 812, DateTimeKind.Local).AddTicks(6379),
                            Deleted = false,
                            FinishDate = new DateTime(2023, 10, 6, 12, 6, 47, 812, DateTimeKind.Utc).AddTicks(7293),
                            PricingId = 5,
                            UserId = "a53bc759-f5b2-49fe-b4d3-db96edab5118"
                        });
                });

            modelBuilder.Entity("FollowersPark.DataAccess.Tables.Pricing", b =>
                {
                    b.Property<int>("PricingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBestSeller")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("SubTitle")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("PricingId");

                    b.ToTable("Pricings");

                    b.HasData(
                        new
                        {
                            PricingId = 1,
                            CreatedDate = new DateTime(2021, 1, 10, 15, 6, 47, 808, DateTimeKind.Local).AddTicks(3099),
                            Currency = "₺",
                            Deleted = false,
                            IsActive = true,
                            IsBestSeller = false,
                            Price = 30.00m,
                            SubTitle = "1",
                            Title = "Individual"
                        },
                        new
                        {
                            PricingId = 2,
                            CreatedDate = new DateTime(2021, 1, 10, 15, 6, 47, 811, DateTimeKind.Local).AddTicks(818),
                            Currency = "₺",
                            Deleted = false,
                            IsActive = true,
                            IsBestSeller = true,
                            Price = 51.00m,
                            SubTitle = "2",
                            Title = "Duo"
                        },
                        new
                        {
                            PricingId = 3,
                            CreatedDate = new DateTime(2021, 1, 10, 15, 6, 47, 811, DateTimeKind.Local).AddTicks(1750),
                            Currency = "₺",
                            Deleted = false,
                            IsActive = true,
                            IsBestSeller = false,
                            Price = 75.00m,
                            SubTitle = "3",
                            Title = "Triple"
                        },
                        new
                        {
                            PricingId = 4,
                            CreatedDate = new DateTime(2021, 1, 10, 15, 6, 47, 811, DateTimeKind.Local).AddTicks(1785),
                            Currency = "₺",
                            Deleted = false,
                            IsActive = true,
                            IsBestSeller = false,
                            Price = 120.00m,
                            SubTitle = "5",
                            Title = "Quintette"
                        },
                        new
                        {
                            PricingId = 5,
                            CreatedDate = new DateTime(2021, 1, 10, 15, 6, 47, 811, DateTimeKind.Local).AddTicks(1810),
                            Currency = "₺",
                            Deleted = false,
                            IsActive = false,
                            IsBestSeller = false,
                            Price = 0m,
                            SubTitle = "1",
                            Title = "Free"
                        });
                });

            modelBuilder.Entity("FollowersPark.DataAccess.Tables.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Action")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int?>("DirectMessageId")
                        .HasColumnType("int");

                    b.Property<byte>("DirectMessageSource")
                        .HasColumnType("tinyint");

                    b.Property<string>("GeoraphicalLocations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hashtags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InteractWithPosts")
                        .HasColumnType("bit");

                    b.Property<byte>("InteractWithPostsDays")
                        .HasColumnType("tinyint");

                    b.Property<int>("IntervalSpeed")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleteAfterSendingMessage")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSkipSentMessage")
                        .HasColumnType("bit");

                    b.Property<short>("MaximumNumberTransactions")
                        .HasColumnType("smallint");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<short>("NumberTransactions")
                        .HasColumnType("smallint");

                    b.Property<string>("PostsShortCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Resource")
                        .HasColumnType("tinyint");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<byte>("UnfollowOption")
                        .HasColumnType("tinyint");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserList")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<byte>("WhereUserResource")
                        .HasColumnType("tinyint");

                    b.HasKey("TaskId");

                    b.HasIndex("DirectMessageId");

                    b.HasIndex("UserId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("FollowersPark.DataAccess.Tables.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

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
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "a53bc759-f5b2-49fe-b4d3-db96edab5118",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b7e6b263-b296-4ab5-97ea-de6146f11dbb",
                            CreatedDate = new DateTime(2021, 1, 10, 15, 6, 47, 812, DateTimeKind.Local).AddTicks(3000),
                            Deleted = false,
                            Email = "demo@followerspark.com",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            ModifiedDate = new DateTime(2021, 1, 10, 15, 6, 47, 812, DateTimeKind.Local).AddTicks(4422),
                            NormalizedEmail = "DEMO@FOLLOWERSPARK.COM",
                            NormalizedUserName = "DEMO@FOLLOWERSPARK.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEEgF9tR64l8xuT16f/zfv51NKZ5BOY+8spB5eJN5KuQ4s5kv74JVsDmPMYsGFcqFEA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "WFAXFZOX3UIXREEDBJXNWNMUU2LZB3E4",
                            TwoFactorEnabled = false,
                            UserName = "demo@followerspark.com"
                        });
                });

            modelBuilder.Entity("FollowersPark.DataAccess.Tables.UserList", b =>
                {
                    b.Property<int>("UserListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("ListName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Usernames")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserListId");

                    b.HasIndex("UserId");

                    b.ToTable("UserLists");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
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

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
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

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("FollowersPark.DataAccess.Tables.BlockList", b =>
                {
                    b.HasOne("FollowersPark.DataAccess.Tables.User", "User")
                        .WithMany("BlockLists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FollowersPark.DataAccess.Tables.DirectMessage", b =>
                {
                    b.HasOne("FollowersPark.DataAccess.Tables.User", "User")
                        .WithMany("DirectMessages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FollowersPark.DataAccess.Tables.InstagramAccount", b =>
                {
                    b.HasOne("FollowersPark.DataAccess.Tables.User", "User")
                        .WithMany("InstagramAccounts")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FollowersPark.DataAccess.Tables.Log", b =>
                {
                    b.HasOne("FollowersPark.DataAccess.Tables.Task", "Task")
                        .WithMany("Logs")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FollowersPark.DataAccess.Tables.User", "User")
                        .WithMany("Logs")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FollowersPark.DataAccess.Tables.Order", b =>
                {
                    b.HasOne("FollowersPark.DataAccess.Tables.Pricing", "Pricing")
                        .WithMany("Orders")
                        .HasForeignKey("PricingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FollowersPark.DataAccess.Tables.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FollowersPark.DataAccess.Tables.Task", b =>
                {
                    b.HasOne("FollowersPark.DataAccess.Tables.DirectMessage", "DirectMessage")
                        .WithMany("Tasks")
                        .HasForeignKey("DirectMessageId");

                    b.HasOne("FollowersPark.DataAccess.Tables.User", "User")
                        .WithMany("Tasks")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FollowersPark.DataAccess.Tables.UserList", b =>
                {
                    b.HasOne("FollowersPark.DataAccess.Tables.User", "User")
                        .WithMany("UserLists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                    b.HasOne("FollowersPark.DataAccess.Tables.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FollowersPark.DataAccess.Tables.User", null)
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

                    b.HasOne("FollowersPark.DataAccess.Tables.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FollowersPark.DataAccess.Tables.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
