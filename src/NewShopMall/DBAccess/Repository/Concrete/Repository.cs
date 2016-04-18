using System.Linq;
using Microsoft.Data.Entity;
using ShopMall.DBAccess.Repository.Abstract;
using ShopMall.Models.ShopMallDBModels;
using ShopMall.Models.AccountDBModels;

namespace ShopMall.DBAccess.Repository.Concrete
{
    public partial class Repository: IRepository
    {
 
        public static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public IQueryable<Shop> Shops()
        {
            return ctx.Shops;
        }
        public ApplicationUser GetCurrentUser(string UserEmail)
        {
            return ctx.Users.Where(u => u.Email == UserEmail).FirstOrDefault();
        }
        public Shop GetUserShop(ApplicationUser User) {
            return ctx.Shops.Where(s => s.ApplicationUserId == User.Id).Include(s => s.Goods).FirstOrDefault();
        }
        public int AddUserShop(Shop shop) {
            ctx.Shops.Add(shop);
            ctx.SaveChanges();
            return shop.Id;
        }

        public void SaveImage(Image item)
        {
            ctx.Images.Add(item);
            ctx.SaveChanges();
        }


    }
}


