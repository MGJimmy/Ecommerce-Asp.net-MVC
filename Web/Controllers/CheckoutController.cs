using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.AppServices;
using DAL;
using BL.ViewModels;
using Microsoft.AspNet.Identity;

namespace Web.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        UserAppService userAppService = new UserAppService();
        CartAppService cartAppService = new CartAppService();
        ProductAppService productAppService = new ProductAppService();
        OrderHeaderAppService orderAppService = new OrderHeaderAppService();
        [Authorize]
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            double ProductsTotalPrice = cartAppService.getCartProductsPrice(userId);
            ViewBag.ProductsTotalPrice = ProductsTotalPrice;
            ViewBag.userId = userId;
            return View();
        }
        [HttpPost]
        public ActionResult Done(UserShippingInfoViewModel userShippingInfoViewModel)
        {
            string userId = User.Identity.GetUserId();
            userAppService.UpdateUserShippingInfo(userId, userShippingInfoViewModel);
            Cart userCart = cartAppService.getCartByUserId(userId);
            orderAppService.MakeOrder(userId, userCart.CartProducts);
            return RedirectToAction("MyOrders", "Home");
        }
    }
}