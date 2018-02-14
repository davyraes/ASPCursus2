using ASPCursus3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPCursus3.Models;

namespace ASPCursus3.Controllers
{
    public class FiliaalController : Controller
    {
        private FiliaalService filiaalService = new FiliaalService();
        private HoofdzetelService hoofdzetelService = new HoofdzetelService();
        // GET: Filiaal
        public ActionResult Index()
        {
            var hoofdzetel = hoofdzetelService.read();
            ViewBag.hoofdzetel = hoofdzetel;
            var filialen = filiaalService.FindAll();
            return View(filialen);
        }
        public ActionResult Verwijderen(int id)
        {
            var filiaal = filiaalService.Read(id);
            return View(filiaal);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var filiaal = filiaalService.Read(id);
            TempData["filiaal"] = filiaal;
            filiaalService.Delete(id);
            return RedirectToAction("Verwijderd");
        }
        public ActionResult Verwijderd()
        {
            var filiaal = (Filiaal)TempData["filiaal"];
            return View(filiaal);
        }
    }
}