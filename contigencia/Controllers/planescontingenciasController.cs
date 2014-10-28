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
    public class planescontingenciasController : Controller
    {
        private contingenciaEntities db = new contingenciaEntities();

        // GET: planescontingencias
        public ActionResult Index()
        {
            return View(db.planescontingencias.ToList());
        }

        // GET: planescontingencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            planescontingencia planescontingencia = db.planescontingencias.Find(id);
            if (planescontingencia == null)
            {
                return HttpNotFound();
            }
            return View(planescontingencia);
        }

        // GET: planescontingencias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: planescontingencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion,activo")] planescontingencia planescontingencia)
        {
            if (ModelState.IsValid)
            {
                db.planescontingencias.Add(planescontingencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(planescontingencia);
        }

        // GET: planescontingencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            planescontingencia planescontingencia = db.planescontingencias.Find(id);
            if (planescontingencia == null)
            {
                return HttpNotFound();
            }
            return View(planescontingencia);
        }

        // POST: planescontingencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion,activo")] planescontingencia planescontingencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planescontingencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(planescontingencia);
        }

        // GET: planescontingencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            planescontingencia planescontingencia = db.planescontingencias.Find(id);
            if (planescontingencia == null)
            {
                return HttpNotFound();
            }
            return View(planescontingencia);
        }

        // POST: planescontingencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            planescontingencia planescontingencia = db.planescontingencias.Find(id);
            db.planescontingencias.Remove(planescontingencia);
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
