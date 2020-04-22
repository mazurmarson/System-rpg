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
    public class DZIALANIEsController : Controller
    {
        private RpgSystemEntities db = new RpgSystemEntities();

        // GET: DZIALANIEs
        public ActionResult Index()
        {
            var dZIALANIE = db.DZIALANIE.Include(d => d.FUNKCJA).Include(d => d.ITEM);
            return View(dZIALANIE.ToList());
        }

        // GET: DZIALANIEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DZIALANIE dZIALANIE = db.DZIALANIE.Find(id);
            if (dZIALANIE == null)
            {
                return HttpNotFound();
            }
            return View(dZIALANIE);
        }

        // GET: DZIALANIEs/Create
        public ActionResult Create()
        {
            ViewBag.IDFUNKCJA = new SelectList(db.FUNKCJA, "IDFUNKCJA", "NAZWA");
            ViewBag.IDITEM = new SelectList(db.ITEM, "IDITEM", "NAZWA");
            return View();
        }

        // POST: DZIALANIEs/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDZIALANIE,IDFUNKCJA,IDITEM,WARTOSC")] DZIALANIE dZIALANIE)
        {
            if (ModelState.IsValid)
            {
                db.DZIALANIE.Add(dZIALANIE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDFUNKCJA = new SelectList(db.FUNKCJA, "IDFUNKCJA", "NAZWA", dZIALANIE.IDFUNKCJA);
            ViewBag.IDITEM = new SelectList(db.ITEM, "IDITEM", "NAZWA", dZIALANIE.IDITEM);
            return View(dZIALANIE);
        }

        // GET: DZIALANIEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DZIALANIE dZIALANIE = db.DZIALANIE.Find(id);
            if (dZIALANIE == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDFUNKCJA = new SelectList(db.FUNKCJA, "IDFUNKCJA", "NAZWA", dZIALANIE.IDFUNKCJA);
            ViewBag.IDITEM = new SelectList(db.ITEM, "IDITEM", "NAZWA", dZIALANIE.IDITEM);
            return View(dZIALANIE);
        }

        // POST: DZIALANIEs/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDZIALANIE,IDFUNKCJA,IDITEM,WARTOSC")] DZIALANIE dZIALANIE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dZIALANIE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDFUNKCJA = new SelectList(db.FUNKCJA, "IDFUNKCJA", "NAZWA", dZIALANIE.IDFUNKCJA);
            ViewBag.IDITEM = new SelectList(db.ITEM, "IDITEM", "NAZWA", dZIALANIE.IDITEM);
            return View(dZIALANIE);
        }

        // GET: DZIALANIEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DZIALANIE dZIALANIE = db.DZIALANIE.Find(id);
            if (dZIALANIE == null)
            {
                return HttpNotFound();
            }
            return View(dZIALANIE);
        }

        // POST: DZIALANIEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DZIALANIE dZIALANIE = db.DZIALANIE.Find(id);
            db.DZIALANIE.Remove(dZIALANIE);
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
