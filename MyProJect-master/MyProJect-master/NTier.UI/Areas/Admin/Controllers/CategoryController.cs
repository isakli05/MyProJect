using NTier.Model.Model.Entities;
using NTier.Service.Service.Option;
using NTier.UI.Areas.Admin.Models;
using NTier.UI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTier.UI.Areas.Admin.Controllers
{
    [Role("Admin")]
    public class CategoryController : Controller
    {
        CategoryService _categoryService;
        public CategoryController()
        {
            _categoryService = new CategoryService();
        }


        public ViewResult List() => View(_categoryService.GetActive());

        [HttpGet]
        public ViewResult Add() => View();

        [HttpPost]
        public RedirectToRouteResult Add(Category data)
        {
            _categoryService.Add(data);
            return RedirectToAction("List", "Category", new { area = "Admin" });
        }

        public RedirectToRouteResult Delete(Guid? id)
        {
            if (id == null) return RedirectToAction("List", "Category", new { area = "Admin" });
            _categoryService.Remove((Guid)id);
            return RedirectToAction("List", "Category", new { area = "Admin" });
        }

        [HttpGet]
        public ActionResult Update(Guid? id)
        {
            if (id == null) return RedirectToAction("List", "Category", new { area = "Admin" });

            Category cat = _categoryService.GetById((Guid)id);

            CategoryVM model = new CategoryVM()
            {
                ID = cat.ID,
                Name = cat.Name,
                Description = cat.Description
            };

            return View(model);
        }

        [HttpPost]
        public RedirectToRouteResult Update(CategoryVM data)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("List", "Category", new { area = "Admin" });
            }

            Category cat = _categoryService.GetById(data.ID);
            cat.Name = data.Name;
            cat.Description = data.Description;
            _categoryService.Update(cat);
            return RedirectToAction("List", "Category", new { area = "Admin" });
        }
    }
}