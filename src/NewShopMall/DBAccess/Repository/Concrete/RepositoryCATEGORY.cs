using System.Linq;
using ShopMall.DBAccess.Repository.Abstract;
using ShopMall.Models.ShopMallDBModels;

namespace ShopMall.DBAccess.Repository.Concrete
{
    public partial class Repository : IRepository
    {
        public IQueryable<Category> Categories() {
            return ctx.Categories;
        }
    }
}
