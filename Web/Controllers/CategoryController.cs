using BL.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BL.ViewModels;
using System.IO;

namespace Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {

        CategoryAppService CategoryService = new CategoryAppService();
        // GET: Category
        public ActionResult Index()
        {
            return View(CategoryService.GetAll());
        }
        public ActionResult Create() => View(new CategoryViewModel());
        [HttpPost]
        public ActionResult Create(CategoryViewModel category, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid == false)
                return View(category);
            //if (Image.ContentLength > 0)
            //{
            var fileName = Path.GetFileName(Image.FileName);
            var path = Path.Combine(Server.MapPath("~/Content/images"), fileName);
            Image.SaveAs(path);
            category.Image = fileName;
            // }
            CategoryService.Insert(category);
            return RedirectToAction("Index");
        }
        public ActionResult update(int id)
        {

            return View(CategoryService.GetById(id));
        }
        [HttpPost]
        public ActionResult update(int id, CategoryViewModel category)
        {
            if (ModelState.IsValid == false)
                return View(category);
            CategoryService.Update(category);
            return RedirectToAction("Index");
        }
        public ActionResult delete(int id)
        {
            return View(CategoryService.GetById(id));
        }
        [HttpPost]
        public ActionResult delete(int id, CategoryViewModel categoryViewModel)
        {

            CategoryService.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(CategoryService.GetById(id));
        }

        [HttpPost]
        public ActionResult products(int id)
        {
            ///not created
            CategoryService.GetById(id);
            return RedirectToAction("Index");
        }

    }
}