using NTier.Model.Model.Entities;
using NTier.Service.Service.Option;
using NTier.UI.Attributes;
using NTier.UI.Cart;
using NTier.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTier.UI.Controllers
{
    [RoleAttribute("admin", "member")]
    public class CartController : Controller
    {
        ProductService _productService;
        public CartController()
        {
            _productService = new ProductService();
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {

            if (Session["sepet"] != null)
            {
                ProductCart cart = Session["sepet"] as ProductCart;
                List<CartProductVM> productList = cart.CartProductList.Select(x => new CartProductVM
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    UnitPrice = x.UnitPrice,
                    Quantity = x.Quantity
                }).ToList();
                return Json(productList, JsonRequestBehavior.AllowGet);
            }

            return Json("Empty", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(Guid id)
        {

            Product eklenecek = _productService.GetById(id);

            CartProductVM model = new CartProductVM
            {
                Id = eklenecek.ID,
                ImagePath = eklenecek.ImagePath,
                ProductName = eklenecek.Name,
                UnitPrice = eklenecek.Price,
                Quantity = 1
            };


            if (Session["sepet"] != null)
            {

                ProductCart cart = Session["sepet"] as ProductCart;
                cart.AddCart(model);

                Session["sepet"] = cart;
            }
            else
            {

                ProductCart cart = new ProductCart();

                cart.AddCart(model);
                Session.Add("sepet", cart);
            }


            return Json("");
        }

        public JsonResult DecreaseCart(Guid id)
        {

            if (Session["sepet"] != null)
            {
                ProductCart cart = Session["sepet"] as ProductCart;
                cart.DecreaseCart(id);
                Session["sepet"] = cart;
            }

            return Json("");
        }
        public ActionResult IncreaseCart(Guid id)
        {
            if (Session["sepet"] != null)
            {
                ProductCart cart = Session["sepet"] as ProductCart;
                cart.IncreaseCart(id);
                Session["sepet"] = cart;
            }
            return Json("");
        }
        public ActionResult Remove(Guid id)
        {
            if (Session["sepet"] != null)
            {
                ProductCart cart = Session["sepet"] as ProductCart;
                cart.RemoveCart(id);
                Session["sepet"] = cart;
            }
            return Json("");
        }
    }
}