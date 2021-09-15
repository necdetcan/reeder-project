using RaporUygulamasi.Models;
using System.Linq;
using System.Web.Mvc;
using System.Data;
using RaporUygulamasi.ViewModel;
using System.Collections.Generic;

namespace RaporUygulamasi.Controllers
{
    public class LoginController : Controller
    {
        RaporEntities2 re = new RaporEntities2();
        // GET: Login
        public ActionResult Login()
        {
            if(Session["Kullanici"] == null)
            {
                return View();


            }
            else
            {
                @Session["Kullanici"] = null;
               
            }
            return View();
        }
        public static int id22;
        
        [HttpPost]
        public ActionResult Login(Kullanici kullaniciM)
        {
            var kullanici = re.Kullanici.Where(a => a.kullaniciAdi == kullaniciM.kullaniciAdi && a.sifre== kullaniciM.sifre).FirstOrDefault();
            
            if (kullanici == null)
            {
                ViewBag.Message = "Kullanıcı Adı veya Şifre yanlış";
                return View();
            }
            else
            {
                
                id22 = kullanici.ID;
                Session["Kullanici"] = kullanici.ID;
                return RedirectToAction("Raporlar/"+id22);
            }
        }
  
        public ActionResult Raporlar(int? id)
        {

            if(Session["Kullanici"] == null)
            {
                return RedirectToAction("Login");
            }
            var x = re.spRaporSirala(id);
            var y = re.Kullanici.Where(a => a.ID == id).FirstOrDefault();
            ViewBag.yetki = y.yetki;
            TempData["Kullanici"] = Session["Kullanici"];
            return View(x.ToList());
        }
    }
}
