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
    public class ProductsController : Controller
    {
        private shopsDBEntities db = new shopsDBEntities();

        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult AllProductsList(int ShopId)
        {
            var lProducts = db.Products.Select(s => new {
                s.ShopId,
                s.productId,
                s.Product_name,
                s.Product_properties
            }).Where(s=>s.ShopId == ShopId).ToList();
            return Json(lProducts, JsonRequestBehavior.AllowGet);
        }
        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.ShopId = new SelectList(db.Shops, "ShopId", "Shop_name");
            return View();
        }

        // POST: Products/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Create( Products products)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    products.Shops = db.Shops.Find(products.ShopId);
                    db.Products.Add(products);
                    db.SaveChanges();
                    products.Shops = null;
                    return Json(products, JsonRequestBehavior.AllowGet);
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.ShopId = new SelectList(db.Shops, "ShopId", "Shop_name", products.ShopId);
            return View(products);
        }

        // POST: Products/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Edit(Products product)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    product.Shops = db.Shops.Find(product.ShopId);
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    var lResult = db.Products.Select(s=>new {
                        s.ShopId,
                        s.productId,
                        s.Product_name,
                        s.Product_properties})
                        .Where(s => s.ShopId == product.ShopId).ToList();
                    return Json(lResult, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(int id)
        {
            Products product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            var lResult = db.Products.Select(s => new {
                s.ShopId,
                s.productId,
                s.Product_name,
                s.Product_properties
            })
                .Where(s => s.ShopId == product.ShopId).ToList();
            return Json(lResult, JsonRequestBehavior.AllowGet);
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
