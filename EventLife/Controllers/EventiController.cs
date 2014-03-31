using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EL_Repository;

namespace EventLife.Controllers
{
    public class EventiController : Controller
    {
        private event_lifeEntities db = new event_lifeEntities();

        //
        // GET: /Eventi/

        public ActionResult Index()
        {
            var profiloID = Request.Cookies["USERID"];
            var userGuid = new Guid();

            if (profiloID != null && !string.IsNullOrEmpty(profiloID.Value))
            {
                Guid.TryParse(profiloID.Value, out userGuid);
                var eventis = db.Eventis.Include(e => e.Categoria).Include(e => e.Gallery).Include(e => e.Profilo).Where(e => e.Profilo.ID_profilo.Equals(userGuid));
                return View(eventis.ToList());
            }
             
            return View("Login");            
        }

        //
        // GET: /Eventi/Details/5

        public ActionResult Details(int id = 0)
        {
            Eventi eventi = db.Eventis.Find(id);
            if (eventi == null)
            {
                return HttpNotFound();
            }
            return View(eventi);
        }

        //
        // GET: /Eventi/Create

        public ActionResult Create()
        {
            ViewBag.categoria_id = new SelectList(db.Categorias, "ID_categoria", "Titolo");
            ViewBag.gallery_id = new SelectList(db.Galleries, "ID_gallery", "nome");
            ViewBag.profilo_id = new SelectList(db.Profiloes, "ID_profilo", "nome");
            return View();
        }

        //
        // POST: /Eventi/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Eventi eventi)
        {
            if (ModelState.IsValid)
            {
                db.Eventis.Add(eventi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoria_id = new SelectList(db.Categorias, "ID_categoria", "Titolo", eventi.categoria_id);
            ViewBag.gallery_id = new SelectList(db.Galleries, "ID_gallery", "nome", eventi.gallery_id);
            ViewBag.profilo_id = new SelectList(db.Profiloes, "ID_profilo", "nome", eventi.profilo_id);
            return View(eventi);
        }

        //
        // GET: /Eventi/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Eventi eventi = db.Eventis.Find(id);
            if (eventi == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoria_id = new SelectList(db.Categorias, "ID_categoria", "Titolo", eventi.categoria_id);
            ViewBag.gallery_id = new SelectList(db.Galleries, "ID_gallery", "nome", eventi.gallery_id);
            ViewBag.profilo_id = new SelectList(db.Profiloes, "ID_profilo", "nome", eventi.profilo_id);
            return View(eventi);
        }

        //
        // POST: /Eventi/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Eventi eventi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoria_id = new SelectList(db.Categorias, "ID_categoria", "Titolo", eventi.categoria_id);
            ViewBag.gallery_id = new SelectList(db.Galleries, "ID_gallery", "nome", eventi.gallery_id);
            ViewBag.profilo_id = new SelectList(db.Profiloes, "ID_profilo", "nome", eventi.profilo_id);
            return View(eventi);
        }

        //
        // GET: /Eventi/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Eventi eventi = db.Eventis.Find(id);
            if (eventi == null)
            {
                return HttpNotFound();
            }
            return View(eventi);
        }

        //
        // POST: /Eventi/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Eventi eventi = db.Eventis.Find(id);
            db.Eventis.Remove(eventi);
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