using PDKS_Code_First.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static PDKS_Code_First.Classes.Class1;

namespace PDKS_Code_First.Controllers
{
    public class PersonelCocukController : Controller
    {
        // GET: PersonelCocuk
        PDKSCodeFirstContext db = new PDKSCodeFirstContext();
        public ActionResult Listele(string tc, string ad, string soyad)
        {
            var personelcocuk = from x in db.PersonelCocuk select x;
            if (!string.IsNullOrEmpty(tc) || !string.IsNullOrEmpty(ad) || !string.IsNullOrEmpty(soyad))
            {
                personelcocuk = personelcocuk.Where(x => x.PersonelOzlukBilgileri.TcKimlik.Contains(tc) && x.PersonelOzlukBilgileri.Ad.Contains(ad) && x.PersonelOzlukBilgileri.Soyad.Contains(soyad));
            }

            return View(personelcocuk.ToList());
        }
        public ActionResult EkleListe(string tc, string ad, string soyad)
        {
            var personelcocuk = from x in db.PersonelOzlukBilgileri select x;
            if (!string.IsNullOrEmpty(tc) || !string.IsNullOrEmpty(ad) || !string.IsNullOrEmpty(soyad))
            {
                personelcocuk = personelcocuk.Where(x => x.TcKimlik.Contains(tc) && x.Ad.Contains(ad) && x.Soyad.Contains(soyad));
            }

            return View(personelcocuk.ToList());
        }
        public ActionResult GetirEkle(int id)
        {

            PersonelCocukView personelCocukView = new PersonelCocukView();

            return View("GetirEkle", GetirekleMetot(personelCocukView, id));

        }

        private PersonelCocukView GetirekleMetot(PersonelCocukView personelCocukView, int id)
        {
            var personel = db.PersonelOzlukBilgileri.Find(id);

            personelCocukView.PersonelId = personel.Id;
            personelCocukView.Tc = personel.TcKimlik;
            personelCocukView.Ad = personel.Ad;
            personelCocukView.Soyad = personel.Soyad;
            personelCocukView.Departmanad = personel.Departmanlar.DepartmanAdi;
            return personelCocukView;
        }

        public ActionResult Ekle(PersonelCocukView personelCocukView)
        {
            try
            {
                PersonelCocuk personelCocuk = new PersonelCocuk();

                var bul = db.PersonelCocuk.FirstOrDefault(x => x.CocukTc == personelCocukView.CocukTc && x.PersonelId==personelCocukView.PersonelId);
                if (bul==null)
                {
                    if (personelCocuk.CocukDogumTarihi<= DateTime.Today)
                    {
                        personelCocuk.PersonelId = personelCocukView.PersonelId;
                        personelCocuk.CocukTc = personelCocukView.CocukTc;
                        personelCocuk.CocukAdiSoyadi = personelCocukView.CocukAdiSoyadi;
                        personelCocuk.CocukCinsiyet = personelCocuk.CocukCinsiyet;
                        personelCocuk.CocukDogumTarihi = personelCocukView.CocukDogumTarihi;
                        db.PersonelCocuk.Add(personelCocuk);
                        db.SaveChanges();
                        return RedirectToAction("Listele");
                    }
                    else
                    {
                        ViewBag.Cocukdogum = "Çocuk doğum tarihi bugunden sonra olomaz.";
                        return View("GetirEkle", GetirekleMetot(personelCocukView, personelCocukView.PersonelId));
                    }
                    
                }
                else
                {
                    ViewBag.Cocuktc = "Personelin aynı TC kimlik numaralı çocuk kaydı bulunmakdadır.";
                    return View("GetirEkle", GetirekleMetot(personelCocukView, personelCocukView.PersonelId));
                }
            }
            catch (Exception ex)
            {
                TempData["Warning"] = "Hata !!" + ex.Message;
                return View("GetirEkle", GetirekleMetot(personelCocukView, personelCocukView.PersonelId));
            }
        }
        public ActionResult Sil(int id)
        {
            try
            {
                var cocuksil = db.PersonelCocuk.FirstOrDefault(x => x.Id == id);
                db.PersonelCocuk.Remove(cocuksil);
                db.SaveChanges();
                return RedirectToAction("Listele");
            }
            catch (Exception ex)
            {
                TempData["Warning"] = "Hata !!" + ex.Message;
                return View();
            }

        }
        public ActionResult GetirGuncelle(int id)
        {

            PersonelCocukView personelCocukView = new PersonelCocukView();

            return View("GetirGuncelle", GetirGuncelleMetot(personelCocukView, id));

        }

        private PersonelCocukView GetirGuncelleMetot(PersonelCocukView personelCocukView, int id)
        {
            var cocuk = db.PersonelCocuk.Find(id);
            var personel = db.PersonelOzlukBilgileri.Find(cocuk.PersonelId);

            personelCocukView.Cocukid = id;
            personelCocukView.PersonelId = personel.Id;
            personelCocukView.Tc = personel.TcKimlik;
            personelCocukView.Ad = personel.Ad;
            personelCocukView.Soyad = personel.Soyad;
            personelCocukView.Departmanad = personel.Departmanlar.DepartmanAdi;
            personelCocukView.CocukTc = cocuk.CocukTc;
            personelCocukView.CocukAdiSoyadi = cocuk.CocukAdiSoyadi;
            personelCocukView.CocukCinsiyet = cocuk.CocukCinsiyet;
            personelCocukView.CocukDogumTarihi = cocuk.CocukDogumTarihi;
            return personelCocukView;
        }
        public ActionResult Guncelle(PersonelCocukView personelCocukView)
        {
            
            try
            {
                if (personelCocukView.CocukDogumTarihi <= DateTime.Today)
                {
                    var personelCocuk = db.PersonelCocuk.FirstOrDefault(x => x.Id == personelCocukView.Cocukid);


                    personelCocuk.PersonelId = personelCocukView.PersonelId;
                    personelCocuk.CocukTc = personelCocukView.CocukTc;
                    personelCocuk.CocukAdiSoyadi = personelCocukView.CocukAdiSoyadi;
                    personelCocuk.CocukCinsiyet = personelCocukView.CocukCinsiyet;
                    personelCocuk.CocukDogumTarihi = personelCocukView.CocukDogumTarihi;
                    db.SaveChanges();
                    return RedirectToAction("Listele");
                }
                else
                {
                    ViewBag.Cocukdogum = "Çocuk doğum tarihi bugunden sonra olomaz.";
                    return View("GetirGuncelle", GetirGuncelleMetot(personelCocukView, personelCocukView.PersonelId));
                }
             
            }
            catch (Exception ex)
            {
                TempData["Warning"] = "Hata !!" + ex.Message;
                return View("GetirGuncelle", GetirGuncelleMetot(personelCocukView, personelCocukView.PersonelId));
            }
            


        }
    }
}