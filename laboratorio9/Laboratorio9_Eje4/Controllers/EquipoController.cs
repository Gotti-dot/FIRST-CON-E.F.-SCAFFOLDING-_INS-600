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
    public class EquipoController : Controller
    {
        private Lab9_Eje4DBEntities db = new Lab9_Eje4DBEntities();

        // GET: Equipo
        public ActionResult Index()
        {
            var equipo = db.Equipo.Include(e => e.EstadoEquipo).Include(e => e.TipoEquipo);
            return View(equipo.ToList());
        }

        // GET: Equipo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipo.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            return View(equipo);
        }

        // GET: Equipo/Create
        public ActionResult Create()
        {
            ViewBag.CodEst = new SelectList(db.EstadoEquipo, "CodEst", "DesEst");
            ViewBag.CodTipEqu = new SelectList(db.TipoEquipo, "CodTipEqu", "DesTip");
            return View();
        }

        // POST: Equipo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEqu,CodTipEqu,CodEst,Descripcion,Icono,CodExt")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                db.Equipo.Add(equipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodEst = new SelectList(db.EstadoEquipo, "CodEst", "DesEst", equipo.CodEst);
            ViewBag.CodTipEqu = new SelectList(db.TipoEquipo, "CodTipEqu", "DesTip", equipo.CodTipEqu);
            return View(equipo);
        }

        // GET: Equipo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipo.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodEst = new SelectList(db.EstadoEquipo, "CodEst", "DesEst", equipo.CodEst);
            ViewBag.CodTipEqu = new SelectList(db.TipoEquipo, "CodTipEqu", "DesTip", equipo.CodTipEqu);
            return View(equipo);
        }

        // POST: Equipo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEqu,CodTipEqu,CodEst,Descripcion,Icono,CodExt")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodEst = new SelectList(db.EstadoEquipo, "CodEst", "DesEst", equipo.CodEst);
            ViewBag.CodTipEqu = new SelectList(db.TipoEquipo, "CodTipEqu", "DesTip", equipo.CodTipEqu);
            return View(equipo);
        }

        // GET: Equipo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipo.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            return View(equipo);
        }

        // POST: Equipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipo equipo = db.Equipo.Find(id);
            db.Equipo.Remove(equipo);
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
