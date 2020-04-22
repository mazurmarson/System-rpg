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
    public class UZYTKOWNIKsController : Controller
    {
        private RpgSystemEntities db = new RpgSystemEntities();

        // GET: UZYTKOWNIKs
        public ActionResult Index()
        {
            return View(db.UZYTKOWNIK.ToList());
        }

        // GET: UZYTKOWNIKs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UZYTKOWNIK uZYTKOWNIK = db.UZYTKOWNIK.Find(id);
            if (uZYTKOWNIK == null)
            {
                return HttpNotFound();
            }
            return View(uZYTKOWNIK);
        }

        public ActionResult Show(int? id)
        {
            UZYTKOWNIK uzytkownik = db.UZYTKOWNIK.Find(id);
            uzytkownik.IDUZYTKOWNIK = (int)id;
            var item = from a in db.ITEM select a;
            item = item.Where(a => a.UZYTKOWNIK.NAZWA.Contains(uzytkownik.NAZWA));
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if(uzytkownik == null)
            {
                return HttpNotFound();
            }
            return View(item.ToList());
        }

        // GET: UZYTKOWNIKs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UZYTKOWNIKs/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDUZYTKOWNIK,NAZWA,HASLO,EMAIL,TELEFON")] UZYTKOWNIK uZYTKOWNIK)
        {
            if (ModelState.IsValid)
            {
                db.UZYTKOWNIK.Add(uZYTKOWNIK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uZYTKOWNIK);
        }

        // GET: UZYTKOWNIKs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UZYTKOWNIK uZYTKOWNIK = db.UZYTKOWNIK.Find(id);
            if (uZYTKOWNIK == null)
            {
                return HttpNotFound();
            }
            return View(uZYTKOWNIK);
        }

        // POST: UZYTKOWNIKs/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDUZYTKOWNIK,NAZWA,HASLO,EMAIL,TELEFON")] UZYTKOWNIK uZYTKOWNIK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uZYTKOWNIK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uZYTKOWNIK);
        }

        // GET: UZYTKOWNIKs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UZYTKOWNIK uZYTKOWNIK = db.UZYTKOWNIK.Find(id);
            if (uZYTKOWNIK == null)
            {
                return HttpNotFound();
            }
            return View(uZYTKOWNIK);
        }

        // POST: UZYTKOWNIKs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UZYTKOWNIK uZYTKOWNIK = db.UZYTKOWNIK.Find(id);
            db.UZYTKOWNIK.Remove(uZYTKOWNIK);
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
