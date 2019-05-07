using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CinemaHitss;

namespace CinemaHitss.Controllers
{
    public class CinesController : Controller
    {
        private CineHitssEntitiesFinish db = new CineHitssEntitiesFinish();

        // GET: Cines
        public ActionResult Index(string searchCiudad, string searchCine)
        {
            if (Session["Login"] != null)
            {
                var cine = from m in db.Cines select m;

            if (!String.IsNullOrEmpty(searchCiudad))
            {
                cine = cine.Where(s => s.Ciudad.Nombre.Contains(searchCiudad));
                Console.Write(cine);
                Console.Write("Prueba");
                System.Web.HttpContext.Current.Session["Ciudad"] =searchCiudad;
                return RedirectToAction("Index", "CinePelis", null);
            }

            if (!String.IsNullOrEmpty(searchCine))
            {
                cine = cine.Where(s => s.Nombre.Contains(searchCine));
                System.Web.HttpContext.Current.Session["Cine"] = searchCine;
                return RedirectToAction("Index", "CinePelis", null);
            }

            return View(cine);
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // GET: Cines/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Login"] != null)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cine cine = db.Cines.Find(id);
            if (cine == null)
            {
                return HttpNotFound();
            }
            return View(cine);
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // GET: Cines/Create
        public ActionResult Create()
        {
            if (Session["Login"] != null)
            {
                ViewBag.ID_Ciudad = new SelectList(db.Ciudads, "ID", "Nombre");
            return View();
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // POST: Cines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,ID_Ciudad")] Cine cine)
        {
            if (Session["Login"] != null)
            {
                if (ModelState.IsValid)
            {
                db.Cines.Add(cine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Ciudad = new SelectList(db.Ciudads, "ID", "Nombre", cine.ID_Ciudad);
            return View(cine);
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // GET: Cines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Login"] != null)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cine cine = db.Cines.Find(id);
            if (cine == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Ciudad = new SelectList(db.Ciudads, "ID", "Nombre", cine.ID_Ciudad);
            return View(cine);
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // POST: Cines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,ID_Ciudad")] Cine cine)
        {
            if (Session["Login"] != null)
            {
                if (ModelState.IsValid)
            {
                db.Entry(cine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Ciudad = new SelectList(db.Ciudads, "ID", "Nombre", cine.ID_Ciudad);
            return View(cine);
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // GET: Cines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Login"] != null)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cine cine = db.Cines.Find(id);
            if (cine == null)
            {
                return HttpNotFound();
            }
            return View(cine);
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // POST: Cines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["Login"] != null)
            {
                Cine cine = db.Cines.Find(id);
            db.Cines.Remove(cine);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
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
