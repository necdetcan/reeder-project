using RaporUygulamasi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaporUygulamasi.ViewModel
{
    public class Tablolar:IEnumerable
    {
        public List<musteriHizmetleri> musteriHizmetleri { get; set; }
        public List<Servis> servis { get; set; }
        public Depo depo { get; set; }
        public DepoParca depoParca { get; set; }
        public int kID { get; set; }
        public IQueryable <Raporlar> raporlar { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}