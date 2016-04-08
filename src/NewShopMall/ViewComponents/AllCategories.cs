using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ShopMall.DBAccess.Repository.Abstract;

namespace ShopMall.ViewComponents
{
    public class AllCategories : ViewComponent
    {
        private IRepository _repository;

        public AllCategories(IRepository repository) {
            _repository = repository;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
