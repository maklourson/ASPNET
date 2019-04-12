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
using System.IO;

namespace GestionDesCourses.Controllers
{
    [Authorize(Roles ="Admin,SA")]
    public class PoisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pois
        public ActionResult Index()
        {
            return View(db.Pois.ToList());
        }

        // GET: Pois/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poi poi = db.Pois.Find(id);
            if (poi == null)
            {
                return HttpNotFound();
            }
            return View(poi);
        }

        // GET: Pois/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pois/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PoiViewModel poiViewModel)
        {
            var lePoi = poiViewModel.PoiVm;
            var fileName = "";
            var fileSavePath = "";
            var uploadedFile = poiViewModel.file;
            fileName = Path.GetFileName(uploadedFile.FileName).Replace(uploadedFile.FileName, lePoi.Description);
            fileName = fileName + ".css";
            fileSavePath = Server.MapPath("/Content/GPX/" + fileName);

            if (ModelState.IsValid)
            {
                //on ajoute la description du Pois en BDD
                db.Pois.Add(lePoi);
                db.SaveChanges();
                // si la sauvegarde en bdd est bonne on retourne le dernier id
                if(poiViewModel.PoiVm.Id > 0)
                {
                    //on enregistre le fichier
                    uploadedFile.SaveAs(fileSavePath);
                }
                return RedirectToAction("Index");
            }

            return View(poiViewModel.PoiVm);
        }

        // GET: Pois/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poi poi = db.Pois.Find(id);
            if (poi == null)
            {
                return HttpNotFound();
            }
            return View(poi);
        }

        // POST: Pois/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description")] Poi poi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(poi);
        }

        // GET: Pois/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poi poi = db.Pois.Find(id);
            if (poi == null)
            {
                return HttpNotFound();
            }
            return View(poi);
        }

        // POST: Pois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Poi poi = db.Pois.Find(id);
            db.Pois.Remove(poi);
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
