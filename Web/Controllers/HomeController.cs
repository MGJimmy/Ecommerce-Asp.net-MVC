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
    public class HomeController : Controller
    {
        CategoryAppService categoryAppService = new CategoryAppService();
        ProductAppService productservice = new ProductAppService();
        public ActionResult Index()
        {
            IEnumerable<Product> products = productservice.GetLastProducts(10);
            ViewBag.latestProducts = products;
            return View(categoryAppService.GetAll());
        }

        [Authorize]
        public ActionResult MyOrders()
        {
            OrderHeaderAppService orderHeaderAppService = new OrderHeaderAppService(); 
            string userId = User.Identity.GetUserId();
            IEnumerable<OrderHeader> orderHeaders = orderHeaderAppService.GetAllUserOrdersr(userId);

            return View(orderHeaders);
        }

    }
}