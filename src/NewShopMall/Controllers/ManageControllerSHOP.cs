using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using ShopMall.Models;
using ShopMall.Services;
using ShopMall.ViewModels.Manage;
using Microsoft.AspNet.Http;




using ShopMall.Models.AccountDBModels;
using ShopMall.Models.ShopMallDBModels;
using System.IO;

namespace ShopMall.Controllers
{
    [Authorize]
    public partial class ManageController : Controller
    {
        [HttpGet]
        public IActionResult ManageShopGoods()
        {
            var currentUser = _repository.GetCurrentUser(User.Identity.Name);
            if (currentUser != null)
            {
       
                var Shop   = _repository.GetUserShop(currentUser);
       
                ViewBag.Goods = _repository.ShopGoodsFullInformation(Shop.Id).ToList();
            }
            else {
                Redirect("/");
            }

            return View();
        }
        [HttpGet]
        public IActionResult CreateGood()
        {
            return View();
        }
        [HttpPost  ]
        public IActionResult CreateGood(CreateEditGoodViewModel model, ICollection<IFormFile> newimages)
        {
            if (ModelState.IsValid) {
                //тек пользователь
                var currentUser = _repository.GetCurrentUser(User.Identity.Name);
                
                //соответсвующий магазин
                Shop shop = new Shop();
                if (currentUser != null)
                    shop = _repository.GetUserShop(currentUser);

                Good newgood = new Good() { Title = model.Title, Description = model.Description, CategoryId = Convert.ToInt32(model.CategoryId)};

                _repository.CreateShopGood(newgood, shop, newimages);

                return RedirectToAction("ManageShopGoods");
            }
            return RedirectToAction("ManageShopGoods");
        }
        [HttpGet]
        public ActionResult EditGood(int? id)
        {
            if (id == null) return HttpNotFound();

            Good good = _repository.GetGood(id);
            if (good != null)
            {
                string Category = good.Category.ParentCategory.Title + "/" + good.Category.Title;
                return View(new CreateEditGoodViewModel { Id = good.Id, Title = good.Title, Description = good.Description, Category = Category, Images = good.Images });
            }

            return RedirectToAction("GoodsList");
        }
        [HttpPost]
        public ActionResult EditGood(CreateEditGoodViewModel model, ICollection<IFormFile> newimages)
        {
            if (ModelState.IsValid)
            {
                //тек пользователь
                var currentUser = _repository.GetCurrentUser(User.Identity.Name);

                //соответсвующий магазин
                Shop shop = new Shop();
                if (currentUser != null)
                    shop = _repository.GetUserShop(currentUser);

                Good newgood = new Good() { Title = model.Title, Description = model.Description, CategoryId = Convert.ToInt32(model.Category) };

                _repository.CreateShopGood(newgood, shop, newimages);

                return RedirectToAction("ManageShopGoods");
            }
            return RedirectToAction("ManageShopGoods");

        }
        [HttpGet]
        public ActionResult DeleteGood(int? id)
        {
            //
            //if (id == null) return HttpNotFound();

            //Good good = repository.FindGood(id);

            //if (good == null) return HttpNotFound();

            //return PartialView("PartialDeleteGood", good);
            return View();

        }
        [HttpPost, ActionName("DeleteGood")]
        public ActionResult DeleteGoodConfirmed(int? id)
        {
            //if (id == null) return HttpNotFound();

            //Good good = repository.FindGood(id);

            //if (good == null) return HttpNotFound();

            //repository.DeleteGood(good);

            //return RedirectToAction("GoodsList");
            return View();
        }



        public IActionResult ManageShopSales()
        {
            return View();
        }
        public IActionResult ManageShopPurchases()
        {
            return View();
        }
        public IActionResult ManageShopDiscounts()
        {
            return View();
        }
        public IActionResult ManageShopProfile()
        {
            return View();
        }




    }
}
