using RaporUygulamasi.ViewModel;
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
    public class musteriHizmetlerisController : Controller
    {
        private RaporEntities2 db = new RaporEntities2();

        // GET: musteriHizmetleris
        public ActionResult Index()
        {
            if (Session["Kullanici"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var mh = db.musteriHizmetleri.ToList();
            return View(mh);
        }
        // GET: musteriHizmetleris/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            musteriHizmetleri musteriHizmetleri = db.musteriHizmetleri.Find(id);
            if (musteriHizmetleri == null)
            {
                return HttpNotFound();
            }
            return View(musteriHizmetleri);
        }

        // GET: musteriHizmetleris/Create
        public ActionResult Create()
        {
            ViewBag.rapor = new SelectList(db.Raporlar, "ID", "raporID");
            return View();
        }

        // POST: musteriHizmetleris/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,tarih,temsilci,musteriAd,musteriSoyad,musteriTelefon,musteriEmail,musteriSikayeti,musteriyeCevap,musteriyeUlasildi,cihazModel,cihazSeriNo,rapor")] musteriHizmetleri musteriHizmetleri)
        {
            if (ModelState.IsValid)
            {
                db.musteriHizmetleri.Add(musteriHizmetleri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(musteriHizmetleri);
        }

        

        // POST: musteriHizmetleris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            musteriHizmetleri musteriHizmetleri = db.musteriHizmetleri.Find(id);
            db.musteriHizmetleri.Remove(musteriHizmetleri);
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
