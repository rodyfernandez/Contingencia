using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using contigencia.Models;
using contigencia.Models.ViewModels;

namespace contigencia.Controllers
{
    public class destinatariosController : Controller
    {
        private ContingenciaEntities db = new ContingenciaEntities();

        // GET: destinatarios
        public ActionResult Index()
        {
            var destinatarios = db.Destinatarios.Include(d => d.PlanContingencia);
            return View(destinatarios.ToList());
        }

        // GET: destinatarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destinatario destinatario = db.Destinatarios.Find(id);
            if (destinatario == null)
            {
                return HttpNotFound();
            }
            return View(destinatario);
        }

        // GET: destinatarios/Create
        public ActionResult Create()
        {
            ViewBag.id_planescontigencia = new SelectList(db.PlanContingencias, "id", "descripcion");
            return View();
        }

        // POST: destinatarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,descripcion,activo,id_planescontigencia")] Destinatario destinatario)
        {
            if (ModelState.IsValid)
            {
                db.Destinatarios.Add(destinatario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_planescontigencia = new SelectList(db.PlanContingencias, "id", "descripcion", destinatario.id_planescontigencia);
            return View(destinatario);
        }

        // GET: destinatarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destinatario destinatario = db.Destinatarios.Find(id);
            if (destinatario == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_planescontigencia = new SelectList(db.PlanContingencias, "id", "descripcion", destinatario.id_planescontigencia);
            return View(destinatario);
        }

        // POST: destinatarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,descripcion,activo,id_planescontigencia")] Destinatario destinatario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(destinatario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_planescontigencia = new SelectList(db.PlanContingencias, "id", "descripcion", destinatario.id_planescontigencia);
            return View(destinatario);
        }

        // GET: destinatarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destinatario destinatario = db.Destinatarios.Find(id);
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
            Destinatario destinatario = db.Destinatarios.Find(id);
            db.Destinatarios.Remove(destinatario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: escenarios/AddPersons/5
        public ActionResult AddPersons(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var destinatarioPersonas = new DestinatarioPersonasViewModel()
            {
                destinatario = db.Destinatarios.Include(i => i.Persona).First(i => i.id == id)
            };

            if (destinatarioPersonas.destinatario == null)
                return HttpNotFound();

            
            var allPersonas = db.Personas.ToList();
            destinatarioPersonas.allPersonas = allPersonas.Select(o => new SelectListItem
            {
                Text = o.razon_social,
                Value = o.id.ToString()
            });

            return View(destinatarioPersonas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//[Bind(Include = "id,nombre,activo")] 
        public ActionResult AddPersons(DestinatarioPersonasViewModel destinatarioPersonaVM)
        {
            if (ModelState.IsValid)
            {

                var destinatario = db.Destinatarios.Find(destinatarioPersonaVM.destinatario.id);

                if (destinatario != null)
                {
                    //primero borro todo y despues agrego
                    destinatario.Persona.Clear();

                    foreach (int idPersona in destinatarioPersonaVM.SelectedPersonas)
                    {
                        Persona persona = db.Personas.Find(idPersona);

                        destinatario.Persona.Add(persona);
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(destinatarioPersonaVM);
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
