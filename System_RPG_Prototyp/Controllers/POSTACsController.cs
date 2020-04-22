using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System_RPG_Prototyp;

namespace System_RPG_Prototyp.Controllers
{
    [Authorize]
    public class POSTACsController : Controller
    {
        private RpgSystemEntities db = new RpgSystemEntities();

        // GET: POSTACs
        public ActionResult Index()
        {
            var pOSTAC = db.POSTAC.Include(p => p.KLASA).Include(p => p.UZYTKOWNIK);
            return View(pOSTAC.ToList());
        }

        // GET: POSTACs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POSTAC pOSTAC = db.POSTAC.Find(id);
            if (pOSTAC == null)
            {
                return HttpNotFound();
            }
            return View(pOSTAC);
        }

        // GET: POSTACs/Create
        public ActionResult Create()
        {
            ViewBag.IDKLASA = new SelectList(db.KLASA, "IDKLASA", "NAZWA");
            ViewBag.IDUZYTKOWNIK = new SelectList(db.UZYTKOWNIK, "IDUZYTKOWNIK", "NAZWA");
            return View();
        }

        // POST: POSTACs/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPOSTAC,IDKLASA,IDUZYTKOWNIK,NAZWA")] POSTAC pOSTAC)
        {
            if (ModelState.IsValid)
            {
                db.POSTAC.Add(pOSTAC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDKLASA = new SelectList(db.KLASA, "IDKLASA", "NAZWA", pOSTAC.IDKLASA);
            ViewBag.IDUZYTKOWNIK = new SelectList(db.UZYTKOWNIK, "IDUZYTKOWNIK", "NAZWA", pOSTAC.IDUZYTKOWNIK);
            return View(pOSTAC);
        }

        // GET: POSTACs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POSTAC pOSTAC = db.POSTAC.Find(id);
            if (pOSTAC == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDKLASA = new SelectList(db.KLASA, "IDKLASA", "NAZWA", pOSTAC.IDKLASA);
            ViewBag.IDUZYTKOWNIK = new SelectList(db.UZYTKOWNIK, "IDUZYTKOWNIK", "NAZWA", pOSTAC.IDUZYTKOWNIK);
            return View(pOSTAC);
        }

        // POST: POSTACs/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPOSTAC,IDKLASA,IDUZYTKOWNIK,NAZWA")] POSTAC pOSTAC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pOSTAC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDKLASA = new SelectList(db.KLASA, "IDKLASA", "NAZWA", pOSTAC.IDKLASA);
            ViewBag.IDUZYTKOWNIK = new SelectList(db.UZYTKOWNIK, "IDUZYTKOWNIK", "NAZWA", pOSTAC.IDUZYTKOWNIK);
            return View(pOSTAC);
        }

        // GET: POSTACs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POSTAC pOSTAC = db.POSTAC.Find(id);
            if (pOSTAC == null)
            {
                return HttpNotFound();
            }
            return View(pOSTAC);
        }

        // POST: POSTACs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            POSTAC pOSTAC = db.POSTAC.Find(id);
            db.POSTAC.Remove(pOSTAC);
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
