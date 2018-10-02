using NTier.Model.Model.Entities;
using NTier.Service.Service.Option;
using NTier.UI.Attributes;
using NTier.UI.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTier.UI.Areas.Member.Controllers
{
    [Role("admin", "member")]
    public class OrderController : Controller
    {
        AppUserService _appUserService;
        ProductService _productService;
        OrderService _orderService;

        public OrderController()
        {
            _appUserService = new AppUserService();
            _productService = new ProductService();
            _orderService = new OrderService();
        }



        public RedirectToRouteResult Checkout()
        {
            //Sepet boşsa kategori listesine döndür.
            if (Session["sepet"] == null)
            {
                return RedirectToAction("Index", "Category", new { area = "Member" });
            }
            //Sepeti yakalıyoruz.
            ProductCart cart = Session["sepet"] as ProductCart;

            //Yeni sipariş oluşturuyoruz.
            Order o = new Order();

            //Siparişi yapacak kişinin id'sini yakalıyoruz ve siparişe ekliyoruz.
            o.AppUserID = _appUserService.FindByUserName(HttpContext.User.Identity.Name).ID;


            //Sepetteki tüm ürünlerde geziyoruz. Her ürün için siparişimizin ürün detay listesine yeni bir sipariş detay oluşturuyoruz.
            foreach (var item in cart.CartProductList)
            {
                o.OrderDetails.Add(new OrderDetail
                {
                    ProductID = item.Id,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                });
            }

            //Adminden onay bekleyececği için false yapıyoruz.
            o.isConfirmed = false;

            _orderService.Add(o);

            return RedirectToAction("Index", "Category", new { area = "Member" });
        }
    }
}