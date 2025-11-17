using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Laboratorio9_Eje6.Models;

namespace Laboratorio9_Eje6.Controllers
{
    public class materiasController : Controller
    {
        private Lab9_Eje6DBEntities db = new Lab9_Eje6DBEntities();

        // GET: materias
        public ActionResult Index()
        {
            var materias = db.materias.Include(m => m.carreras).Include(m => m.docentes);
            return View(materias.ToList());
        }

        // GET: materias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            materias materias = db.materias.Find(id);
            if (materias == null)
            {
                return HttpNotFound();
            }
            return View(materias);
        }

        // GET: materias/Create
        public ActionResult Create()
        {
            ViewBag.id_carrera = new SelectList(db.carreras, "id_carrera", "nombre_carrera");
            ViewBag.id_docente = new SelectList(db.docentes, "id_docente", "ci");
            return View();
        }

        // POST: materias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_materia,nombre_materia,carga_horaria,id_carrera,id_docente")] materias materias)
        {
            if (ModelState.IsValid)
            {
                db.materias.Add(materias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_carrera = new SelectList(db.carreras, "id_carrera", "nombre_carrera", materias.id_carrera);
            ViewBag.id_docente = new SelectList(db.docentes, "id_docente", "ci", materias.id_docente);
            return View(materias);
        }

        // GET: materias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            materias materias = db.materias.Find(id);
            if (materias == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_carrera = new SelectList(db.carreras, "id_carrera", "nombre_carrera", materias.id_carrera);
            ViewBag.id_docente = new SelectList(db.docentes, "id_docente", "ci", materias.id_docente);
            return View(materias);
        }

        // POST: materias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_materia,nombre_materia,carga_horaria,id_carrera,id_docente")] materias materias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_carrera = new SelectList(db.carreras, "id_carrera", "nombre_carrera", materias.id_carrera);
            ViewBag.id_docente = new SelectList(db.docentes, "id_docente", "ci", materias.id_docente);
            return View(materias);
        }

        // GET: materias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            materias materias = db.materias.Find(id);
            if (materias == null)
            {
                return HttpNotFound();
            }
            return View(materias);
        }

        // POST: materias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            materias materias = db.materias.Find(id);
            db.materias.Remove(materias);
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
