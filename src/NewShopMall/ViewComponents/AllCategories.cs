using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ShopMall.DBAccess.Repository.Abstract;
using ShopMall.ViewModels.Manage;

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
            ViewBag.Categories = _repository.Categories().ToList();
            return View();
        }

        public IViewComponentResult Invoke(CreateEditGoodViewModel cegvm)
        {
            ViewBag.Categories = _repository.Categories().ToList();
            string[] ws = cegvm.Category.Split('/');
            ViewBag.FW = ws[0];
            return View(cegvm);
        }
    }
}
