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
    public class destinatario_personaController : Controller
    {
        private contingenciaEntities db = new contingenciaEntities();

        // GET: destinatario_persona
        public ActionResult Index()
        {
            var destinatario_persona = db.destinatario_persona.Include(d => d.destinatario).Include(d => d.persona);
            return View(destinatario_persona.ToList());
        }

        // GET: destinatario_persona/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            destinatario_persona destinatario_persona = db.destinatario_persona.Find(id);
            if (destinatario_persona == null)
            {
                return HttpNotFound();
            }
            return View(destinatario_persona);
        }

        // GET: destinatario_persona/Create
        public ActionResult Create()
        {
            ViewBag.id_destinatarios = new SelectList(db.destinatarios, "id", "nombre");
            ViewBag.id_personas = new SelectList(db.personas, "id", "razon_social");
            return View();
        }

        // POST: destinatario_persona/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_destinatarios,id_personas,id")] destinatario_persona destinatario_persona)
        {
            if (ModelState.IsValid)
            {
                db.destinatario_persona.Add(destinatario_persona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_destinatarios = new SelectList(db.destinatarios, "id", "nombre", destinatario_persona.id_destinatarios);
            ViewBag.id_personas = new SelectList(db.personas, "id", "razon_social", destinatario_persona.id_personas);
            return View(destinatario_persona);
        }

        // GET: destinatario_persona/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            destinatario_persona destinatario_persona = db.destinatario_persona.Find(id);
            if (destinatario_persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_destinatarios = new SelectList(db.destinatarios, "id", "nombre", destinatario_persona.id_destinatarios);
            ViewBag.id_personas = new SelectList(db.personas, "id", "razon_social", destinatario_persona.id_personas);
            return View(destinatario_persona);
        }

        // POST: destinatario_persona/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_destinatarios,id_personas,id")] destinatario_persona destinatario_persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(destinatario_persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_destinatarios = new SelectList(db.destinatarios, "id", "nombre", destinatario_persona.id_destinatarios);
            ViewBag.id_personas = new SelectList(db.personas, "id", "razon_social", destinatario_persona.id_personas);
            return View(destinatario_persona);
        }

        // GET: destinatario_persona/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            destinatario_persona destinatario_persona = db.destinatario_persona.Find(id);
            if (destinatario_persona == null)
            {
                return HttpNotFound();
            }
            return View(destinatario_persona);
        }

        // POST: destinatario_persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            destinatario_persona destinatario_persona = db.destinatario_persona.Find(id);
            db.destinatario_persona.Remove(destinatario_persona);
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
