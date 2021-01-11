using FollowersPark.DataAccess.Tables;
using FollowersPark.DataAccess.Tables.Entity;
using FollowersPark.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FollowersPark.DataAccess.EntityFramework.Context
{
    public class FollowersParkContext : IdentityDbContext<User, IdentityRole, string>
    {
        public FollowersParkContext(DbContextOptions<FollowersParkContext> options)
              : base(options)
        {
        }

        public DbSet<BlockList> BlockLists { get; set; }
        public DbSet<DirectMessage> DirectMessages { get; set; }
        public DbSet<InstagramAccount> InstagramAccounts { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<UserList> UserLists { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pricing> Pricings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes().Where(entityType => typeof(IEntity).IsAssignableFrom(entityType.ClrType)))
            {
                entityType.AddSoftDeleteQueryFilter();
            }

            builder
                .Entity<Pricing>()
                .Property(o => o.Price)
                .HasColumnType("decimal(18,4)");

            string currency = "₺";

            builder
                .Entity<Pricing>()
                .HasData(new Pricing
                {
                    PricingId = 1,
                    Title = "Individual",
                    SubTitle = "1",
                    Price = 30.00m,
                    Currency = currency,
                });

            builder
                .Entity<Pricing>()
                .HasData(new Pricing
                {
                    PricingId = 2,
                    Title = "Duo",
                    SubTitle = "2",
                    Price = 51.00m,
                    Currency = currency,
                    IsBestSeller = true
                });

            builder
                .Entity<Pricing>()
                .HasData(new Pricing
                {
                    PricingId = 3,
                    Title = "Triple",
                    SubTitle = "3",
                    Price = 75.00m,
                    Currency = currency,
                });

            builder
                .Entity<Pricing>()
                .HasData(new Pricing
                {
                    PricingId = 4,
                    Title = "Quintette",
                    SubTitle = "5",
                    Price = 120.00m,
                    Currency = currency,
                });

            builder
                .Entity<Pricing>()
                .HasData(new Pricing
                {
                    PricingId = 5,
                    Title = "Free",
                    SubTitle = "1",
                    Price = 0,
                    Currency = currency,
                    IsActive = false
                });

            const string USER_ID = "a53bc759-f5b2-49fe-b4d3-db96edab5118";
            string userName = "demo@followerspark.com";
            builder
                .Entity<User>()
                .HasData(new User()
                {
                    Id = USER_ID,
                    UserName = userName,
                    Email = userName,
                    NormalizedUserName = userName.ToUpper(),
                    NormalizedEmail = userName.ToUpper(),
                    AccessFailedCount = 0,
                    ConcurrencyStamp = "b7e6b263-b296-4ab5-97ea-de6146f11dbb",
                    CreatedDate = DateTime.Now,
                    EmailConfirmed = false,
                    LockoutEnabled = true,
                    ModifiedDate = DateTime.Now,
                    PasswordHash = "AQAAAAEAACcQAAAAEEgF9tR64l8xuT16f/zfv51NKZ5BOY+8spB5eJN5KuQ4s5kv74JVsDmPMYsGFcqFEA==",
                    SecurityStamp = "WFAXFZOX3UIXREEDBJXNWNMUU2LZB3E4",
                });

            builder
                .Entity<Order>()
                .HasData(new Order
                {
                    OrderId = 1,
                    AccountsLimit = 255,
                    FinishDate = DateTime.UtcNow.AddDays(999),
                    UserId = USER_ID,
                    PricingId = 5,
                });

            base.OnModelCreating(builder);
        }
    }
}