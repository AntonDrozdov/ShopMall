using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopMall.Models.ShopMallDBModels;
using ShopMall.Models.AccountDBModels;
using Microsoft.AspNet.Http;

namespace ShopMall.DBAccess.Repository.Abstract
{
    public interface IRepository
    {
            //SHOPINFO
        IQueryable<Shop> Shops();
        IQueryable<Good> ShopGoodsFullInformation(int ShopId);
        IQueryable<Good> ShopGoods(int ShopId);
            //USERS
        ApplicationUser GetCurrentUser(string UserEmail);
        Shop GetUserShop(ApplicationUser User);
        int AddUserShop(Shop shop);
            //CATEGORIES
        IQueryable<Category> Categories();
            //IMAGE
        void SaveImage(Image item);
            //GOODS
        Good CreateShopGood(Good good, Shop shop, ICollection<IFormFile> newimages);
        Good GetGood(int? Id);

    }
}
