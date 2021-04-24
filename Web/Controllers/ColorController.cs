using BL.AppServices;
using BL.ViewModels;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class ColorController : Controller
    {
        ColorAppService colorAppService = new ColorAppService();
        // GET: Color
        public ActionResult Index()
        {
            IEnumerable<Color> colors = colorAppService.GetAll();
            return View(colors);
        }
        public ActionResult Create() => View();
        [HttpPost]
        public ActionResult Create(ColorViewModel colorViewModel)
        {
            if (ModelState.IsValid == false)
                return View();
            colorAppService.Insert(colorViewModel);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            Color color = colorAppService.GetByID(id);
            return View(color);
        }
        [HttpPost]
        public ActionResult Edit(ColorViewModel colorViewModel)
        {
            if (ModelState.IsValid == false)
                return View();
            colorAppService.Update(colorViewModel);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            colorAppService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}