using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EL_Repository.Controllers
{
    public class ProfiloController : Controller
    {
        private event_life_Entities db = new event_life_Entities();

        //
        // GET: /Profilo/

        public ActionResult Index()
        {
            var profiloes = db.Profiloes.Include(p => p.Categoria).Include(p => p.Gallery).Include(p => p.Utenti);
            return View(profiloes.ToList());
        }

        //
        // GET: /Profilo/Details/5

        public ActionResult Details(int id = 0)
        {
            Profilo profilo = db.Profiloes.Find(id);
            if (profilo == null)
            {
                return HttpNotFound();
            }
            return View(profilo);
        }

        //
        // GET: /Profilo/Create

        public ActionResult Create()
        {
            ViewBag.categoria_id = new SelectList(db.Categorias, "ID_categoria", "Titolo");
            ViewBag.gallery_id = new SelectList(db.Galleries, "ID_gallery", "ID_gallery");
            ViewBag.utente_id = new SelectList(db.Utentis, "ID_utente", "usename");
            return View();
        }

        //
        // POST: /Profilo/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Profilo profilo)
        {
            if (ModelState.IsValid)
            {
                db.Profiloes.Add(profilo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoria_id = new SelectList(db.Categorias, "ID_categoria", "Titolo", profilo.categoria_id);
            ViewBag.gallery_id = new SelectList(db.Galleries, "ID_gallery", "ID_gallery", profilo.gallery_id);
            ViewBag.utente_id = new SelectList(db.Utentis, "ID_utente", "usename", profilo.utente_id);
            return View(profilo);
        }

        //
        // GET: /Profilo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Profilo profilo = db.Profiloes.Find(id);
            if (profilo == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoria_id = new SelectList(db.Categorias, "ID_categoria", "Titolo", profilo.categoria_id);
            ViewBag.gallery_id = new SelectList(db.Galleries, "ID_gallery", "ID_gallery", profilo.gallery_id);
            ViewBag.utente_id = new SelectList(db.Utentis, "ID_utente", "usename", profilo.utente_id);
            return View(profilo);
        }

        //
        // POST: /Profilo/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Profilo profilo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profilo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoria_id = new SelectList(db.Categorias, "ID_categoria", "Titolo", profilo.categoria_id);
            ViewBag.gallery_id = new SelectList(db.Galleries, "ID_gallery", "ID_gallery", profilo.gallery_id);
            ViewBag.utente_id = new SelectList(db.Utentis, "ID_utente", "usename", profilo.utente_id);
            return View(profilo);
        }

        //
        // GET: /Profilo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Profilo profilo = db.Profiloes.Find(id);
            if (profilo == null)
            {
                return HttpNotFound();
            }
            return View(profilo);
        }

        //
        // POST: /Profilo/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profilo profilo = db.Profiloes.Find(id);
            db.Profiloes.Remove(profilo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}