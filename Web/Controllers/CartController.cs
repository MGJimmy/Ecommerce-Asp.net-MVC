using BL.AppServices;
using DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        UserAppService userAppService = new UserAppService();
        CartAppService cartAppService = new CartAppService();
        OrderDetailsAppService OrderDetailsAppService = new OrderDetailsAppService();
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            Cart cart = cartAppService.getCartByUserId(userId); 
            return View(cart.CartProducts);
        }
        public ActionResult removeProduct(int productId)
        {
            string userId = User.Identity.GetUserId();
            cartAppService.removeProduct(userId, productId);
            TempData["Msg_Wishlist"] = "Product Removed from cart";
            return RedirectToAction("index");
        }
        [HttpPost]
        public ActionResult getQuantity( int[] newQuantity)
        {
            CartProductAppService cartProductAppService = new CartProductAppService();
            var userId = User.Identity.GetUserId();
            Cart cart = cartAppService.getCartByUserId(userId);
            List<CartProduct> cartProducts = cart.CartProducts.ToList();
            for (int i = 0; i < cartProducts.Count; i++)
            {
                cartProductAppService.UpdateQuantity(cartProducts[i].CartID, cartProducts[i].ProductID, newQuantity[i]);
            }
            //return RedirectToAction("index", "Checkout");
            var redirectUrl = new UrlHelper(Request.RequestContext).Action("index", "Checkout");
            return Json(new { Url = redirectUrl });

        }
    }
}