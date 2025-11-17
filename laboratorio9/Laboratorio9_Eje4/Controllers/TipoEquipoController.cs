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
    public class TipoEquipoController : Controller
    {
        private Lab9_Eje4DBEntities db = new Lab9_Eje4DBEntities();

        // GET: TipoEquipo
        public ActionResult Index()
        {
            return View(db.TipoEquipo.ToList());
        }

        // GET: TipoEquipo/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEquipo tipoEquipo = db.TipoEquipo.Find(id);
            if (tipoEquipo == null)
            {
                return HttpNotFound();
            }
            return View(tipoEquipo);
        }

        // GET: TipoEquipo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEquipo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodTipEqu,DesTip")] TipoEquipo tipoEquipo)
        {
            if (ModelState.IsValid)
            {
                db.TipoEquipo.Add(tipoEquipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoEquipo);
        }

        // GET: TipoEquipo/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEquipo tipoEquipo = db.TipoEquipo.Find(id);
            if (tipoEquipo == null)
            {
                return HttpNotFound();
            }
            return View(tipoEquipo);
        }

        // POST: TipoEquipo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodTipEqu,DesTip")] TipoEquipo tipoEquipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoEquipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoEquipo);
        }

        // GET: TipoEquipo/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEquipo tipoEquipo = db.TipoEquipo.Find(id);
            if (tipoEquipo == null)
            {
                return HttpNotFound();
            }
            return View(tipoEquipo);
        }

        // POST: TipoEquipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TipoEquipo tipoEquipo = db.TipoEquipo.Find(id);
            db.TipoEquipo.Remove(tipoEquipo);
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
