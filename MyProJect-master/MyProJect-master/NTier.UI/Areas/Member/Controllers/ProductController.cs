using NTier.Core.Core.Entity.Enum;
using NTier.Service.Service.Option;
using NTier.UI.Attributes;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTier.UI.Areas.Member.Controllers
{
    [Role("admin", "member")]
    public class ProductController : Controller
    {
        ProductService _productService;
        public ProductController()
        {
            _productService = new ProductService();
        }

        //public ViewResult List(int page = 1) => View(_productService.GetActive().OrderByDescending(x => x.CreatedDate).ToPagedList(page, 10));

        public ActionResult List(Guid? id, int page = 1)
        {
            if (id != null)
            {
                //return View(_productService.GetDefault(x => x.CategoryID == id && x.Status==Status.Active || x.Status==Status.Updated).ToPagedList(page, 5));
                return View(_productService.GetActive().OrderByDescending(x => x.CreatedDate).ToPagedList(page, 8));
            }
            return RedirectToAction("Index", "Category", new { area = "Member" });
        }

        public ActionResult Detail(Guid id)
        {
            if (id != null)
            {
                return View(_productService.GetById(id));
            }
            return RedirectToAction("Index", "Category", new { area = "" });
        }
    }
}