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

using ShopMall.Models.AccountDBModels;

namespace ShopMall.Controllers
{
    [Authorize]
    public partial class ManageController : Controller
    {

        [HttpGet]
        public IActionResult ManageShopProfile()
        {
            return View();
        }
        public IActionResult ManageShopGoods()
        {
            return View();
        }
        public IActionResult ManageShopGoodDiscounts()
        {
            return View();
        }






    }
}
