using BL.AppServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class DashboardController : Controller
    {
        RoleAppService roleAppService = new RoleAppService();
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRole(string Name)
        {
            if (Name != null)
            {
                IdentityResult result = roleAppService.Create(Name);
                if (result.Succeeded)
                {
                    TempData["Msg"] = "New Role Added Successfully";
                    return RedirectToAction("Index");
                }
                ViewBag.IdentityResultErrors = result.Errors;
            }
            else
            {
                ViewBag.Error = "Role Cant Be Empty";
            }
            return View();
        }
    }
}