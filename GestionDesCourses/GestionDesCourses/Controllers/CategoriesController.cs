using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BO;
using GestionDesCourses.Models;

namespace GestionDesCourses.Controllers
{
    [Authorize(Roles ="Admin,SA")]
    public class CategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Categories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title")] Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // on vérifie la validité des données
                    if (!CheckRulesCreateEdit(category))
                    {
                        throw new Exception("Une ou plusieurs rêgles métiers ne sont pas respectées sur une création d'une catégorie");
                    }
                    db.Categories.Add(category);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    // Si nous avons rencontré une erreur, il faut recharger la page de création
                    return View(category);
                }
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title")] Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // on vérifie la validité des données
                    if (!CheckRulesCreateEdit(category))
                    {
                        throw new Exception("Une ou plusieurs rêgles métiers ne sont pas respectées sur une création d'une catégorie");
                    }

                    var categoriedb = db.Categories.FirstOrDefault(i => i.Id == category.Id);
                    categoriedb.Title = category.Title;
                    
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    // Si nous avons rencontré une erreur, il faut recharger la page
                    return View(category);
                }
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            try
            {
                // on vérifie qu'il n'y a aucune course associée à cette catégorie
                if (!CheckRulesDelete(id.Value))
                {
                    throw new Exception("Une ou plusieurs rêgles métiers ne sont pas respectées sur une suppression d'une catégorie");
                }
                return View(category);
            }

            catch (Exception ex)
            {
                // si on a rencontré une erreur, on affiche un message d'alerte
                Debug.WriteLine(ex.Message);
                TempData["alertMessage"] = ViewData.ModelState["ErreurSuppressionCategorie"].Errors[0].ErrorMessage;
                return RedirectToAction("Index");
            }
    }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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

        private bool CheckRulesCreateEdit(Category categorie)
        {
            var brokenRules = 0;

            // le titre doit etre unique
            List<Category> categoriesExistantes = db.Categories.ToList();
            if (categoriesExistantes.Any(p => p.Title.ToUpper() == categorie.Title.ToUpper() && p.Id != categorie.Id))
            {
                ModelState.AddModelError("Title", "Il existe déjà une categorie portant ce titre");
                brokenRules++;
            }
            
            return brokenRules == 0;
        }

        private bool CheckRulesDelete(int id)
        {
            var brokenRules = 0;

            // il ne doit y avoir aucune course de cette catégorie en base
            List<Race> racesExistantes = db.Races.Include(z => z.Category).ToList();
            if (racesExistantes.Any(r => r.Category.Id == id))
            {
                ModelState.AddModelError("ErreurSuppressionCategorie", "Vous ne pouvez pas supprimer cette catégorie car des courses y sont encore associées");
                brokenRules++;
            }

            return brokenRules == 0;
        }
    }
}
