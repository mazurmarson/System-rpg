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
    public class ITEMsController : Controller
    {
        private RpgSystemEntities db = new RpgSystemEntities();

        // GET: ITEMs
        public ActionResult Index()
        {
            var iTEM = db.ITEM.Include(i => i.KATEGORIA).Include(i => i.UZYTKOWNIK);
            return View(iTEM.ToList());
        }

        // GET: ITEMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEM iTEM = db.ITEM.Find(id);
            if (iTEM == null)
            {
                return HttpNotFound();
            }
            return View(iTEM);
        }

        // GET: ITEMs/Create
        public ActionResult Create()
        {
            ViewBag.IDKATEGORIA = new SelectList(db.KATEGORIA, "IDKATEGORIA", "NAZWA");
            ViewBag.IDUZYTKOWNIK = new SelectList(db.UZYTKOWNIK, "IDUZYTKOWNIK", "NAZWA");
            return View();
        }



        // POST: ITEMs/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDITEM,IDKATEGORIA,IDUZYTKOWNIK,WAGA,DWURECZNOSC,NAZWA")] ITEM iTEM)
        {
            if (ModelState.IsValid)
            {
                db.ITEM.Add(iTEM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDKATEGORIA = new SelectList(db.KATEGORIA, "IDKATEGORIA", "NAZWA", iTEM.IDKATEGORIA);
            ViewBag.IDUZYTKOWNIK = new SelectList(db.UZYTKOWNIK, "IDUZYTKOWNIK", "NAZWA", iTEM.IDUZYTKOWNIK);
            return View(iTEM);
        }

        // GET: ITEMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEM iTEM = db.ITEM.Find(id);
            if (iTEM == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDKATEGORIA = new SelectList(db.KATEGORIA, "IDKATEGORIA", "NAZWA", iTEM.IDKATEGORIA);
            ViewBag.IDUZYTKOWNIK = new SelectList(db.UZYTKOWNIK, "IDUZYTKOWNIK", "NAZWA", iTEM.IDUZYTKOWNIK);
            return View(iTEM);
        }

        // POST: ITEMs/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDITEM,IDKATEGORIA,IDUZYTKOWNIK,WAGA,DWURECZNOSC,NAZWA")] ITEM iTEM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iTEM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDKATEGORIA = new SelectList(db.KATEGORIA, "IDKATEGORIA", "NAZWA", iTEM.IDKATEGORIA);
            ViewBag.IDUZYTKOWNIK = new SelectList(db.UZYTKOWNIK, "IDUZYTKOWNIK", "NAZWA", iTEM.IDUZYTKOWNIK);
            return View(iTEM);
        }

        // GET: ITEMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEM iTEM = db.ITEM.Find(id);
            if (iTEM == null)
            {
                return HttpNotFound();
            }
            return View(iTEM);
        }

        // POST: ITEMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ITEM iTEM = db.ITEM.Find(id);
            db.ITEM.Remove(iTEM);
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
