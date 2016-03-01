using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using NewShopMall.Models.ShopMallDBModels;

namespace NewShopMall.DBContexts
{
    public class ShopMallDBContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
    }
}
