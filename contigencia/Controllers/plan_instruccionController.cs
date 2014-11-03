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
    public class plan_instruccionController : Controller
    {
        private contingenciaEntities db = new contingenciaEntities();

        // GET: plan_instruccion
        public ActionResult Index()
        {
            var plan_instruccion = db.plan_instruccion.Include(p => p.instruccione).Include(p => p.planescontingencia);
            return View(plan_instruccion.ToList());
        }

        // GET: plan_instruccion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            plan_instruccion plan_instruccion = db.plan_instruccion.Find(id);
            if (plan_instruccion == null)
            {
                return HttpNotFound();
            }
            return View(plan_instruccion);
        }

        // GET: plan_instruccion/Create
        public ActionResult Create()
        {
            ViewBag.id_instrucciones = new SelectList(db.instrucciones, "id", "descripcion");
            ViewBag.id_planescontigencia = new SelectList(db.planescontingencias, "id", "descripcion");
            return View();
        }

        // POST: plan_instruccion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_planescontigencia,id_instrucciones,id")] plan_instruccion plan_instruccion)
        {
            if (ModelState.IsValid)
            {
                db.plan_instruccion.Add(plan_instruccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_instrucciones = new SelectList(db.instrucciones, "id", "descripcion", plan_instruccion.id_instrucciones);
            ViewBag.id_planescontigencia = new SelectList(db.planescontingencias, "id", "descripcion", plan_instruccion.id_planescontigencia);
            return View(plan_instruccion);
        }

        // GET: plan_instruccion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            plan_instruccion plan_instruccion = db.plan_instruccion.Find(id);
            if (plan_instruccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_instrucciones = new SelectList(db.instrucciones, "id", "descripcion", plan_instruccion.id_instrucciones);
            ViewBag.id_planescontigencia = new SelectList(db.planescontingencias, "id", "descripcion", plan_instruccion.id_planescontigencia);
            return View(plan_instruccion);
        }

        // POST: plan_instruccion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_planescontigencia,id_instrucciones,id")] plan_instruccion plan_instruccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan_instruccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_instrucciones = new SelectList(db.instrucciones, "id", "descripcion", plan_instruccion.id_instrucciones);
            ViewBag.id_planescontigencia = new SelectList(db.planescontingencias, "id", "descripcion", plan_instruccion.id_planescontigencia);
            return View(plan_instruccion);
        }

        // GET: plan_instruccion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            plan_instruccion plan_instruccion = db.plan_instruccion.Find(id);
            if (plan_instruccion == null)
            {
                return HttpNotFound();
            }
            return View(plan_instruccion);
        }

        // POST: plan_instruccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            plan_instruccion plan_instruccion = db.plan_instruccion.Find(id);
            db.plan_instruccion.Remove(plan_instruccion);
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
