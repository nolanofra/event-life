using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EL_Repository.Controllers
{
    public class UtentiController : Controller
    {
        private event_lifeEntities db = new event_lifeEntities();

        //
        // GET: /Utenti/

        public ActionResult Index()
        {
            var utentis = db.Utentis.Include(u => u.Livello_Utenti);
            return View(utentis.ToList());
        }

        //
        // GET: /Utenti/Details/5

        public ActionResult Details(Guid id )
        {
            Utenti utenti = db.Utentis.Find(id);
            if (utenti == null)
            {
                return HttpNotFound();
            }
            return View(utenti);
        }

        //
        // GET: /Utenti/Create

        public ActionResult Create()
        {
            ViewBag.livello_id = new SelectList(db.Livello_Utenti, "ID_livello", "descrizione");
            return View();
        }

        //
        // POST: /Utenti/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Utenti utenti)
        {
            if (ModelState.IsValid)
            {
                utenti.ID_utente = Guid.NewGuid();
                db.Utentis.Add(utenti);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.livello_id = new SelectList(db.Livello_Utenti, "ID_livello", "descrizione", utenti.livello_id);
            return View(utenti);
        }

        //
        // GET: /Utenti/Edit/5

        public ActionResult Edit(Guid id )
        {
            Utenti utenti = db.Utentis.Find(id);
            if (utenti == null)
            {
                return HttpNotFound();
            }
            ViewBag.livello_id = new SelectList(db.Livello_Utenti, "ID_livello", "descrizione", utenti.livello_id);
            return View(utenti);
        }

        //
        // POST: /Utenti/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Utenti utenti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utenti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.livello_id = new SelectList(db.Livello_Utenti, "ID_livello", "descrizione", utenti.livello_id);
            return View(utenti);
        }

        //
        // GET: /Utenti/Delete/5

        public ActionResult Delete(Guid id )
        {
            Utenti utenti = db.Utentis.Find(id);
            if (utenti == null)
            {
                return HttpNotFound();
            }
            return View(utenti);
        }

        //
        // POST: /Utenti/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Utenti utenti = db.Utentis.Find(id);
            db.Utentis.Remove(utenti);
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