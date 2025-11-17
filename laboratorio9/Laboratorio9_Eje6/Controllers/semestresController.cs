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
    public class semestresController : Controller
    {
        private Lab9_Eje6DBEntities db = new Lab9_Eje6DBEntities();

        // GET: semestres
        public ActionResult Index()
        {
            return View(db.semestres.ToList());
        }

        // GET: semestres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            semestres semestres = db.semestres.Find(id);
            if (semestres == null)
            {
                return HttpNotFound();
            }
            return View(semestres);
        }

        // GET: semestres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: semestres/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_semestre,numero_semestre,descripcion")] semestres semestres)
        {
            if (ModelState.IsValid)
            {
                db.semestres.Add(semestres);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(semestres);
        }

        // GET: semestres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            semestres semestres = db.semestres.Find(id);
            if (semestres == null)
            {
                return HttpNotFound();
            }
            return View(semestres);
        }

        // POST: semestres/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_semestre,numero_semestre,descripcion")] semestres semestres)
        {
            if (ModelState.IsValid)
            {
                db.Entry(semestres).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(semestres);
        }

        // GET: semestres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            semestres semestres = db.semestres.Find(id);
            if (semestres == null)
            {
                return HttpNotFound();
            }
            return View(semestres);
        }

        // POST: semestres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            semestres semestres = db.semestres.Find(id);
            db.semestres.Remove(semestres);
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
