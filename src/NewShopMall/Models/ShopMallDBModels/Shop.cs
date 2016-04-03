using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ShopMall.Models.AccountDBModels;

namespace ShopMall.Models.ShopMallDBModels
{
    public class Shop
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual string ApplicationUserId { get; set; }
        public List<RelShopGood> Goods {get; set;}

        public Shop() {
            Goods = new List<RelShopGood>();
        }
        
    }
}
