using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Http;
using ShopMall.DBAccess.Repository.Abstract;
using ShopMall.Models.ShopMallDBModels;

namespace ShopMall.DBAccess.Repository.Concrete
{
    public partial class Repository: IRepository
    {
        public void SaveImage(Image item)
        {
            _ctx.Images.Add(item);
            _ctx.SaveChanges();
        }

    }
}
