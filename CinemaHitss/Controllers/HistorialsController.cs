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
    public class HistorialsController : Controller
    {
        private CineHitssEntitiesFinish db = new CineHitssEntitiesFinish();

        // GET: Historials
        public ActionResult Index()
        {
            if (Session["Login"] != null)
            {
                var historials = db.Historials.Include(h => h.Pelicula).Include(h => h.Usuario);
            return View(historials.ToList());
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // GET: Historials/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Login"] != null)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historial historial = db.Historials.Find(id);
            if (historial == null)
            {
                return HttpNotFound();
            }
            return View(historial);
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // GET: Historials/Create
        public ActionResult Create()
        {
            if (Session["Login"] != null)
            {
                ViewBag.ID_Pelicula = new SelectList(db.Peliculas, "ID", "Nombre");
            ViewBag.ID_Usuario = new SelectList(db.Usuarios, "ID", "Nombre");
            return View();
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // POST: Historials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Usuario,ID_Pelicula,ID")] Historial historial)
        {
            if (Session["Login"] != null)
            {
                if (ModelState.IsValid)
            {
                db.Historials.Add(historial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Pelicula = new SelectList(db.Peliculas, "ID", "Nombre", historial.ID_Pelicula);
            ViewBag.ID_Usuario = new SelectList(db.Usuarios, "ID", "Nombre", historial.ID_Usuario);
            return View(historial);
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // GET: Historials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Login"] != null)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historial historial = db.Historials.Find(id);
            if (historial == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Pelicula = new SelectList(db.Peliculas, "ID", "Nombre", historial.ID_Pelicula);
            ViewBag.ID_Usuario = new SelectList(db.Usuarios, "ID", "Nombre", historial.ID_Usuario);
            return View(historial);
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // POST: Historials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Usuario,ID_Pelicula,ID")] Historial historial)
        {
            if (Session["Login"] != null)
            {
                if (ModelState.IsValid)
            {
                db.Entry(historial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Pelicula = new SelectList(db.Peliculas, "ID", "Nombre", historial.ID_Pelicula);
            ViewBag.ID_Usuario = new SelectList(db.Usuarios, "ID", "Nombre", historial.ID_Usuario);
            return View(historial);
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // GET: Historials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Login"] != null)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historial historial = db.Historials.Find(id);
            if (historial == null)
            {
                return HttpNotFound();
            }
            return View(historial);
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // POST: Historials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["Login"] != null)
            {
                Historial historial = db.Historials.Find(id);
            db.Historials.Remove(historial);
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
