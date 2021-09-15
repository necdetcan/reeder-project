using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RaporUygulamasi.Models
{
    public class KullanicisController : Controller
    {
        private RaporEntities2 db = new RaporEntities2();

        // GET: Kullanicis
        public ActionResult Index()
        {
            if (Session["Kullanici"] == null)
            {
                return RedirectToAction("Login","Login");
            }
            TempData["Kullanici"] = Session["Kullanici"];
            return View(db.Kullanici.ToList());
        }

        // GET: Kullanicis/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = db.Kullanici.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // GET: Kullanicis/Create
        public ActionResult Create()
        {
            if (Session["Kullanici"] == null)
            {
                return RedirectToAction("Login","Login");
            }

            return View();
        }

        // POST: Kullanicis/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "kullaniciID,kullaniciAdi,sifre,dogumTarihi,ad,soyad,yetki")] Kullanici kullanici)
        {
            
            if (ModelState.IsValid)
            {
             
                try
                {
                    db.Kullanici.Add(kullanici);

                    db.SaveChanges();


                }



                catch (DbEntityValidationException ex)
                {
                    ViewBag.Message = "Kullanıcı oluşturulamadı " + ex;
                }

                ViewBag.Message = "Kullanıcı başarıyla oluşturuldu ";
                TempData["Kullanici"] = Session["Kullanici"];
                return View(kullanici);
            }

            return View(kullanici);
        }

        // GET: Kullanicis/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = db.Kullanici.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // POST: Kullanicis/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "kullaniciID,sifre,dogumTarihi,ad,soyad,yetki")] Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kullanici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kullanici);
        }

        // GET: Kullanicis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = db.Kullanici.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // POST: Kullanicis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Kullanici kullanici = db.Kullanici.Find(id);
            db.Kullanici.Remove(kullanici);
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
        protected void Session_End(Object sender, EventArgs e)
        {
            Session.Abandon(); 
        }
    }
}
