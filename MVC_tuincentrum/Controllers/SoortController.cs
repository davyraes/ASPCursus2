﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_tuincentrum.Models;
using MVC_tuincentrum.Models.Viewmodels;
using MVC_tuincentrum.Services;

namespace MVC_tuincentrum.Controllers
{
    public class SoortController : Controller
    {
        private MVCTuinCentrumEntities db = new MVCTuinCentrumEntities();
        private SoortService soortService = new SoortService();
        // GET: Soort
        public ActionResult Index()
        {
            return View(db.Soorten.ToList());
        }

        // GET: Soort/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soort soort = db.Soorten.Find(id);
            if (soort == null)
            {
                return HttpNotFound();
            }
            return View(soort);
        }

        // GET: Soort/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Soort/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoortNr,Naam,MagazijnNr")] Soort soort)
        {
            if (ModelState.IsValid)
            {
                db.Soorten.Add(soort);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(soort);
        }

        // GET: Soort/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soort soort = db.Soorten.Find(id);
            if (soort == null)
            {
                return HttpNotFound();
            }
            return View(soort);
        }

        // POST: Soort/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoortNr,Naam,MagazijnNr")] Soort soort)
        {
            if (ModelState.IsValid)
            {
                db.Entry(soort).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(soort);
        }

        // GET: Soort/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soort soort = db.Soorten.Find(id);
            if (soort == null)
            {
                return HttpNotFound();
            }
            return View(soort);
        }

        // POST: Soort/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Soort soort = db.Soorten.Find(id);
            db.Soorten.Remove(soort);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        //GET: /Soort/Zoekform
        public ViewResult Zoekform()
        {
            return View(new ZoekSoortViewModel());
        }
        [HttpGet]
        public ViewResult BeginNaam(ZoekSoortViewModel form)
        {
            if(ModelState.IsValid)
            {
                form.Soorten = soortService.FindByBeginNaam(form.BeginNaam);
            }
            return View("Zoekform", form);
        }
    }
}
