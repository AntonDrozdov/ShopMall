using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Entity.Storage;

using ShopMall.Models.ShopMallDBModels;
using ShopMall.DBAccess.DBContexts;

namespace ShopMall.ForTests
{
    public class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();

            if (!context.Shops.Any())
            {
                context.Shops.AddRange(
                    new Shop { Title = "Samsung Galaxy Edge" },
                    new Shop { Title = "Samsung Galaxy Edge" },
                    new Shop { Title = "Samsung Galaxy Edge" }
                );
                context.SaveChanges();
            }
        }


    }
}
