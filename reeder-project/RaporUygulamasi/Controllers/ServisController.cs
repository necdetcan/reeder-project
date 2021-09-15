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
    public class ServisController : Controller
    {
        private RaporEntities2 db = new RaporEntities2();

        // GET: Servis
        public ActionResult Index()
        {
            var servis = db.Servis;
            return View(servis.ToList());
        }

      
    }
}
