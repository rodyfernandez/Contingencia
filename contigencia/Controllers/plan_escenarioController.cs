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
    public class plan_escenarioController : Controller
    {
        private contingenciaEntities db = new contingenciaEntities();

        // GET: plan_escenario
        public ActionResult Index()
        {
            var plan_escenario = db.plan_escenario.Include(p => p.escenario).Include(p => p.planescontingencia);
            return View(plan_escenario.ToList());
        }

        // GET: plan_escenario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            plan_escenario plan_escenario = db.plan_escenario.Find(id);
            if (plan_escenario == null)
            {
                return HttpNotFound();
            }
            return View(plan_escenario);
        }

        // GET: plan_escenario/Create
        public ActionResult Create()
        {
            ViewBag.id_escenarios = new SelectList(db.escenarios, "id", "nombre");
            ViewBag.id_planescontigencia = new SelectList(db.planescontingencias, "id", "descripcion");
            return View();
        }

        // POST: plan_escenario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_escenarios,id_planescontigencia,id,orden")] plan_escenario plan_escenario)
        {
            if (ModelState.IsValid)
            {
                db.plan_escenario.Add(plan_escenario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_escenarios = new SelectList(db.escenarios, "id", "nombre", plan_escenario.id_escenarios);
            ViewBag.id_planescontigencia = new SelectList(db.planescontingencias, "id", "descripcion", plan_escenario.id_planescontigencia);
            return View(plan_escenario);
        }

        // GET: plan_escenario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            plan_escenario plan_escenario = db.plan_escenario.Find(id);
            if (plan_escenario == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_escenarios = new SelectList(db.escenarios, "id", "nombre", plan_escenario.id_escenarios);
            ViewBag.id_planescontigencia = new SelectList(db.planescontingencias, "id", "descripcion", plan_escenario.id_planescontigencia);
            return View(plan_escenario);
        }

        // POST: plan_escenario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_escenarios,id_planescontigencia,id,orden")] plan_escenario plan_escenario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan_escenario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_escenarios = new SelectList(db.escenarios, "id", "nombre", plan_escenario.id_escenarios);
            ViewBag.id_planescontigencia = new SelectList(db.planescontingencias, "id", "descripcion", plan_escenario.id_planescontigencia);
            return View(plan_escenario);
        }

        // GET: plan_escenario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            plan_escenario plan_escenario = db.plan_escenario.Find(id);
            if (plan_escenario == null)
            {
                return HttpNotFound();
            }
            return View(plan_escenario);
        }

        // POST: plan_escenario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            plan_escenario plan_escenario = db.plan_escenario.Find(id);
            db.plan_escenario.Remove(plan_escenario);
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
