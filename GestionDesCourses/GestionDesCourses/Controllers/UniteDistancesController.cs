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
    public class UniteDistancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UniteDistances
        public ActionResult Index()
        {
            return View(db.UniteDistances.ToList());
        }

        // GET: UniteDistances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniteDistance uniteDistance = db.UniteDistances.Find(id);
            if (uniteDistance == null)
            {
                return HttpNotFound();
            }
            return View(uniteDistance);
        }

        // GET: UniteDistances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UniteDistances/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,unite")] UniteDistance uniteDistance)
        {
            if (ModelState.IsValid)
            {
                db.UniteDistances.Add(uniteDistance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uniteDistance);
        }

        // GET: UniteDistances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniteDistance uniteDistance = db.UniteDistances.Find(id);
            if (uniteDistance == null)
            {
                return HttpNotFound();
            }
            return View(uniteDistance);
        }

        // POST: UniteDistances/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,unite")] UniteDistance uniteDistance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uniteDistance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uniteDistance);
        }

        // GET: UniteDistances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniteDistance uniteDistance = db.UniteDistances.Find(id);
            if (uniteDistance == null)
            {
                return HttpNotFound();
            }
            return View(uniteDistance);
        }

        // POST: UniteDistances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UniteDistance uniteDistance = db.UniteDistances.Find(id);
            db.UniteDistances.Remove(uniteDistance);
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
