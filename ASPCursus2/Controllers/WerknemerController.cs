using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPCursus2.Models;

namespace ASPCursus2.Controllers
{
    public class WerknemerController : Controller
    {
        // GET: Werknemer
        public ActionResult Index(int? id)
        {
            return View("AndereNaam");
        }
        [NonAction]
        public void GeenAction()
        {

        }
        public ActionResult Read()
        {
            return View();
        }
        public ActionResult Read(int? id)
        {
            return View();
        }
        public ActionResult ShowAll(int? paginaNr)
        {
            return View();
        }
        [HttpPost]
        public ActionResult VerdubbelDeWeddes()
        {
            return View();
        }
        [ActionName("Lijst")]
        public ActionResult AlleWerknemers()
        {
            var werknemers = new List<Werknemer>();
            werknemers.Add(new Werknemer { Voornaam = "Steven", Wedde = 1000, InDienst = DateTime.Today });
            werknemers.Add(new Werknemer { Voornaam = "Prosper", Wedde = 2000, InDienst = DateTime.Today.AddDays(2) });
            return View("AlleWerknemers",werknemers);
        }
    }
}