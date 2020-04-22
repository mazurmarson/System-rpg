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
    public class FUNKCJAsController : Controller
    {
        private RpgSystemEntities db = new RpgSystemEntities();

        // GET: FUNKCJAs
        public ActionResult Index()
        {
            return View(db.FUNKCJA.ToList());
        }

        // GET: FUNKCJAs/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FUNKCJA fUNKCJA = db.FUNKCJA.Find(id);
            if (fUNKCJA == null)
            {
                return HttpNotFound();
            }
            return View(fUNKCJA);
        }

        // GET: FUNKCJAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FUNKCJAs/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDFUNKCJA,NAZWA")] FUNKCJA fUNKCJA)
        {
            if (ModelState.IsValid)
            {
                db.FUNKCJA.Add(fUNKCJA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fUNKCJA);
        }

        // GET: FUNKCJAs/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FUNKCJA fUNKCJA = db.FUNKCJA.Find(id);
            if (fUNKCJA == null)
            {
                return HttpNotFound();
            }
            return View(fUNKCJA);
        }

        // POST: FUNKCJAs/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDFUNKCJA,NAZWA")] FUNKCJA fUNKCJA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fUNKCJA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fUNKCJA);
        }

        // GET: FUNKCJAs/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FUNKCJA fUNKCJA = db.FUNKCJA.Find(id);
            if (fUNKCJA == null)
            {
                return HttpNotFound();
            }
            return View(fUNKCJA);
        }

        // POST: FUNKCJAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            FUNKCJA fUNKCJA = db.FUNKCJA.Find(id);
            db.FUNKCJA.Remove(fUNKCJA);
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
