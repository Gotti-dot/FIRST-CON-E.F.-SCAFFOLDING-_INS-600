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
    public class matriculasController : Controller
    {
        private Lab9_Eje6DBEntities db = new Lab9_Eje6DBEntities();

        // GET: matriculas
        public ActionResult Index()
        {
            var matriculas = db.matriculas.Include(m => m.carreras).Include(m => m.estudiantes).Include(m => m.semestres);
            return View(matriculas.ToList());
        }

        // GET: matriculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            matriculas matriculas = db.matriculas.Find(id);
            if (matriculas == null)
            {
                return HttpNotFound();
            }
            return View(matriculas);
        }

        // GET: matriculas/Create
        public ActionResult Create()
        {
            ViewBag.id_carrera = new SelectList(db.carreras, "id_carrera", "nombre_carrera");
            ViewBag.id_estudiante = new SelectList(db.estudiantes, "id_estudiante", "ci");
            ViewBag.id_semestre = new SelectList(db.semestres, "id_semestre", "descripcion");
            return View();
        }

        // POST: matriculas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_matricula,id_estudiante,id_carrera,id_semestre,gestion,fecha_matricula")] matriculas matriculas)
        {
            if (ModelState.IsValid)
            {
                db.matriculas.Add(matriculas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_carrera = new SelectList(db.carreras, "id_carrera", "nombre_carrera", matriculas.id_carrera);
            ViewBag.id_estudiante = new SelectList(db.estudiantes, "id_estudiante", "ci", matriculas.id_estudiante);
            ViewBag.id_semestre = new SelectList(db.semestres, "id_semestre", "descripcion", matriculas.id_semestre);
            return View(matriculas);
        }

        // GET: matriculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            matriculas matriculas = db.matriculas.Find(id);
            if (matriculas == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_carrera = new SelectList(db.carreras, "id_carrera", "nombre_carrera", matriculas.id_carrera);
            ViewBag.id_estudiante = new SelectList(db.estudiantes, "id_estudiante", "ci", matriculas.id_estudiante);
            ViewBag.id_semestre = new SelectList(db.semestres, "id_semestre", "descripcion", matriculas.id_semestre);
            return View(matriculas);
        }

        // POST: matriculas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_matricula,id_estudiante,id_carrera,id_semestre,gestion,fecha_matricula")] matriculas matriculas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matriculas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_carrera = new SelectList(db.carreras, "id_carrera", "nombre_carrera", matriculas.id_carrera);
            ViewBag.id_estudiante = new SelectList(db.estudiantes, "id_estudiante", "ci", matriculas.id_estudiante);
            ViewBag.id_semestre = new SelectList(db.semestres, "id_semestre", "descripcion", matriculas.id_semestre);
            return View(matriculas);
        }

        // GET: matriculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            matriculas matriculas = db.matriculas.Find(id);
            if (matriculas == null)
            {
                return HttpNotFound();
            }
            return View(matriculas);
        }

        // POST: matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            matriculas matriculas = db.matriculas.Find(id);
            db.matriculas.Remove(matriculas);
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
