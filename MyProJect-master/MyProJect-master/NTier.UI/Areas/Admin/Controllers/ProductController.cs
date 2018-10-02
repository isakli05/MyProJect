using NTier.Model.Model.Entities;
using NTier.Service.Service.Option;
using NTier.UI.Areas.Admin.Models;
using NTier.UI.Attributes;
using NTier.Utility;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTier.UI.Areas.Admin.Controllers
{
    [Role("Admin")]
    public class ProductController : Controller
    {
        ProductService _productService;
        CategoryService _categoryService;

        public ProductController()
        {
            _productService = new ProductService();
            _categoryService = new CategoryService();
        }

        public ViewResult List(int page = 1) => View(_productService.GetActive().OrderByDescending(x => x.CreatedDate).ToPagedList(page, 10));


        [HttpGet]
        public ViewResult Add()
        {
            TempData["KategoriListesi"] = _categoryService.GetActive();
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult Add(Product data, HttpPostedFileBase Image)
        {
            data.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/", Image);

            if (data.ImagePath == "0" || data.ImagePath == "1" || data.ImagePath == "2")
            {
                data.ImagePath = "/Uploads/foodanon.jpg";
            }
            _productService.Add(data);
            return RedirectToAction("List", "Product", new { area = "Admin" });
        }

        public RedirectToRouteResult Delete(Guid? id)
        {
            if (id == null) return RedirectToAction("List", "Product", new { area = "Admin" });
            _productService.Remove((Guid)id);
            return RedirectToAction("List", "Product", new { area = "Admin" });
        }

        [HttpGet]
        public ActionResult Update(Guid? id)
        {
            if (id == null) return RedirectToAction("List", "Product", new { area = "Admin" });

            Product data = _productService.GetById((Guid)id);

            ProductVM model = new ProductVM()
            {
                ID = data.ID,
                Name = data.Name,
                Price = data.Price,
                UnitsInStock = data.UnitsInStock,
                CategoryID = data.CategoryID,
                ImagePath = data.ImagePath,
                Quantity = data.Quantity,
                Status = data.Status
            };
            TempData["KategoriListesi"] = _categoryService.GetActive();

            return View(model);
        }

        [HttpPost]
        public RedirectToRouteResult Update(ProductVM data, HttpPostedFileBase Image)
        {
            Product product = _productService.GetById(data.ID);

            data.ImagePath = ImageUploader.UploadSingleImage("/Uploads/", Image);

            if (data.ImagePath != "0" && data.ImagePath != "1" && data.ImagePath != "2")
            {
                product.ImagePath = data.ImagePath;
            }

            product.Name = data.Name;
            product.Price = data.Price;
            product.UnitsInStock = data.UnitsInStock;
            product.Quantity = data.Quantity;
            product.CategoryID = data.CategoryID;
            product.Status = (NTier.Core.Core.Entity.Enum.Status)data.Status;
            _productService.Update(product);

            return RedirectToAction("List", "Product", new { area = "Admin" });
        }
    }
}