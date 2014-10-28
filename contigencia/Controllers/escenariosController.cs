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
    public class escenariosController : Controller
    {
        private contingenciaEntities db = new contingenciaEntities();

        // GET: escenarios
        public ActionResult Index()
        {
            return View(db.escenarios.ToList());
        }

        // GET: escenarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            escenario escenario = db.escenarios.Find(id);
            if (escenario == null)
            {
                return HttpNotFound();
            }
            return View(escenario);
        }

        // GET: escenarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: escenarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,activo")] escenario escenario)
        {
            if (ModelState.IsValid)
            {
                db.escenarios.Add(escenario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(escenario);
        }

        // GET: escenarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            escenario escenario = db.escenarios.Find(id);
            if (escenario == null)
            {
                return HttpNotFound();
            }
            return View(escenario);
        }

        // POST: escenarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,activo")] escenario escenario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(escenario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(escenario);
        }

        // GET: escenarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            escenario escenario = db.escenarios.Find(id);
            if (escenario == null)
            {
                return HttpNotFound();
            }
            return View(escenario);
        }

        // POST: escenarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            escenario escenario = db.escenarios.Find(id);
            db.escenarios.Remove(escenario);
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
