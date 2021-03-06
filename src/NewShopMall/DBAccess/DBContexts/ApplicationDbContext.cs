﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

using ShopMall.Models.AccountDBModels;
using ShopMall.Models.ShopMallDBModels;


namespace ShopMall.DBAccess.DBContexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Good> Goods {get;set;}
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<RelShopGood>().HasKey(r => new { r.ShopId, r.GoodId });
            builder.Entity<RelShopGood>()
                .HasOne(r => r.Shop)
                .WithMany(l => l.Goods)
                .HasForeignKey(r => r.ShopId);
            builder.Entity<RelShopGood>()
                .HasOne(r => r.Good)
                .WithMany(l => l.Shops)
                .HasForeignKey(r => r.GoodId);

        }
    }
}
