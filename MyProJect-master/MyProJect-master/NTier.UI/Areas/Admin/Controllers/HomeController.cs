using NTier.Service.Service.Option;
using NTier.UI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTier.UI.Areas.Admin.Controllers
{
    [Role("Admin")]
    public class HomeController : Controller
    {
        OrderService _orderService;
        public HomeController() => _orderService = new OrderService();

        public ActionResult Index()
        {
            ViewBag.OrderCount = _orderService.PendingOrderCount();
            return View();
        }
    }
}