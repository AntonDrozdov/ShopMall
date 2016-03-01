using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ShopMall.Models.AccountDBModels
{
    public class ApplicationUser : IdentityUser
    {
        public string Urladdress { get; set; }
    }
}

