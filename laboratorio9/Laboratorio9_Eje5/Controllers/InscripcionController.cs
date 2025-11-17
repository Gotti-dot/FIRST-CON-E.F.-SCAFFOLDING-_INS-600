using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Laboratorio9_Eje5.Models;

namespace Laboratorio9_Eje5.Controllers
{
    public class InscripcionController : Controller
    {
        private Lab9_Eje5DBEntities db = new Lab9_Eje5DBEntities();

        // GET: Inscripcion
        public ActionResult Index()
        {
            var inscripcion = db.Inscripcion.Include(i => i.Curso).Include(i => i.Estudiante);
            return View(inscripcion.ToList());
        }

        // GET: Inscripcion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscripcion inscripcion = db.Inscripcion.Find(id);
            if (inscripcion == null)
            {
                return HttpNotFound();
            }
            return View(inscripcion);
        }

        // GET: Inscripcion/Create
        public ActionResult Create()
        {
            ViewBag.CursoId = new SelectList(db.Curso, "CursoId", "Nombre");
            ViewBag.EstudianteId = new SelectList(db.Estudiante, "EstudianteId", "Nombre");
            return View();
        }

        // POST: Inscripcion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdInscripcion,EstudianteId,CursoId,FechaInscripcion,Calificacion")] Inscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                db.Inscripcion.Add(inscripcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CursoId = new SelectList(db.Curso, "CursoId", "Nombre", inscripcion.CursoId);
            ViewBag.EstudianteId = new SelectList(db.Estudiante, "EstudianteId", "Nombre", inscripcion.EstudianteId);
            return View(inscripcion);
        }

        // GET: Inscripcion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscripcion inscripcion = db.Inscripcion.Find(id);
            if (inscripcion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursoId = new SelectList(db.Curso, "CursoId", "Nombre", inscripcion.CursoId);
            ViewBag.EstudianteId = new SelectList(db.Estudiante, "EstudianteId", "Nombre", inscripcion.EstudianteId);
            return View(inscripcion);
        }

        // POST: Inscripcion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdInscripcion,EstudianteId,CursoId,FechaInscripcion,Calificacion")] Inscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inscripcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CursoId = new SelectList(db.Curso, "CursoId", "Nombre", inscripcion.CursoId);
            ViewBag.EstudianteId = new SelectList(db.Estudiante, "EstudianteId", "Nombre", inscripcion.EstudianteId);
            return View(inscripcion);
        }

        // GET: Inscripcion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscripcion inscripcion = db.Inscripcion.Find(id);
            if (inscripcion == null)
            {
                return HttpNotFound();
            }
            return View(inscripcion);
        }

        // POST: Inscripcion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inscripcion inscripcion = db.Inscripcion.Find(id);
            db.Inscripcion.Remove(inscripcion);
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
