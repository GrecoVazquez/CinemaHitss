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
    public class CinePelisController : Controller
    {
        private CineHitssEntitiesFinish db = new CineHitssEntitiesFinish();

        // GET: CinePelis
        public ActionResult Index()
        {
            if (Session["Login"] != null)
            {
                var cinePelis = db.CinePelis.Include(c => c.Cine).Include(c => c.Pelicula);
                return View(cinePelis.ToList());
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // GET: CinePelis/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Login"] != null)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CinePeli cinePeli = db.CinePelis.Find(id);
           
            if (cinePeli == null)
            {
                return HttpNotFound();
            }
            return View(cinePeli);
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // GET: CinePelis/Create
        public ActionResult Create()
        {
            if (Session["Login"] != null)
            {
                ViewBag.ID_Cine = new SelectList(db.Cines, "ID", "Nombre");
            ViewBag.ID_Pelicula = new SelectList(db.Peliculas, "ID", "Nombre");
            return View();
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // POST: CinePelis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Cine,ID_Pelicula,ID")] CinePeli cinePeli)
        {
            if (Session["Login"] != null)
            {
                if (ModelState.IsValid)
            {
                db.CinePelis.Add(cinePeli);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Cine = new SelectList(db.Cines, "ID", "Nombre", cinePeli.ID_Cine);
            ViewBag.ID_Pelicula = new SelectList(db.Peliculas, "ID", "Nombre", cinePeli.ID_Pelicula);
            return View(cinePeli);
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // GET: CinePelis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Login"] != null)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CinePeli cinePeli = db.CinePelis.Find(id);
            if (cinePeli == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Cine = new SelectList(db.Cines, "ID", "Nombre", cinePeli.ID_Cine);
            ViewBag.ID_Pelicula = new SelectList(db.Peliculas, "ID", "Nombre", cinePeli.ID_Pelicula);
            return View(cinePeli);
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // POST: CinePelis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Cine,ID_Pelicula,ID")] CinePeli cinePeli)
        {
            if (Session["Login"] != null)
            {
                if (ModelState.IsValid)
            {
                db.Entry(cinePeli).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Cine = new SelectList(db.Cines, "ID", "Nombre", cinePeli.ID_Cine);
            ViewBag.ID_Pelicula = new SelectList(db.Peliculas, "ID", "Nombre", cinePeli.ID_Pelicula);
            return View(cinePeli);
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // GET: CinePelis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Login"] != null)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CinePeli cinePeli = db.CinePelis.Find(id);
            if (cinePeli == null)
            {
                return HttpNotFound();
            }
            return View(cinePeli);
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // POST: CinePelis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["Login"] != null)
            {
                CinePeli cinePeli = db.CinePelis.Find(id);
            db.CinePelis.Remove(cinePeli);
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
