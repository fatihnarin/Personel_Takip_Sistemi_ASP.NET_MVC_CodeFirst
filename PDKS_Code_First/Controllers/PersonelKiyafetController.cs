using PDKS_Code_First.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static PDKS_Code_First.Classes.Class1;

namespace PDKS_Code_First.Controllers
{
    public class PersonelKiyafetController : Controller
    {
        // GET: PersonelKiyafet
        PDKSCodeFirstContext db = new PDKSCodeFirstContext();

        [Authorize]
        public ActionResult Listele(string tc, string ad, string soyad)
        {
            var personelkiyafet = from x in db.PersonelKiyafet select x;
            if (!string.IsNullOrEmpty(tc) || !string.IsNullOrEmpty(ad) || !string.IsNullOrEmpty(soyad))
            {
                personelkiyafet = personelkiyafet.Where(x => x.PersonelOzlukBilgileri.TcKimlik.Contains(tc) && x.PersonelOzlukBilgileri.Ad.Contains(ad) && x.PersonelOzlukBilgileri.Soyad.Contains(soyad));
            }

            return View(personelkiyafet.ToList());
        }

        [Authorize]
        public ActionResult EkleListe(string tc, string ad, string soyad)
        {
            var personelkiyafet = from x in db.PersonelOzlukBilgileri select x;
            if (!string.IsNullOrEmpty(tc) || !string.IsNullOrEmpty(ad) || !string.IsNullOrEmpty(soyad))
            {
                personelkiyafet = personelkiyafet.Where(x => x.TcKimlik.Contains(tc) && x.Ad.Contains(ad) && x.Soyad.Contains(soyad));
            }

            return View(personelkiyafet.ToList());
        }

        [Authorize]
        public ActionResult GetirEkle(int id)
        {

            PersonelKiyafetView personelKiyafetView = new PersonelKiyafetView();

            return View("GetirEkle", GetirekleMetot(personelKiyafetView, id));

        }

        private PersonelKiyafetView GetirekleMetot(PersonelKiyafetView personelKiyafetView, int id)
        {
            var personel = db.PersonelOzlukBilgileri.Find(id);

            personelKiyafetView.PersonelId = personel.Id;
            personelKiyafetView.Tc = personel.TcKimlik;
            personelKiyafetView.Ad = personel.Ad;
            personelKiyafetView.Soyad = personel.Soyad;
            personelKiyafetView.Departmanad = personel.Departmanlar.DepartmanAdi;
            personelKiyafetView.DepartmanId = personel.DepartmanId;
            return personelKiyafetView;
        }

       
        public ActionResult Ekle(PersonelKiyafetView personelKiyafetView)
        {
            try
            {
             
                    PersonelKiyafet personelKiyafet = new PersonelKiyafet();
                    personelKiyafet.PersonelId = personelKiyafetView.PersonelId;
                    personelKiyafet.DepartmanId = personelKiyafetView.DepartmanId;
                    personelKiyafet.IstekNedeni = personelKiyafetView.Isteknedeni;
                    personelKiyafet.Renk = personelKiyafetView.Renk;
                    personelKiyafet.Model = personelKiyafetView.Model;
                    personelKiyafet.KafaBedenNo = personelKiyafetView.KafaBeden;
                    personelKiyafet.Kilo = personelKiyafetView.Kilo;
                    personelKiyafet.UstBedenNo = personelKiyafetView.UstBeden;
                    personelKiyafet.AltBedenNo = personelKiyafetView.AltBeden;
                    personelKiyafet.AyakkabiNo = personelKiyafetView.Ayakkapi;
                    personelKiyafet.Boy = personelKiyafetView.Boy;
                    db.PersonelKiyafet.Add(personelKiyafet);
                    db.SaveChanges();
                    return RedirectToAction("Listele");
                           
                
            }
            catch (Exception ex)
            {
                TempData["Warning"] = "Hata !!" + ex.Message;

                return View("GetirEkle", GetirekleMetot(personelKiyafetView, personelKiyafetView.PersonelId));
            }
        }

        public ActionResult Sil(int id)
        {
            try
            {
                var kiyafetsil = db.PersonelKiyafet.FirstOrDefault(x => x.Id == id);
                db.PersonelKiyafet.Remove(kiyafetsil);
                db.SaveChanges();
                return RedirectToAction("Listele");
            }
            catch (Exception ex)
            {
                TempData["Warning"] = "Hata !!" + ex.Message;
                return View();
            }

        }

        [Authorize]
        public ActionResult GetirGuncelle(int id)
        {

            PersonelKiyafetView personelKiyafetView = new PersonelKiyafetView();
            return View("GetirGuncelle", GetirGuncelleMetot(personelKiyafetView, id));
        }
        private PersonelKiyafetView GetirGuncelleMetot(PersonelKiyafetView personelKiyafetView, int id)
        {

            var kiyafet = db.PersonelKiyafet.Find(id);
            var personel = db.PersonelOzlukBilgileri.Find(kiyafet.PersonelId);

            personelKiyafetView.kiyafetid = id;
            personelKiyafetView.PersonelId = personel.Id;
            personelKiyafetView.Tc = personel.TcKimlik;
            personelKiyafetView.Ad = personel.Ad;
            personelKiyafetView.Soyad = personel.Soyad;
            personelKiyafetView.Departmanad = personel.Departmanlar.DepartmanAdi;
            personelKiyafetView.DepartmanId = personel.DepartmanId;
            personelKiyafetView.PersonelId = personel.Id;
            personelKiyafetView.Isteknedeni=kiyafet.IstekNedeni;
            personelKiyafetView.Renk=kiyafet.Renk;
            personelKiyafetView.Model=kiyafet.Model;
            personelKiyafetView.KafaBeden=kiyafet.KafaBedenNo;
            personelKiyafetView.Kilo=kiyafet.Kilo;
            personelKiyafetView.UstBeden=kiyafet.UstBedenNo;
            personelKiyafetView.AltBeden=kiyafet.AltBedenNo;
            personelKiyafetView.Ayakkapi=kiyafet.AyakkabiNo;
            personelKiyafetView.Boy=kiyafet.Boy;
            return personelKiyafetView;
        }
        public ActionResult Guncelle(PersonelKiyafetView personelKiyafetView)
        {
            try
            {
                    var personelKiyafet = db.PersonelKiyafet.FirstOrDefault(x => x.Id == personelKiyafetView.kiyafetid);               
                    personelKiyafet.PersonelId = personelKiyafetView.PersonelId;
                    personelKiyafet.DepartmanId = personelKiyafetView.DepartmanId;
                    personelKiyafet.IstekNedeni = personelKiyafetView.Isteknedeni;
                    personelKiyafet.Renk = personelKiyafetView.Renk;
                    personelKiyafet.Model = personelKiyafetView.Model;
                    personelKiyafet.KafaBedenNo = personelKiyafetView.KafaBeden;
                    personelKiyafet.Kilo = personelKiyafetView.Kilo;
                    personelKiyafet.UstBedenNo = personelKiyafetView.UstBeden;
                    personelKiyafet.AltBedenNo = personelKiyafetView.AltBeden;
                    personelKiyafet.AyakkabiNo = personelKiyafetView.Ayakkapi;
                    personelKiyafet.Boy = personelKiyafetView.Boy;

                    db.SaveChanges();
                    return RedirectToAction("Listele");

            }
            catch (Exception ex)
            {
                TempData["Warning"] = "Hata !!" + ex.Message;

                return View("GetirGuncelle", GetirekleMetot(personelKiyafetView, personelKiyafetView.PersonelId));
            }
        }
    }
}