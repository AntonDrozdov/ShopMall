using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Data.Entity;
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


        public IQueryable<Good> ShopGoods(int ShopId) {
            //получаем список ид товаров магазина из объектов RelShopGood поля Goods, что есть связующие объекты между таблицей магазинов и таблицей товаров
            List<int> ShopGoodsIds = new List<int>();
            foreach (RelShopGood rsg in ctx.Shops.Where(s => s.Id == ShopId).FirstOrDefault().Goods) {
                ShopGoodsIds.Add(rsg. GoodId);
            }

            //выбираем из таблицы товаров все, ид которых, содержаться в вышеопределенной коллекции необходимых ид
            return ctx.Goods.Where(g => ShopGoodsIds.Contains(g.Id));
        }
        public Good CreateShopGood(Good good, Shop shop) {
            //сналча добавляем новый товар в таблицу
            ctx.Goods.Add(good);
            ctx.SaveChanges();

            //теперь создаем обхект связку товар - магазин
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


