using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Http;

using ShopMall.DBAccess.DBContexts;
using ShopMall.DBAccess.Repository.Abstract;
using ShopMall.Models.ShopMallDBModels;
using ShopMall.Models.AccountDBModels;

namespace ShopMall.DBAccess.Repository.Concrete
{
    public partial class Repository: IRepository
    {
        private ApplicationDbContext ctx;  
        private bool disposing = false;

        public Repository(ApplicationDbContext _ctx) {
            ctx = _ctx;
        }

        public static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposing)
            {
                if (disposing)
                {
                    this.ctx.Dispose();
                }
            }
            this.disposing = true;

        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
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

        public IQueryable<Good> ShopGoods(int ShopId) {
            //получаем список ид товаров магазина из объектов RelShopGood поля Goods, что есть связующие объекты между таблицей магазинов и таблицей товаров
            List<int> ShopGoodsIds = new List<int>();
            foreach (RelShopGood rsg in ctx.Shops.Where(s => s.Id == ShopId).FirstOrDefault().Goods) {
                ShopGoodsIds.Add(rsg. GoodId);
            }

            //выбираем из таблицы товаров все, ид которых, содержаться в вышеопределенной коллекции необходимых ид
            return ctx.Goods.Where(g => ShopGoodsIds.Contains(g.Id));
        }
        public Good CreateShopGood(Good good, Shop shop, ICollection<IFormFile> newimages) {
            Good newgood = good;
            //сначала добавляем картинки в бд и тут же в коллекцию изображений товара
            List<Image> uploadimages = new List<Image>();
            foreach (IFormFile im in newimages)
            {
                Image newim = new Image();
                newim.Id = 0; newim.IsMain = true; newim.Description = ""; newim.ImageMimeType = im.ContentType;
                using (var reader = new StreamReader(im.OpenReadStream()))
                {
                    string contentAsString = reader.ReadToEnd();
                    newim.ImageContent = GetBytes(contentAsString);
                }
                SaveImage(newim);
                newgood.Images.Add(newim);
            }

            //добавляем новый товар в таблицу
            ctx.Goods.Add(good);
            ctx.SaveChanges();

            //теперь создаем обхъкт связку товар - магазин
            RelShopGood rsg = new RelShopGood() { Good = good, GoodId = good.Id, Shop = shop, ShopId = shop.Id };
            //добавляем объект связку в товар
            good.Shops.Add(rsg);
            //созраняемся
            ctx.Entry(good).State = EntityState.Modified;
            ctx.SaveChanges();
            return good;
        }

    }
}


