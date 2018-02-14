using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPCursus3.Services;
using ASPCursus3.Models;

namespace ASPCursus3.Controllers
{
    public class PersoonController : Controller
    {
        private PersoonService persoonService = new PersoonService();
        // GET: Persoon
        public ActionResult Index()
        {
            return View(persoonService.FindAll());
        }
        [HttpGet]
        public ActionResult VerwijderForm(int id)
        {
            return View(persoonService.FindByID(id));
        }
        [HttpPost]
        public ActionResult Verwijderen(int id)
        {
            persoonService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Opslag()
        {
            OpslagViewModel opslagviewmodel = new OpslagViewModel();
            return View(opslagviewmodel);
        }
        [HttpPost]
        public ActionResult Opslag(OpslagViewModel opslagViewModel)
        {
            if (ModelState.IsValid)
            {
                persoonService.Opslag(opslagViewModel.VanWedde.Value, opslagViewModel.TotWedde.Value, opslagViewModel.Percentage.Value);
                return RedirectToAction("Index");
            }
            return View(opslagViewModel);
        }
        [HttpGet]
        public ActionResult VanTotWedde()
        {
            var form = new VanTotWeddeViewModel();
            return View(form);
        }
        [HttpGet]
        public ActionResult VanTotWeddeResultaat(VanTotWeddeViewModel form)
        {
            if(ModelState.IsValid)
            {
                form.Personen = persoonService.VanTotWedde(form.VanWedde.Value, form.TotWedde.Value);
               
            }
            return View("VanTotWedde", form);
        }
        public ActionResult Toevoegen()
        {
            var persoon = new Persoon();
            persoon.Geslacht = Geslacht.Vrouw;
            return View(persoon);
        }
        [HttpPost]
        public ActionResult Toevoegen(Persoon p)
        {
            if(ModelState.IsValid)
            {
                persoonService.Add(p);
                return RedirectToAction("index");
            }
            else
            {
                return View(p);
            }
        }
        [HttpGet]
        public ActionResult EditForm(int id)
        {
            return View(persoonService.FindByID(id));
        }
        [HttpPost]
        public ActionResult Edit(Persoon p)
        {
            persoonService.Update(p);
            return RedirectToAction("Index");
        }
    }
}