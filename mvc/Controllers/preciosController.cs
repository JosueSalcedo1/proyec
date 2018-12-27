using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvc.Entity;

namespace mvc.Controllers
{
    public class preciosController : Controller
    {
        private Model1 db = new Model1();

        // GET: precios
        public ActionResult Index()
        {
            return View(db.precios.ToList());
        }

        // GET: precios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            precios precios = db.precios.Find(id);
            if (precios == null)
            {
                return HttpNotFound();
            }
            return View(precios);
        }

        // GET: precios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: precios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "precio,valor_total")] precios precios)
        {
            if (ModelState.IsValid)
            {
                db.precios.Add(precios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(precios);
        }

        // GET: precios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            precios precios = db.precios.Find(id);
            if (precios == null)
            {
                return HttpNotFound();
            }
            return View(precios);
        }

        // POST: precios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "precio,valor_total")] precios precios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(precios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(precios);
        }

        // GET: precios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            precios precios = db.precios.Find(id);
            if (precios == null)
            {
                return HttpNotFound();
            }
            return View(precios);
        }

        // POST: precios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            precios precios = db.precios.Find(id);
            db.precios.Remove(precios);
            db.SaveChanges();
            return RedirectToAction("Index");
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
