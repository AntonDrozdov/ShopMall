using System;
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
        DbSet<Shop> Shops { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
