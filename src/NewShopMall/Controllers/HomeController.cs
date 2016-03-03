using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

using ShopMall.Models.ShopMallDBModels;
using ShopMall.DBAccess.DBContexts;


namespace ShopMall.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext ctx;
        public HomeController(ApplicationDbContext _ctx) {
            ctx = _ctx;
        }
        public IActionResult Index()
        {
            ViewBag.Shops = ctx.Shops.ToList();
 
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
