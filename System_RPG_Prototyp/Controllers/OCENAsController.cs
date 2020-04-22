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
    public class OCENAsController : Controller
    {
        private RpgSystemEntities db = new RpgSystemEntities();

        // GET: OCENAs
        public ActionResult Index()
        {
            var oCENA = db.OCENA.Include(o => o.ITEM).Include(o => o.UZYTKOWNIK);
            return View(oCENA.ToList());
        }

        // GET: OCENAs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OCENA oCENA = db.OCENA.Find(id);
            if (oCENA == null)
            {
                return HttpNotFound();
            }
            return View(oCENA);
        }

        // GET: OCENAs/Create
        public ActionResult Create()
        {
            ViewBag.IDITEM = new SelectList(db.ITEM, "IDITEM", "NAZWA");
            ViewBag.IDUZYTKOWNIK = new SelectList(db.UZYTKOWNIK, "IDUZYTKOWNIK", "NAZWA");
            return View();
        }

        // POST: OCENAs/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDOCENA,IDUZYTKOWNIK,IDITEM,WARTOSC")] OCENA oCENA)
        {
            if (ModelState.IsValid)
            {
                db.OCENA.Add(oCENA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDITEM = new SelectList(db.ITEM, "IDITEM", "NAZWA", oCENA.IDITEM);
            ViewBag.IDUZYTKOWNIK = new SelectList(db.UZYTKOWNIK, "IDUZYTKOWNIK", "NAZWA", oCENA.IDUZYTKOWNIK);
            return View(oCENA);
        }

        // GET: OCENAs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OCENA oCENA = db.OCENA.Find(id);
            if (oCENA == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDITEM = new SelectList(db.ITEM, "IDITEM", "NAZWA", oCENA.IDITEM);
            ViewBag.IDUZYTKOWNIK = new SelectList(db.UZYTKOWNIK, "IDUZYTKOWNIK", "NAZWA", oCENA.IDUZYTKOWNIK);
            return View(oCENA);
        }

        // POST: OCENAs/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDOCENA,IDUZYTKOWNIK,IDITEM,WARTOSC")] OCENA oCENA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oCENA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDITEM = new SelectList(db.ITEM, "IDITEM", "NAZWA", oCENA.IDITEM);
            ViewBag.IDUZYTKOWNIK = new SelectList(db.UZYTKOWNIK, "IDUZYTKOWNIK", "NAZWA", oCENA.IDUZYTKOWNIK);
            return View(oCENA);
        }

        // GET: OCENAs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OCENA oCENA = db.OCENA.Find(id);
            if (oCENA == null)
            {
                return HttpNotFound();
            }
            return View(oCENA);
        }

        // POST: OCENAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            OCENA oCENA = db.OCENA.Find(id);
            db.OCENA.Remove(oCENA);
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
