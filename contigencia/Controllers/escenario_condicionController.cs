using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using contigencia.Models;

namespace contigencia.Controllers
{
    public class escenario_condicionController : Controller
    {
        private contingenciaEntities db = new contingenciaEntities();

        // GET: escenario_condicion
        public ActionResult Index()
        {
            var escenario_condicion = db.escenario_condicion.Include(e => e.condicione).Include(e => e.escenario);
            return View(escenario_condicion.ToList());
        }

        // GET: escenario_condicion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            escenario_condicion escenario_condicion = db.escenario_condicion.Find(id);
            if (escenario_condicion == null)
            {
                return HttpNotFound();
            }
            return View(escenario_condicion);
        }

        // GET: escenario_condicion/Create
        public ActionResult Create()
        {
            ViewBag.id_condiciones = new SelectList(db.condiciones, "id", "nombre");
            ViewBag.id_escenarios = new SelectList(db.escenarios, "id", "nombre");
            return View();
        }

        // POST: escenario_condicion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_escenarios,id_condiciones,activo,id")] escenario_condicion escenario_condicion)
        {
            if (ModelState.IsValid)
            {
                db.escenario_condicion.Add(escenario_condicion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_condiciones = new SelectList(db.condiciones, "id", "nombre", escenario_condicion.id_condiciones);
            ViewBag.id_escenarios = new SelectList(db.escenarios, "id", "nombre", escenario_condicion.id_escenarios);
            return View(escenario_condicion);
        }

        // GET: escenario_condicion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            escenario_condicion escenario_condicion = db.escenario_condicion.Find(id);
            if (escenario_condicion == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_condiciones = new SelectList(db.condiciones, "id", "nombre", escenario_condicion.id_condiciones);
            ViewBag.id_escenarios = new SelectList(db.escenarios, "id", "nombre", escenario_condicion.id_escenarios);
            return View(escenario_condicion);
        }

        // POST: escenario_condicion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_escenarios,id_condiciones,activo,id")] escenario_condicion escenario_condicion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(escenario_condicion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_condiciones = new SelectList(db.condiciones, "id", "nombre", escenario_condicion.id_condiciones);
            ViewBag.id_escenarios = new SelectList(db.escenarios, "id", "nombre", escenario_condicion.id_escenarios);
            return View(escenario_condicion);
        }

        // GET: escenario_condicion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            escenario_condicion escenario_condicion = db.escenario_condicion.Find(id);
            if (escenario_condicion == null)
            {
                return HttpNotFound();
            }
            return View(escenario_condicion);
        }

        // POST: escenario_condicion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            escenario_condicion escenario_condicion = db.escenario_condicion.Find(id);
            db.escenario_condicion.Remove(escenario_condicion);
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
