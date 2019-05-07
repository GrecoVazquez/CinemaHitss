using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaHitss.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Login"] != null)
            {
                ViewBag.Message += "Bienvenido " + Session["Login"];
                return View();
           
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        public ActionResult About()
        {
            if (Session["Login"] != null)
            {
                ViewBag.Message = "Your application description page.";

            return View();
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

        public ActionResult Contact()
        {
            if (Session["Login"] != null)
            {
                ViewBag.Message = "Your contact page.";

            return View();
            }
            else
            {
                return RedirectToAction("Sesion", "Sesion", null);
            }
        }

     
    }
}