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
    public class condicionesController : Controller
    {
        private ContingenciaEntities db = new ContingenciaEntities();

        // GET: condiciones
        public ActionResult Index()
        {
            return View(db.Condiciones.ToList());
        }

        // GET: condiciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           Condicion condicione = db.Condiciones.Find(id);
            if (condicione == null)
            {
                return HttpNotFound();
            }
            return View(condicione);
        }

        // GET: condiciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: condiciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,activo,descripcion")] Condicion condicione)
        {
            if (ModelState.IsValid)
            {
                db.Condiciones.Add(condicione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(condicione);
        }

        // GET: condiciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condicion condicione = db.Condiciones.Find(id);
            if (condicione == null)
            {
                return HttpNotFound();
            }
            return View(condicione);
        }

        // POST: condiciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,activo,descripcion")] Condicion condicione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(condicione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(condicione);
        }

        // GET: condiciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condicion condicione = db.Condiciones.Find(id);
            if (condicione == null)
            {
                return HttpNotFound();
            }
            return View(condicione);
        }

        // POST: condiciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Condicion condicione = db.Condiciones.Find(id);
            db.Condiciones.Remove(condicione);
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
