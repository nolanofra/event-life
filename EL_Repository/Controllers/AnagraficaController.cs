using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EL_Repository.Controllers
{
    public class AnagraficaController : Controller
    {
        private event_life_Entities db = new event_life_Entities();

        //
        // GET: /Anagrafica/

        public ActionResult Index()
        {
            var anagraficas = db.Anagraficas.Include(a => a.Utenti);
            return View(anagraficas.ToList());
        }

        //
        // GET: /Anagrafica/Details/5

        public ActionResult Details(int id = 0)
        {
            Anagrafica anagrafica = db.Anagraficas.Find(id);
            if (anagrafica == null)
            {
                return HttpNotFound();
            }
            return View(anagrafica);
        }

        //
        // GET: /Anagrafica/Create

        public ActionResult Create()
        {
            ViewBag.utente_id = new SelectList(db.Utentis, "ID_utente", "usename");
            return View();
        }

        //
        // POST: /Anagrafica/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Anagrafica anagrafica)
        {
            if (ModelState.IsValid)
            {
                db.Anagraficas.Add(anagrafica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.utente_id = new SelectList(db.Utentis, "ID_utente", "usename", anagrafica.utente_id);
            return View(anagrafica);
        }

        //
        // GET: /Anagrafica/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Anagrafica anagrafica = db.Anagraficas.Find(id);
            if (anagrafica == null)
            {
                return HttpNotFound();
            }
            ViewBag.utente_id = new SelectList(db.Utentis, "ID_utente", "usename", anagrafica.utente_id);
            return View(anagrafica);
        }

        //
        // POST: /Anagrafica/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Anagrafica anagrafica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anagrafica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.utente_id = new SelectList(db.Utentis, "ID_utente", "usename", anagrafica.utente_id);
            return View(anagrafica);
        }

        //
        // GET: /Anagrafica/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Anagrafica anagrafica = db.Anagraficas.Find(id);
            if (anagrafica == null)
            {
                return HttpNotFound();
            }
            return View(anagrafica);
        }

        //
        // POST: /Anagrafica/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Anagrafica anagrafica = db.Anagraficas.Find(id);
            db.Anagraficas.Remove(anagrafica);
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