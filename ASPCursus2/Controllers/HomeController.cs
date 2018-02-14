using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPCursus2.Models;

namespace ASPCursus2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new Persoon {Voornaam="Eddy" ,Achternaam="Wally"});
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Palindroom(string woord)
        {
            char[] omgekeerd = woord.ToCharArray();
            Array.Reverse(omgekeerd);
            string achterstevoren = new string(omgekeerd);
            if (woord == achterstevoren)
                ViewBag.palindroom = true;
            else
                ViewBag.palindroom = false;

            ViewBag.ingetiktwoord = woord;
            return View();
        }
    }
}