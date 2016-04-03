using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopMall.Models.ShopMallDBModels;
using ShopMall.Models.AccountDBModels;

namespace ShopMall.DBAccess.Repository.Abstract
{
    public interface IRepository
    {
        IQueryable<Shop> Shops();
        IQueryable<Good> ShopGoods(int ShopId);
        ApplicationUser GetCurrentUser(string UserEmail);
        Shop GetUserShop(ApplicationUser User);
        int AddUserShop(Shop shop); 

        
        
    }
}
