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
    public class KLASAsController : Controller
    {
        private RpgSystemEntities db = new RpgSystemEntities();

        // GET: KLASAs
        public ActionResult Index()
        {
            return View(db.KLASA.ToList());
        }

        // GET: KLASAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KLASA kLASA = db.KLASA.Find(id);
            if (kLASA == null)
            {
                return HttpNotFound();
            }
            return View(kLASA);
        }

        // GET: KLASAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KLASAs/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDKLASA,NAZWA,SILA,WYTRZYMALOSC,UDZWIG,MANA,HP")] KLASA kLASA)
        {
            if (ModelState.IsValid)
            {
                db.KLASA.Add(kLASA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kLASA);
        }

        // GET: KLASAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KLASA kLASA = db.KLASA.Find(id);
            if (kLASA == null)
            {
                return HttpNotFound();
            }
            return View(kLASA);
        }

        // POST: KLASAs/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDKLASA,NAZWA,SILA,WYTRZYMALOSC,UDZWIG,MANA,HP")] KLASA kLASA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kLASA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kLASA);
        }

        // GET: KLASAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KLASA kLASA = db.KLASA.Find(id);
            if (kLASA == null)
            {
                return HttpNotFound();
            }
            return View(kLASA);
        }

        // POST: KLASAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KLASA kLASA = db.KLASA.Find(id);
            db.KLASA.Remove(kLASA);
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
