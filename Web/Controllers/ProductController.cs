using BL.AppServices;
using BL.ViewModels;
using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        ProductAppService productAppService = new ProductAppService();
        CategoryAppService categoryAppService = new CategoryAppService();
        ColorAppService colorAppService = new ColorAppService();
        public ActionResult Index()
        {
            IEnumerable<Product> products = productAppService.GetAll();
            return View(products);
        }
        [HttpGet]
        public ActionResult Create()
        {
            IEnumerable<Category> categories = categoryAppService.GetAll();
            IEnumerable<Color> colors = colorAppService.GetAll();
            AddProductVM addProductVM = new AddProductVM();
            addProductVM.Categories = categories;
            addProductVM.Colors = colors;
            return View(addProductVM);
        }

        [HttpPost]
        public ActionResult Create(AddProductVM newProduct, HttpPostedFileBase firstImage, HttpPostedFileBase secondImage)
        {
           
            if (ModelState.IsValid == false)
            {
                IEnumerable<Category> categories = categoryAppService.GetAll();
                IEnumerable<Color> Colors = colorAppService.GetAll();
                newProduct.Categories = categories;
                newProduct.Colors = Colors;
                return View(newProduct);
            }
            var FirstfileName = Path.GetFileName(firstImage.FileName);
            var path = Path.Combine(Server.MapPath("~/Content/images"), FirstfileName);
            firstImage.SaveAs(path);
            newProduct.MainImage = FirstfileName;

            var SecondfileName = Path.GetFileName(secondImage.FileName);
            var path2 = Path.Combine(Server.MapPath("~/Content/images"), SecondfileName);
            secondImage.SaveAs(path2);
            newProduct.SecondaryImage = SecondfileName;
            productAppService.Insert(newProduct);
            //productAppService.AssignColorToProduct(productIdentity, productIdentity.ColorID);
            TempData["successMsg"] = "New product added successfully";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            IEnumerable<Category> categories = categoryAppService.GetAll();
            IEnumerable<Color> Colors = colorAppService.GetAll();
            ViewBag.categories = categories;
            ViewData["Colors"] = Colors;
            Product product = productAppService.GetById(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(AddProductVM product)
        {
            IEnumerable<Category> categories = categoryAppService.GetAll();
            IEnumerable<Color> Colors = colorAppService.GetAll();
            ViewBag.categories = categories;
            ViewData["Colors"] = Colors;
            if (ModelState.IsValid)
            {
                productAppService.Update(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            productAppService.Delete(id);
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public ActionResult Show(int id)
        {
            Product product = productAppService.GetById(id);
            Color productColor = colorAppService.GetByID(product.ColorID);
            Category productCategory = categoryAppService.GetCateoryById(product.CategoryID);
            product.Color = productColor;
            product.Category = productCategory;
            return View(product);
        }
    }
}