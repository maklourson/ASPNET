using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BO;
using GestionDesCourses.Models;

namespace GestionDesCourses.Controllers
{
    public class DisplayConfigurationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DisplayConfigurations
        public ActionResult Index()
        {
            return View(db.DisplayConfigurations.ToList());
        }

        // GET: DisplayConfigurations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisplayConfiguration displayConfiguration = db.DisplayConfigurations.Find(id);
            if (displayConfiguration == null)
            {
                return HttpNotFound();
            }
            return View(displayConfiguration);
        }

        // GET: DisplayConfigurations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DisplayConfigurations/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DeviceName,SpeedAvg,SpeedMax")] DisplayConfiguration displayConfiguration)
        {
            if (ModelState.IsValid)
            {
                db.DisplayConfigurations.Add(displayConfiguration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(displayConfiguration);
        }

        // GET: DisplayConfigurations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisplayConfiguration displayConfiguration = db.DisplayConfigurations.Find(id);
            if (displayConfiguration == null)
            {
                return HttpNotFound();
            }
            return View(displayConfiguration);
        }

        // POST: DisplayConfigurations/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DeviceName,SpeedAvg,SpeedMax")] DisplayConfiguration displayConfiguration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(displayConfiguration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(displayConfiguration);
        }

        // GET: DisplayConfigurations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisplayConfiguration displayConfiguration = db.DisplayConfigurations.Find(id);
            if (displayConfiguration == null)
            {
                return HttpNotFound();
            }
            return View(displayConfiguration);
        }

        // POST: DisplayConfigurations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DisplayConfiguration displayConfiguration = db.DisplayConfigurations.Find(id);
            db.DisplayConfigurations.Remove(displayConfiguration);
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
    }
}
