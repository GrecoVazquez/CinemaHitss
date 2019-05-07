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
    public class PeliculasController : Controller
    {
        private CineHitssEntitiesFinish db = new CineHitssEntitiesFinish();

        // GET: Peliculas


        public ActionResult Index(string movieClaf, string movieGenre, string searchString)
        {
            if (Session["Login"] != null)
            {
                var claflista = new List<string>();
            var clasificacion = from c in db.Peliculas
                                orderby c.Clasificacion
                                select c.Clasificacion;
            claflista.AddRange(clasificacion.Distinct());
            ViewBag.movieClaf = new SelectList(claflista);

            var generolista = new List<string>();
            var genero = from d in db.Peliculas
                         orderby d.Genero
                         select d.Genero;
            generolista.AddRange(genero.Distinct());
            ViewBag.movieGenre = new SelectList(generolista);
            var pelicula = from m in db.Peliculas
                           select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                pelicula = pelicula.Where(s => s.Nombre.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(movieGenre))
            {
                pelicula = pelicula.Where(x => x.Genero == movieGenre);
            }
            if (!String.IsNullOrEmpty(movieClaf))
            {
                pelicula = pelicula.Where(x => x.Clasificacion == movieClaf);
            }
            return View(pelicula);
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }




            public ActionResult Compra()
        {
            if (Session["Login"] != null)
            {   
                return View(db.Usuarios.ToList());
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // GET: Peliculas/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Login"] != null)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Peliculas.Find(id);
            ViewBag.MId = pelicula.Nombre;
            ViewBag.Precio = pelicula.precio;
            System.Web.HttpContext.Current.Session["Precio"] = pelicula.precio;
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // GET: Peliculas/Create
        public ActionResult Create()
        {
            if (Session["Login"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // POST: Peliculas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Genero,Clasificacion,Duracion,Sinopsis")] Pelicula pelicula)
        {
            if (Session["Login"] != null)
            {
                if (ModelState.IsValid)
            {
                db.Peliculas.Add(pelicula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pelicula);
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // GET: Peliculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Login"] != null)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // POST: Peliculas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Genero,Clasificacion,Duracion,Sinopsis")] Pelicula pelicula)
        {
            if (Session["Login"] != null)
            {
                if (ModelState.IsValid)
            {
                db.Entry(pelicula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pelicula);
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // GET: Peliculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Login"] != null)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // POST: Peliculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["Login"] != null)
            {
                Pelicula pelicula = db.Peliculas.Find(id);
            db.Peliculas.Remove(pelicula);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction(null, "Sesion",null);
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
