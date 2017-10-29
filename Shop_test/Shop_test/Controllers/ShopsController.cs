using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shop_test.Models;

namespace Shop_test.Controllers
{
    public class ShopsController : Controller
    {
        private shopsDBEntities db = new shopsDBEntities();

        // GET: Shops
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult AllShopsList()
        {
            var lShops = db.Shops.Select(s=> new { s.ShopId, s.Shop_adress, s.Shop_name, s.Shop_time }).ToList();
            return Json(lShops, JsonRequestBehavior.AllowGet);
        }

        // GET: Shops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shops shops = db.Shops.Find(id);
            if (shops == null)
            {
                return HttpNotFound();
            }
            return View(shops);
        }

        // GET: Shops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shops/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Create( Shops shops)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    db.Shops.Add(shops);
                    db.SaveChanges();
                    return Json(shops, JsonRequestBehavior.AllowGet);
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // GET: Shops/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // POST: Shops/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Edit( Shops shops )
        {
            try
            {

                if (ModelState.IsValid)
                {
                    db.Entry(shops).State = EntityState.Modified;
                    db.SaveChanges();
                    var lResult = db.Shops.Select(s => new {
                        s.ShopId,
                        s.Shop_adress,
                        s.Shop_name,
                        s.Shop_time }).ToList();
                    return Json(lResult, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        // GET: Shops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shops shops = db.Shops.Find(id);
            if (shops == null)
            {
                return HttpNotFound();
            }
            return View(shops);
        }

        // POST: Shops/Delete/5
        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(int id)
        {
            try
            {
                Shops shops = db.Shops.Find(id);

                List<Products> lProducts = db.Products.Where(s => s.ShopId == id).ToList();

                foreach (Products Product in lProducts)
                {
                    db.Products.Remove(Product);
                    db.SaveChanges();
                }

                db.Shops.Remove(shops);
                db.SaveChanges();

                var lResult = db.Shops.Select(s => new {
                    s.ShopId,
                    s.Shop_adress,
                    s.Shop_name,
                    s.Shop_time
                }).ToList();

                return Json(lResult, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
