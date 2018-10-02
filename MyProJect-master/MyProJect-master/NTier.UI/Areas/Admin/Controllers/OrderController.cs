using NTier.Model.Model.Entities;
using NTier.Service.Service.Option;
using NTier.UI.Attributes;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTier.UI.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        OrderService _orderService;
        OrderDetailService _orderDetailService;
        ProductService _productService;
        public OrderController()
        {
            _orderService = new OrderService();
            _orderDetailService = new OrderDetailService();
            _productService = new ProductService();
        }

        public ViewResult List(int page = 1) => View(_orderService.ListPendingOrders().ToPagedList(page, 10));

        public ActionResult Detail(Guid? id)
        {
            if (id == null) return RedirectToAction("List", "Order", new { area = "Admin" });


            return View(_orderDetailService.GetDetailsByOrderID((Guid)id));
        }

        public RedirectToRouteResult ConfirmOrder(Guid id)
        {
            Order o = _orderService.GetById(id);
            o.isConfirmed = true;
            _orderService.Update(o);
            foreach (var item in o.OrderDetails)
            {
                Product p = _productService.GetById(item.ProductID);
                p.UnitsInStock -= (short)item.Quantity;
                _productService.Update(p);
            }

            return RedirectToAction("List", "Order", new { area = "Admin" });

        }
        public RedirectToRouteResult RejectOrder(Guid id)
        {
            Order o = _orderService.GetById(id);
            o.isConfirmed = false;
            o.Status = Core.Core.Entity.Enum.Status.Deleted;
            _orderService.Update(o);
            return RedirectToAction("List", "Order", new { area = "Admin" });
        }
    }
}