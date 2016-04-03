using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Mvc;
using System.ComponentModel.DataAnnotations;
namespace ShopMall.Models.ShopMallDBModels
{
    public class RelShopGood
    {
        public int ShopId { get; set; }
        public Shop Shop { get; set; }

        public int GoodId { get; set; }
        public Good Good {get;set;}
    }
}
