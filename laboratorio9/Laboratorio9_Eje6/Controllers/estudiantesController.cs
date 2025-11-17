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
    public class estudiantesController : Controller
    {
        private Lab9_Eje6DBEntities db = new Lab9_Eje6DBEntities();

        // GET: estudiantes
        public ActionResult Index()
        {
            return View(db.estudiantes.ToList());
        }

        // GET: estudiantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estudiantes estudiantes = db.estudiantes.Find(id);
            if (estudiantes == null)
            {
                return HttpNotFound();
            }
            return View(estudiantes);
        }

        // GET: estudiantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: estudiantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_estudiante,ci,nombre,apellido,fecha_nacimiento,telefono,direccion,genero")] estudiantes estudiantes)
        {
            if (ModelState.IsValid)
            {
                db.estudiantes.Add(estudiantes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estudiantes);
        }

        // GET: estudiantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estudiantes estudiantes = db.estudiantes.Find(id);
            if (estudiantes == null)
            {
                return HttpNotFound();
            }
            return View(estudiantes);
        }

        // POST: estudiantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_estudiante,ci,nombre,apellido,fecha_nacimiento,telefono,direccion,genero")] estudiantes estudiantes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estudiantes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estudiantes);
        }

        // GET: estudiantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estudiantes estudiantes = db.estudiantes.Find(id);
            if (estudiantes == null)
            {
                return HttpNotFound();
            }
            return View(estudiantes);
        }

        // POST: estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            estudiantes estudiantes = db.estudiantes.Find(id);
            db.estudiantes.Remove(estudiantes);
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
