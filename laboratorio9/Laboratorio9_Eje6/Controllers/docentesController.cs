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
    public class docentesController : Controller
    {
        private Lab9_Eje6DBEntities db = new Lab9_Eje6DBEntities();

        // GET: docentes
        public ActionResult Index()
        {
            return View(db.docentes.ToList());
        }

        // GET: docentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            docentes docentes = db.docentes.Find(id);
            if (docentes == null)
            {
                return HttpNotFound();
            }
            return View(docentes);
        }

        // GET: docentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: docentes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_docente,ci,nombre,apellido,profesion,telefono")] docentes docentes)
        {
            if (ModelState.IsValid)
            {
                db.docentes.Add(docentes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(docentes);
        }

        // GET: docentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            docentes docentes = db.docentes.Find(id);
            if (docentes == null)
            {
                return HttpNotFound();
            }
            return View(docentes);
        }

        // POST: docentes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_docente,ci,nombre,apellido,profesion,telefono")] docentes docentes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(docentes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(docentes);
        }

        // GET: docentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            docentes docentes = db.docentes.Find(id);
            if (docentes == null)
            {
                return HttpNotFound();
            }
            return View(docentes);
        }

        // POST: docentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            docentes docentes = db.docentes.Find(id);
            db.docentes.Remove(docentes);
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
