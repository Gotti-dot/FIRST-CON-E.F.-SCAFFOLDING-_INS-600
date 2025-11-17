using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Laboratorio9_Eje4.Models;

namespace Laboratorio9_Eje4.Controllers
{
    public class EstadoEquipoController : Controller
    {
        private Lab9_Eje4DBEntities db = new Lab9_Eje4DBEntities();

        // GET: EstadoEquipo
        public ActionResult Index()
        {
            return View(db.EstadoEquipo.ToList());
        }

        // GET: EstadoEquipo/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoEquipo estadoEquipo = db.EstadoEquipo.Find(id);
            if (estadoEquipo == null)
            {
                return HttpNotFound();
            }
            return View(estadoEquipo);
        }

        // GET: EstadoEquipo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoEquipo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodEst,DesEst")] EstadoEquipo estadoEquipo)
        {
            if (ModelState.IsValid)
            {
                db.EstadoEquipo.Add(estadoEquipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadoEquipo);
        }

        // GET: EstadoEquipo/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoEquipo estadoEquipo = db.EstadoEquipo.Find(id);
            if (estadoEquipo == null)
            {
                return HttpNotFound();
            }
            return View(estadoEquipo);
        }

        // POST: EstadoEquipo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodEst,DesEst")] EstadoEquipo estadoEquipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoEquipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadoEquipo);
        }

        // GET: EstadoEquipo/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoEquipo estadoEquipo = db.EstadoEquipo.Find(id);
            if (estadoEquipo == null)
            {
                return HttpNotFound();
            }
            return View(estadoEquipo);
        }

        // POST: EstadoEquipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            EstadoEquipo estadoEquipo = db.EstadoEquipo.Find(id);
            db.EstadoEquipo.Remove(estadoEquipo);
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
