using System.Linq;
using Microsoft.Data.Entity;
using ShopMall.DBAccess.Repository.Abstract;
using ShopMall.Models.ShopMallDBModels;
using ShopMall.Models.AccountDBModels;

namespace ShopMall.DBAccess.Repository.Concrete
{
    public partial class Repository: IRepository
    {
        public ApplicationUser GetCurrentUser(string UserEmail)
        {
            return _ctx.Users.Where(u => u.Email == UserEmail).FirstOrDefault();
        }

        public Shop GetUserShop(ApplicationUser User) {
            return _ctx.Shops.Where(s => s.ApplicationUserId == User.Id).Include(s => s.Goods).FirstOrDefault();
        }
        public int AddUserShop(Shop shop) {
            _ctx.Shops.Add(shop);
            _ctx.SaveChanges();
            return shop.Id;
        }
    }
}


