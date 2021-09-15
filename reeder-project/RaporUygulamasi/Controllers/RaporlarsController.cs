using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RaporUygulamasi.Models
{
    public class RaporlarsController : Controller
    {
        private RaporEntities2 db = new RaporEntities2();

        // GET: Raporlars
        public ActionResult Index(int? id)
        {
            var raporlar = db.Raporlar.Where(a => a.ID == id).FirstOrDefault();
            if (raporlar.kategori == "servis")
            {
                return RedirectToAction("Index","Servis");
            }
            else if (raporlar.kategori == "musteriHizmetleri")
            {
                return RedirectToAction("Index", "musteriHizmetleris");
            }

            var x = db.musteriHizmetleri;
            
            return View();
        }

     

        // GET: Raporlars/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raporlar raporlar = db.Raporlar.Find(id);
            if (raporlar == null)
            {
                return HttpNotFound();
            }
            return View(raporlar);
        }

        // GET: Raporlars/Create
        public ActionResult Create()
        {
            ViewBag.kullanici = new SelectList(db.Kullanici, "kullaniciAdi", "sifre");
            return View();
        }

        // POST: Raporlars/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,raporID,kullanici")] Raporlar raporlar)
        {
            if (ModelState.IsValid)
            {
                db.Raporlar.Add(raporlar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.kullanici = new SelectList(db.Kullanici, "ID", "sifre", raporlar.ID);
            return View(raporlar);
        }

        // GET: Raporlars/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raporlar raporlar = db.Raporlar.Find(id);
            if (raporlar == null)
            {
                return HttpNotFound();
            }
            ViewBag.kullanici = new SelectList(db.Kullanici, "kullaniciID", "sifre", raporlar.ID);
            return View(raporlar);
        }

        // POST: Raporlars/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,raporID,kullanici")] Raporlar raporlar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(raporlar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.kullanici = new SelectList(db.Kullanici, "kullaniciID", "sifre", raporlar.ID);
            return View(raporlar);
        }

        // GET: Raporlars/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raporlar raporlar = db.Raporlar.Find(id);
            if (raporlar == null)
            {
                return HttpNotFound();
            }
            return View(raporlar);
        }

        // POST: Raporlars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Raporlar raporlar = db.Raporlar.Find(id);
            db.Raporlar.Remove(raporlar);
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
