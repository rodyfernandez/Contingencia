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
    public class planescontingenciasController : Controller
    {
        private ContingenciaEntities db = new ContingenciaEntities();

        // GET: planescontingencias
        public ActionResult Index()
        {
            return View(db.PlanContingencias.ToList());
        }

        // GET: planescontingencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanContingencia planescontingencia = db.PlanContingencias.Find(id);
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
        public ActionResult Create([Bind(Include = "id,descripcion,activo")] PlanContingencia planescontingencia)
        {
            if (ModelState.IsValid)
            {
                db.PlanContingencias.Add(planescontingencia);
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
            PlanContingencia planescontingencia = db.PlanContingencias.Find(id);
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
        public ActionResult Edit([Bind(Include = "id,descripcion,activo")] PlanContingencia planescontingencia)
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
            PlanContingencia planescontingencia = db.PlanContingencias.Find(id);
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
            PlanContingencia planescontingencia = db.PlanContingencias.Find(id);
            db.PlanContingencias.Remove(planescontingencia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




        // GET: escenarios/AddEscenaries/5
        public ActionResult AddEscenaries(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var planEscenarios = new PlanEscenariosViewModel()
            {
                plan = db.PlanContingencias.Include(i => i.Escenario).First(i => i.id == id)
            };

            if (planEscenarios.plan == null)
                return HttpNotFound();

            var allEscenarios = db.Escenarios.ToList();
            planEscenarios.allEscenaries = allEscenarios.Select(o => new SelectListItem
            {
                Text = o.nombre,
                Value = o.id.ToString()
            });

            return View(planEscenarios);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//[Bind(Include = "id,nombre,activo")] 
        public ActionResult AddEscenaries(PlanEscenariosViewModel planEscenarioVM)
        {
            if (ModelState.IsValid)
            {

                var plan = db.PlanContingencias.Find(planEscenarioVM.plan.id);

                if (plan != null)
                {
                    //primero borro todo y despues agrego
                    plan.Escenario.Clear();

                    foreach (int idEscenario in planEscenarioVM.SelectedEscenaries)
                    {
                        Escenario escenario = db.Escenarios.Find(idEscenario);

                        plan.Escenario.Add(escenario);
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(planEscenarioVM);
        }



        // GET: escenarios/AddInstructions/5
        public ActionResult AddInstructions(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var planInstrucciones = new PlanInstruccionesViewModel()
            {
                plan = db.PlanContingencias.Include(i => i.Instruccion).First(i => i.id == id)
            };

            if (planInstrucciones.plan == null)
                return HttpNotFound();

            var allInstrucciones = db.Instrucciones.ToList();
            planInstrucciones.allInstructions = allInstrucciones.Select(o => new SelectListItem
            {
                Text = o.descripcion,
                Value = o.id.ToString()
            });

            return View(planInstrucciones);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//[Bind(Include = "id,nombre,activo")] 
        public ActionResult AddInstructions(PlanInstruccionesViewModel planInstruccionesVM)
        {
            if (ModelState.IsValid)
            {

                var plan = db.PlanContingencias.Find(planInstruccionesVM.plan.id);

                if (plan != null)
                {
                    //primero borro todo y despues agrego
                    plan.Instruccion.Clear();

                    foreach (int idInstruccion in planInstruccionesVM.SelectedInstructions)
                    {
                        Instruccion instruccion = db.Instrucciones.Find(idInstruccion);

                        plan.Instruccion.Add(instruccion);
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(planInstruccionesVM);
        }



        // GET: planescontingencias
        public ActionResult Simulation()
        {
            return View(db.Escenarios.Include(e => e.PlanContingencia).Include(e=> e.Condicion).ToList());
        }

        public ActionResult SimulacionManualPlanContigencia(int id)
        {
            return View(db.PlanContingencias.Find(id));
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
