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
    public class escenariosController : Controller
    {
        private ContingenciaEntities db = new ContingenciaEntities();

        // GET: escenarios
        public ActionResult Index()
        {
            return View(db.Escenarios.ToList());
        }

        // GET: escenarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escenario escenario = db.Escenarios.Find(id);
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
        public ActionResult Create([Bind(Include = "id,nombre,activo")] Escenario escenario)
        {
            if (ModelState.IsValid)
            {
                db.Escenarios.Add(escenario);
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
            Escenario escenario = db.Escenarios.Find(id);
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
        public ActionResult Edit([Bind(Include = "id,nombre,activo")] Escenario escenario)
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
            Escenario escenario = db.Escenarios.Find(id);
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
            Escenario escenario = db.Escenarios.Find(id);
            db.Escenarios.Remove(escenario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: escenarios/AddConditions/5
        public ActionResult AddConditions(int? id)
        {  

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var escenaryCondViewModel = new EscenarioCondicionesViewModel()
            {
                escenary = db.Escenarios.Include(i => i.Condicion).First(i => i.id == id)
            };

            if (escenaryCondViewModel.escenary == null)
                return HttpNotFound();

            var allConditions = db.Condiciones.ToList();
            escenaryCondViewModel.AllConditions = allConditions.Select(o => new SelectListItem
            {
                Text = o.nombre,
                Value = o.id.ToString()
            });

            //ViewBag.EmployerID =
            //        new SelectList(db.Employers, "Id", "FullName", jobpostViewModel.JobPost.EmployerID);

            return View(escenaryCondViewModel);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]//[Bind(Include = "id,nombre,activo")] 
        public ActionResult AddConditions(EscenarioCondicionesViewModel escenarioCondicionesVM)
        {
            if (ModelState.IsValid)
            {

                var escenario = db.Escenarios.Find(escenarioCondicionesVM.escenary.id);

                if(escenario!= null)
                {
                    //primero borro todo y despues agrego
                    escenario.Condicion.Clear();

                    foreach (int idCondicion in escenarioCondicionesVM.SelectedConditions)
                    {
                        Condicion condicion = db.Condiciones.Find(idCondicion);

                        escenario.Condicion.Add(condicion);
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(escenarioCondicionesVM);
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
