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


namespace ShopMall.Controllers
{
    [Authorize]
    public partial class ManageController : Controller
    {
        [HttpGet]
        public IActionResult MyShopMall()
        {
            var currentUser = _repository.GetCurrentUser(User.Identity.Name);
            if (currentUser != null)
            {
                var UserShop =  _repository.GetUserShop(currentUser);
                ViewData["UserShop"] = UserShop;
            }
            else {
                Redirect("/");
            }

            return View();
        }
    }
}