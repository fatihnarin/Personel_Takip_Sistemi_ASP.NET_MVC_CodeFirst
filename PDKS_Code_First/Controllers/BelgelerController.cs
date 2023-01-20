using PDKS_Code_First.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PDKS_Code_First.Controllers
{
    public class BelgelerController : Controller
    {
        // GET: Belgeler
        PDKSCodeFirstContext db = new PDKSCodeFirstContext();
        //public ActionResult Listele(string tc, string ad, string soyad)
        //{
        //    var belgeler = from x in db.PersonelBelgeler select x;
        //    if (!string.IsNullOrEmpty(tc) || !string.IsNullOrEmpty(ad) || !string.IsNullOrEmpty(soyad))
        //    {
        //        belgeler = belgeler.Where(x => x.PersonelOzlukBilgileri.TcKimlik.Contains(tc) && x.PersonelOzlukBilgileri.Ad.Contains(ad) && x.PersonelOzlukBilgileri.Soyad.Contains(soyad));
        //    }

        //    return View(belgeler.ToList());
        //}
    }
}