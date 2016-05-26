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
        public Good CreateShopGood(Good good, Shop shop, ICollection<IFormFile> newimages)
        {
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
            _ctx.Goods.Add(good);
            _ctx.SaveChanges();

            //теперь создаем обхъкт связку товар - магазин
            RelShopGood rsg = new RelShopGood() { Good = good, GoodId = good.Id, Shop = shop, ShopId = shop.Id };
            //добавляем объект связку в товар
            good.Shops.Add(rsg);
            //созраняемся
            _ctx.Entry(good).State = EntityState.Modified;
            _ctx.SaveChanges();
            return good;
        }
        public Good GetGood(int? Id)
        {
            return _ctx.Goods.Where(g => g.Id == Id).Include(g => g.Category).Include(g => g.Category.ParentCategory).FirstOrDefault();
        }
    }
}
