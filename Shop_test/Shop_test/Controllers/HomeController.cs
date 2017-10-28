using Shop_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Shop_test.Controllers
{
    public class HomeController : Controller
    {
        shopsDBEntities db = new shopsDBEntities();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult AllShopsList()
        {
            List<Shops> lShops = db.Shops.ToList();
            return Json(lShops, JsonRequestBehavior.AllowGet);
        }
    }
}
