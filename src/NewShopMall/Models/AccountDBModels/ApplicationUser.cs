using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using ShopMall.Models.ShopMallDBModels;

namespace ShopMall.Models.AccountDBModels
{
    public class ApplicationUser : IdentityUser
    {
        public string Urladdress { get; set; }

        public Shop Shop { get; set; }
    }
}

