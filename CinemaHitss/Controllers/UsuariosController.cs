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
    public class UsuariosController : Controller
    {
        private CineHitssEntitiesFinish db = new CineHitssEntitiesFinish();
        // GET: Usuarios
        public ActionResult Index()
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

        public ActionResult IndexPuntos()
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

        public ActionResult Filtros()
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

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Login"] != null)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // GET: Usuarios/Create
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

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Apellido,Correo,Contraseña,Puntos")] Usuario usuario)
        {
            if (Session["Login"] != null)
            {
                if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Login"] != null)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Apellido,Correo,Contraseña,Puntos")] Usuario usuario)
        {
            if (Session["Login"] != null)
            {
                if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Login"] != null)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["Login"] != null)
            {
                Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
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
