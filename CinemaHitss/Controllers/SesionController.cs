using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaHitss.Controllers
{
    public class SesionController : Controller
    {
        private CineHitssEntitiesFinish db = new CineHitssEntitiesFinish();

        public ActionResult login()
        {
            return View();
        }

        public ActionResult Users()
        {

            if (Session["Login"] != null)
            {
                ViewBag.Message += "Bienvenido " + Session["Login"];
                return View();
            }
            else
            {
                return RedirectToAction("login", "Usuario");
            }


        }

        //POST: Usuario
        public ActionResult Sesion(string usuario, string psw)
        {

            var model = db.Usuarios.FirstOrDefault(m => m.Nombre.Equals(usuario) && m.Contraseña.Equals(psw));
            if (model != null)
            {
                System.Web.HttpContext.Current.Session["Login"] = usuario;
                ViewBag.Message += "Bienvenido " + Session["Login"];
                return RedirectToAction("Index", "Home", null);

            }
            else
            {
                return View("Sesion");
            }
        }

        //Log Out
        public ActionResult logout()

        {
            Session["Login"] = null;
            return View("Sesion");
        }


    }
}