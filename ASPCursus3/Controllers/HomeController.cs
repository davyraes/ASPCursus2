using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPCursus3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
                Session["aantalBezoeken"] = (int)Session["aantalBezoeken"] + 1;
            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application["aantalBezoeken"] = (int)System.Web.HttpContext.Current.Application["aantalBezoeken"] + 1;
            System.Web.HttpContext.Current.Application.UnLock();
            return View();
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
        public ActionResult Wissen()
        {
            Session["aantalBezoeken"] = 0;
            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application["aantalBezoeken"] = 0;
            System.Web.HttpContext.Current.Application.UnLock();
            return View();
        }
        public PartialViewResult GetTime()
        {
            return PartialView(DateTime.Now);
        }
    }
}