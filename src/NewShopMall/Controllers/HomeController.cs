using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

using ShopMall.DBAccess.Repository.Abstract;
using ShopMall.DBAccess.DBContexts;



using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Entity.Storage;

namespace ShopMall.Controllers
{
    public class HomeController : Controller
    {
        IRepository _repository;

        public HomeController(IRepository repository) {
            _repository = repository;
        }

        public IActionResult Index()
        {
            ViewBag.Shops = _repository.Shops().ToList();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
