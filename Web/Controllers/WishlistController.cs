using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using BL.AppServices;
using Microsoft.AspNet.Identity;

namespace Web.Controllers
{
    [Authorize]
    public class WishlistController : Controller
    {
        UserAppService userAppService = new UserAppService();
        WishlistAppService wishlistAppService = new WishlistAppService();
        [Authorize]
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            Wishlist wishlist = wishlistAppService.getWishlistByUserId(userId);
            return View(wishlist);
        }
        public ActionResult removeProduct(int productId)
        {
            string userId= User.Identity.GetUserId();
            wishlistAppService.removeProduct(userId, productId);
            TempData["Msg_Wishlist"] = "Product Removed from cart";
            return RedirectToAction("index");
        }
    }
}