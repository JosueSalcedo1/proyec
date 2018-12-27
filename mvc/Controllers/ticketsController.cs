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
    public class ticketsController : Controller
    {
        private Model1 db = new Model1();

        // GET: tickets
        public ActionResult Index()
        {
            var tickets = db.tickets.Include(t => t.precios).Include(t => t.precios1).Include(t => t.precios2);
            return View(tickets.ToList());
        }

        // GET: tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tickets tickets = db.tickets.Find(id);
            if (tickets == null)
            {
                return HttpNotFound();
            }
            return View(tickets);
        }

        // GET: tickets/Create
        public ActionResult Create()
        {
            ViewBag.Soporte = new SelectList(db.precios, "precio", "precio");
            ViewBag.Requerimiento = new SelectList(db.precios, "precio", "precio");
            ViewBag.Incidencias = new SelectList(db.precios, "precio", "precio");
            return View();
        }

        // POST: tickets/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tickets1,Incidencias,Requerimiento,Soporte")] tickets tickets)
        {
            if (ModelState.IsValid)
            {
                db.tickets.Add(tickets);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Soporte = new SelectList(db.precios, "precio", "precio", tickets.Soporte);
            ViewBag.Requerimiento = new SelectList(db.precios, "precio", "precio", tickets.Requerimiento);
            ViewBag.Incidencias = new SelectList(db.precios, "precio", "precio", tickets.Incidencias);
            return View(tickets);
        }

        // GET: tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tickets tickets = db.tickets.Find(id);
            if (tickets == null)
            {
                return HttpNotFound();
            }
            ViewBag.Soporte = new SelectList(db.precios, "precio", "precio", tickets.Soporte);
            ViewBag.Requerimiento = new SelectList(db.precios, "precio", "precio", tickets.Requerimiento);
            ViewBag.Incidencias = new SelectList(db.precios, "precio", "precio", tickets.Incidencias);
            return View(tickets);
        }

        // POST: tickets/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tickets1,Incidencias,Requerimiento,Soporte")] tickets tickets)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tickets).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Soporte = new SelectList(db.precios, "precio", "precio", tickets.Soporte);
            ViewBag.Requerimiento = new SelectList(db.precios, "precio", "precio", tickets.Requerimiento);
            ViewBag.Incidencias = new SelectList(db.precios, "precio", "precio", tickets.Incidencias);
            return View(tickets);
        }

        // GET: tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tickets tickets = db.tickets.Find(id);
            if (tickets == null)
            {
                return HttpNotFound();
            }
            return View(tickets);
        }

        // POST: tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tickets tickets = db.tickets.Find(id);
            db.tickets.Remove(tickets);
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
