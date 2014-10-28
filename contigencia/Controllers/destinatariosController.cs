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
    public class destinatariosController : Controller
    {
        private contingenciaEntities db = new contingenciaEntities();

        // GET: destinatarios
        public ActionResult Index()
        {
            var destinatarios = db.destinatarios.Include(d => d.planescontingencia);
            return View(destinatarios.ToList());
        }

        // GET: destinatarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            destinatario destinatario = db.destinatarios.Find(id);
            if (destinatario == null)
            {
                return HttpNotFound();
            }
            return View(destinatario);
        }

        // GET: destinatarios/Create
        public ActionResult Create()
        {
            ViewBag.id_planescontigencia = new SelectList(db.planescontingencias, "id", "descripcion");
            return View();
        }

        // POST: destinatarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,descripcion,activo,id_planescontigencia")] destinatario destinatario)
        {
            if (ModelState.IsValid)
            {
                db.destinatarios.Add(destinatario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_planescontigencia = new SelectList(db.planescontingencias, "id", "descripcion", destinatario.id_planescontigencia);
            return View(destinatario);
        }

        // GET: destinatarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            destinatario destinatario = db.destinatarios.Find(id);
            if (destinatario == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_planescontigencia = new SelectList(db.planescontingencias, "id", "descripcion", destinatario.id_planescontigencia);
            return View(destinatario);
        }

        // POST: destinatarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,descripcion,activo,id_planescontigencia")] destinatario destinatario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(destinatario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_planescontigencia = new SelectList(db.planescontingencias, "id", "descripcion", destinatario.id_planescontigencia);
            return View(destinatario);
        }

        // GET: destinatarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            destinatario destinatario = db.destinatarios.Find(id);
            if (destinatario == null)
            {
                return HttpNotFound();
            }
            return View(destinatario);
        }

        // POST: destinatarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            destinatario destinatario = db.destinatarios.Find(id);
            db.destinatarios.Remove(destinatario);
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
