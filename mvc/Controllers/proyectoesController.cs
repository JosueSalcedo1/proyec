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
    public class proyectoesController : Controller
    {
        private Model1 db = new Model1();

        // GET: proyectoes
        public ActionResult Index()
        {
            var proyecto = db.proyecto.Include(p => p.clientes).Include(p => p.tickets);
            return View(proyecto.ToList());
        }

        // GET: proyectoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proyecto proyecto = db.proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // GET: proyectoes/Create
        public ActionResult Create()
        {
            ViewBag.cantidad = new SelectList(db.clientes, "id_clientes", "nombreCliente");
            ViewBag.cantidad = new SelectList(db.tickets, "tickets1", "tickets1");
            return View();
        }

        // POST: proyectoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "proyecto1,nombreProyecto,cantidad")] proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                db.proyecto.Add(proyecto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cantidad = new SelectList(db.clientes, "id_clientes", "nombreCliente", proyecto.cantidad);
            ViewBag.cantidad = new SelectList(db.tickets, "tickets1", "tickets1", proyecto.cantidad);
            return View(proyecto);
        }

        // GET: proyectoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proyecto proyecto = db.proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            ViewBag.cantidad = new SelectList(db.clientes, "id_clientes", "nombreCliente", proyecto.cantidad);
            ViewBag.cantidad = new SelectList(db.tickets, "tickets1", "tickets1", proyecto.cantidad);
            return View(proyecto);
        }

        // POST: proyectoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "proyecto1,nombreProyecto,cantidad")] proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proyecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cantidad = new SelectList(db.clientes, "id_clientes", "nombreCliente", proyecto.cantidad);
            ViewBag.cantidad = new SelectList(db.tickets, "tickets1", "tickets1", proyecto.cantidad);
            return View(proyecto);
        }

        // GET: proyectoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proyecto proyecto = db.proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // POST: proyectoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            proyecto proyecto = db.proyecto.Find(id);
            db.proyecto.Remove(proyecto);
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
