using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RaporUygulamasi.Models;

namespace RaporUygulamasi.Controllers
{
    public class KullaniciRaporsController : Controller
    {
        private RaporEntities2 db = new RaporEntities2();

        // GET: KullaniciRapors
        public ActionResult Index()
        {
            if (Session["Kullanici"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            TempData["Kullanici"] = Session["Kullanici"];
            var kullaniciRapor = db.KullaniciRapor.Include(k => k.Kullanici).Include(k => k.Raporlar);
            return View(kullaniciRapor.ToList());
        }

        // GET: KullaniciRapors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KullaniciRapor kullaniciRapor = db.KullaniciRapor.Find(id);
            if (kullaniciRapor == null)
            {
                return HttpNotFound();
            }
            return View(kullaniciRapor);
        }

        // GET: KullaniciRapors/Create
        public ActionResult Create()
        {
            if (Session["Kullanici"] == null)
            {
                return RedirectToAction("Login","Login");
            }

            ViewBag.kullaniciID = new SelectList(db.Kullanici, "ID", "kullaniciAdi");
            ViewBag.RaporID = new SelectList(db.Raporlar, "ID", "raporAdi");
            return View();
        }

        // POST: KullaniciRapors/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,kullaniciID,RaporID")] KullaniciRapor kullaniciRapor)
        {
            if (ModelState.IsValid) 
            {
                var a = db.KullaniciRapor.Where(ab => ab.kullaniciID == kullaniciRapor.kullaniciID && ab.RaporID == kullaniciRapor.RaporID ).FirstOrDefault();
                if(a != null)
                {
                    ViewBag.uyari = "Rapor daha önce aynı kişiye atanmış.";
                    return RedirectToAction("Index");
                }
                db.KullaniciRapor.Add(kullaniciRapor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.kullaniciID = new SelectList(db.Kullanici, "ID", "sifre", kullaniciRapor.kullaniciID);
            ViewBag.RaporID = new SelectList(db.Raporlar, "ID", "raporAdi", kullaniciRapor.RaporID);
            return View(kullaniciRapor);
        }

        // GET: KullaniciRapors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KullaniciRapor kullaniciRapor = db.KullaniciRapor.Find(id);
            if (kullaniciRapor == null)
            {
                return HttpNotFound();
            }
            ViewBag.kullaniciID = new SelectList(db.Kullanici, "ID", "sifre", kullaniciRapor.kullaniciID);
            ViewBag.RaporID = new SelectList(db.Raporlar, "ID", "raporAdi", kullaniciRapor.RaporID);
            return View(kullaniciRapor);
        }

        // POST: KullaniciRapors/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,kullaniciID,RaporID")] KullaniciRapor kullaniciRapor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kullaniciRapor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.kullaniciID = new SelectList(db.Kullanici, "ID", "sifre", kullaniciRapor.kullaniciID);
            ViewBag.RaporID = new SelectList(db.Raporlar, "ID", "raporAdi", kullaniciRapor.RaporID);
            return View(kullaniciRapor);
        }

        // GET: KullaniciRapors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KullaniciRapor kullaniciRapor = db.KullaniciRapor.Find(id);
            if (kullaniciRapor == null)
            {
                return HttpNotFound();
            }
            return View(kullaniciRapor);
        }

        // POST: KullaniciRapors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KullaniciRapor kullaniciRapor = db.KullaniciRapor.Find(id);
            db.KullaniciRapor.Remove(kullaniciRapor);
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
