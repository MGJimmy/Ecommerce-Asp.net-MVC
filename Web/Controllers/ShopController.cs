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
    public class ShopController : Controller
    {

        ProductAppService product = new ProductAppService();
        CategoryAppService category = new CategoryAppService();
        ColorAppService color = new ColorAppService();
        UserAppService userAppService = new UserAppService();
        WishlistAppService wishlistAppService = new WishlistAppService();
        CartAppService cartAppService = new CartAppService();
        // GET: Shop
        public ActionResult Index(int categoryid = 0, int colorid = 0, string name = "")
        {
            ViewBag.category = category.GetAll();
            ViewBag.colors = color.GetAll();
            if (categoryid != 0)
            {
                return View(product.GetProductsByCategory(categoryid));

            }
            if (colorid != 0)
            {
                return View(product.GetProductsByColor(colorid));
            }
            return View(product.GetAll());

        }
        public ActionResult ShowProducts(int categoryId)
        {
            return PartialView("_ProductList", product.GetProductsByCategory(categoryId));
        }
        public ActionResult ShowProductswithcustomColors(int colorId)
        {
            return PartialView("_ProductList", product.GetProductsByColor(colorId));
        }
        [Authorize]
        public ActionResult AddToCart(int productId)
        {
            string userId = User.Identity.GetUserId();
            ApplicationUserIdentity user = userAppService.FindByID(userId);
            CartProduct cartProduct = new CartProduct()
            {
                CartID = user.Id,
                ProductID = productId,
                Quantity = 1
            };
            cartAppService.addProduct(cartProduct);
            TempData["Msg_Cart"] = "New Item Added Successfully To Cart";
            return RedirectToAction("index");
        }
        [Authorize]
        public ActionResult AddToWishlist(int productId)
        {
            string userId = User.Identity.GetUserId();
            wishlistAppService.addProduct(userId, productId);
            TempData["Msg_Wishlist"] = "New Item Added Successfully To WishList";
            return RedirectToAction("index");
        }
        public ActionResult search(string searchName)
        {
            if (product.searchByName(searchName).Count() == 0)
            {
                TempData["Msg_emptysearch"] = "No Item Match The Search Input";



            }
            IEnumerable<Product> result = product.searchByName(searchName);
            return View(result);
        }
    }
}