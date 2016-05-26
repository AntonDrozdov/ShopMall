using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Http;
using ShopMall.DBAccess.Repository.Abstract;
using ShopMall.Models.ShopMallDBModels;

namespace ShopMall.DBAccess.Repository.Concrete
{
    public partial class Repository : IRepository
    {
        public IQueryable<Shop> Shops()
        {
            return _ctx.Shops;
        }

        public IQueryable<Good> ShopGoods(int ShopId)
        {
            //получаем список ид товаров магазина из объектов RelShopGood поля Goods, что есть связующие объекты между таблицей магазинов и таблицей товаров
            List<int> ShopGoodsIds = new List<int>();
            foreach (RelShopGood rsg in _ctx.Shops.Where(s => s.Id == ShopId).FirstOrDefault().Goods)
                ShopGoodsIds.Add(rsg.GoodId);
            
            //выбираем из таблицы товаров все, ид которых, содержаться в вышеопределенной коллекции необходимых ид
            return _ctx.Goods.Where(g => ShopGoodsIds.Contains(g.Id));
        }
        public IQueryable<Good> ShopGoodsFullInformation(int ShopId) 
        {
            
            //получаем список ид товаров магазина из объектов RelShopGood поля Goods, что есть связующие объекты между таблицей магазинов и таблицей товаров
            List<int> ShopGoodsIds = new List<int>();
            foreach (RelShopGood rsg in _ctx.Shops.Where(s => s.Id == ShopId).FirstOrDefault().Goods)
                ShopGoodsIds.Add(rsg.GoodId);

            //выбираем из таблицы товаров все, ид которых, содержаться в вышеопределенной коллекции необходимых ид
            List<Good> Goods = _ctx.Goods.Where(g => ShopGoodsIds.Contains(g.Id)).Include(g => g.Category).Include(g=>g.Category.ParentCategory).ToList();

            return Goods.AsQueryable();
        }
    }
}
