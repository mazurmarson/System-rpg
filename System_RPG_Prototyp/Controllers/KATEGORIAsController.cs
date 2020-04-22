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
    public class KATEGORIAsController : Controller
    {
        private RpgSystemEntities db = new RpgSystemEntities();

        // GET: KATEGORIAs
        public ActionResult Index()
        {
            return View(db.KATEGORIA.ToList());
        }

        // GET: KATEGORIAs/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KATEGORIA kATEGORIA = db.KATEGORIA.Find(id);
            if (kATEGORIA == null)
            {
                return HttpNotFound();
            }
            return View(kATEGORIA);
        }

        // GET: KATEGORIAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KATEGORIAs/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDKATEGORIA,NAZWA")] KATEGORIA kATEGORIA)
        {
            if (ModelState.IsValid)
            {
                db.KATEGORIA.Add(kATEGORIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kATEGORIA);
        }

        // GET: KATEGORIAs/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KATEGORIA kATEGORIA = db.KATEGORIA.Find(id);
            if (kATEGORIA == null)
            {
                return HttpNotFound();
            }
            return View(kATEGORIA);
        }

        // POST: KATEGORIAs/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDKATEGORIA,NAZWA")] KATEGORIA kATEGORIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kATEGORIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kATEGORIA);
        }

        // GET: KATEGORIAs/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KATEGORIA kATEGORIA = db.KATEGORIA.Find(id);
            if (kATEGORIA == null)
            {
                return HttpNotFound();
            }
            return View(kATEGORIA);
        }

        // POST: KATEGORIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            KATEGORIA kATEGORIA = db.KATEGORIA.Find(id);
            db.KATEGORIA.Remove(kATEGORIA);
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
