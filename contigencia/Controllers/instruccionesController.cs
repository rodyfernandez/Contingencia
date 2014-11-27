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
    public class instruccionesController : Controller
    {
        private ContingenciaEntities db = new ContingenciaEntities();

        // GET: instrucciones
        public ActionResult Index()
        {
            return View(db.Instrucciones.ToList());
        }

        // GET: instrucciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instruccion instruccione = db.Instrucciones.Find(id);
            if (instruccione == null)
            {
                return HttpNotFound();
            }
            return View(instruccione);
        }

        // GET: instrucciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: instrucciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion,activo")] Instruccion instruccione)
        {
            if (ModelState.IsValid)
            {
                SetFile(instruccione);
                db.Instrucciones.Add(instruccione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instruccione);
        }

        public FileContentResult DownloadInstructivo(int id)
        {
            var instruccion = db.Instrucciones.Find(id);
            var file = instruccion.Instructivo;
            var fileRes = new FileContentResult(file.ToArray(), "application/octet-stream");
            fileRes.FileDownloadName = instruccion.InstructivoNombre;
            return fileRes;
        }

        private void SetFile(Instruccion instruccion)
        {
            if (Request.Files.Count > 0)
            {

                HttpPostedFileBase file = Request.Files[0];
                byte[] fileSize = new byte[file.ContentLength];                                
                
                if (file.ContentLength == 0)
                {
                    MantengoFileGrabado(instruccion);
                }
                else
                {
                    file.InputStream.Read(fileSize, 0, (int)file.ContentLength);
                    instruccion.Instructivo = fileSize;
                    instruccion.InstructivoNombre = file.FileName;                    
                }
            }
            else
            {
                MantengoFileGrabado(instruccion);
            }
        }
        private void MantengoFileGrabado(Instruccion instruccion)
        {
            //Si el usuario no elige ninguna foto y el estudiante exisitia
            //mantengo la foto guardada, de lo contrario se borraria la misma
            Instruccion instruccionDB = null; // = estudianteRepository.FindAsNoTracking(estudiante.EstudianteId);


            if (instruccionDB != null)
                instruccion.Instructivo = instruccionDB.Instructivo;

            //estudiante.Foto = estudianteRepository.FindPhoto(estudiante.EstudianteId);
        }


        // GET: instrucciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instruccion instruccione = db.Instrucciones.Find(id);
            if (instruccione == null)
            {
                return HttpNotFound();
            }
            return View(instruccione);
        }

        // POST: instrucciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion,activo")] Instruccion instruccione)
        {
            if (ModelState.IsValid)
            {
                SetFile(instruccione);

                db.Entry(instruccione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instruccione);
        }

        public ActionResult ShowFile(int id)
        {
            byte[] imageData = db.Instrucciones.Find(id).Instructivo;

            if (imageData != null)
            {
                return new FileStreamResult(new System.IO.MemoryStream(imageData), "image/jpeg");
            }
            else
                return new FileStreamResult(new System.IO.MemoryStream(), "image/jpeg");
        }




        // GET: instrucciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instruccion instruccione = db.Instrucciones.Find(id);
            if (instruccione == null)
            {
                return HttpNotFound();
            }
            return View(instruccione);
        }

        // POST: instrucciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instruccion instruccione = db.Instrucciones.Find(id);
            db.Instrucciones.Remove(instruccione);
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
