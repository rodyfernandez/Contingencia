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
    public class NivelesRiesgoController : Controller
    {
        private ContingenciaEntities db = new ContingenciaEntities();

        // GET: /NivelesRiesgo/
        public ActionResult Index()
        {
            return View(db.NivelesDeRiesgo.OrderBy(r=>r.prioridad).ToList());
        }

        // GET: /NivelesRiesgo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NivelesDeRiesgo nivelesderiesgo = db.NivelesDeRiesgo.Find(id);
            if (nivelesderiesgo == null)
            {
                return HttpNotFound();
            }
            return View(nivelesderiesgo);
        }

        // GET: /NivelesRiesgo/Create
        public ActionResult Create()
        {
            ViewBag.Color = string.Empty;
            return View();
        }

        // POST: /NivelesRiesgo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,descripcion,color, prioridad")] NivelesDeRiesgo nivelesderiesgo)
        {
            if (ModelState.IsValid)
            {
                db.NivelesDeRiesgo.Add(nivelesderiesgo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nivelesderiesgo);
        }

        // GET: /NivelesRiesgo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NivelesDeRiesgo nivelesderiesgo = db.NivelesDeRiesgo.Find(id);
            if (nivelesderiesgo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Color = nivelesderiesgo.color;
            return View( nivelesderiesgo);
        }

        // POST: /NivelesRiesgo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,descripcion,color, prioridad")] NivelesDeRiesgo nivelesderiesgo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nivelesderiesgo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nivelesderiesgo);
        }

        // GET: /NivelesRiesgo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NivelesDeRiesgo nivelesderiesgo = db.NivelesDeRiesgo.Find(id);
            if (nivelesderiesgo == null)
            {
                return HttpNotFound();
            }
            return View(nivelesderiesgo);
        }

        // POST: /NivelesRiesgo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NivelesDeRiesgo nivelesderiesgo = db.NivelesDeRiesgo.Find(id);
            db.NivelesDeRiesgo.Remove(nivelesderiesgo);
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
