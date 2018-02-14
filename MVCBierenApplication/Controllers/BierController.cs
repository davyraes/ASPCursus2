using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBierenApplication.Models;
using MVCBierenApplication.Services;
namespace MVCBierenApplication.Controllers
{
    public class BierController : Controller
    {
        private BierService Bierservice = new BierService();
        // GET: Bier
        public ActionResult Index()
        {
            var bieren = Bierservice.FindAll();
            return View(bieren);
        }
        public ActionResult Verwijderen(int id)
        {
            var bier = Bierservice.Read(id) ;
            return View(bier);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var bier = Bierservice.Read(id);
            TempData["bier"] = bier;
            Bierservice.Delete(id);
            return RedirectToAction("Verwijderd");
        }
        public ActionResult Verwijderd()
        {
            var bier = (Bier)TempData["bier"];
            return View(bier);
        }
    }
}