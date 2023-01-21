using PDKS_Code_First.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static PDKS_Code_First.Classes.Class1;

namespace PDKS_Code_First.Controllers
{
    public class PersonelEgitimController : Controller
    {
        // GET: PersonelEgitim
        PDKSCodeFirstContext db = new PDKSCodeFirstContext();
        public ActionResult Listele(string tc, string ad, string soyad)
        {
            var personelegitim = from x in db.PersonelEgitim select x;
            if (!string.IsNullOrEmpty(tc) || !string.IsNullOrEmpty(ad) || !string.IsNullOrEmpty(soyad))
            {
                personelegitim = personelegitim.Where(x => x.PersonelOzlukBilgileri.TcKimlik.Contains(tc) && x.PersonelOzlukBilgileri.Ad.Contains(ad) && x.PersonelOzlukBilgileri.Soyad.Contains(soyad));
            }

            return View(personelegitim.ToList());
        }

        public ActionResult EkleListe(string tc, string ad, string soyad)
        {
            var personelegitim = from x in db.PersonelOzlukBilgileri select x;
            if (!string.IsNullOrEmpty(tc) || !string.IsNullOrEmpty(ad) || !string.IsNullOrEmpty(soyad))
            {
                personelegitim = personelegitim.Where(x => x.TcKimlik.Contains(tc) && x.Ad.Contains(ad) && x.Soyad.Contains(soyad));
            }

            return View(personelegitim.ToList());
        }

        public ActionResult GetirEkle(int id)
        {

            PersonelEgitimView personelEgitimView = new PersonelEgitimView();

            return View("GetirEkle", GetirekleMetot(personelEgitimView, id));

        }

        private PersonelEgitimView GetirekleMetot(PersonelEgitimView personelEgitimView, int id)
        {
            var personel = db.PersonelOzlukBilgileri.Find(id);

            personelEgitimView.PersonelId = personel.Id;
            personelEgitimView.Tc = personel.TcKimlik;
            personelEgitimView.Ad = personel.Ad;
            personelEgitimView.Soyad = personel.Soyad;
            personelEgitimView.Departmanad = personel.Departmanlar.DepartmanAdi;
            return personelEgitimView;
        }
        public ActionResult Ekle(PersonelEgitimView personelEgitimView)
        {
            try
            {
                PersonelEgitim personelEgitim = new PersonelEgitim();

                var bul = db.PersonelEgitim.FirstOrDefault(x => x.PersonelId == personelEgitimView.PersonelId );
                if (bul == null)
                {

                    personelEgitim.PersonelId = personelEgitimView.PersonelId;
                    personelEgitim.EgitimDurumu = personelEgitimView.EgitimDurumu;
                    personelEgitim.SonMezunOlduguUkulAdı = personelEgitimView.SonMezunOlduguUkulAdı;
                    db.PersonelEgitim.Add(personelEgitim);
                    db.SaveChanges();
                    return RedirectToAction("Listele");                    
                }
                else
                {
                    ViewBag.egitim = "Personelin eğitim bilgileri kayıtlıdır. Değişiklik yapmak için güncelleme yapabilirsiniz.";
                    return View("GetirEkle", GetirekleMetot(personelEgitimView, personelEgitimView.PersonelId));
                }
            }
            catch (Exception ex)
            {
                TempData["Warning"] = "Hata !!" + ex.Message;
                return View("GetirEkle", GetirekleMetot(personelEgitimView, personelEgitimView.PersonelId));
            }
        }
        public ActionResult Sil(int id)
        {
            try
            {
                var egitimsil = db.PersonelEgitim.FirstOrDefault(x => x.Id == id);
                db.PersonelEgitim.Remove(egitimsil);
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

            PersonelEgitimView personelEgitimView = new PersonelEgitimView();

            return View("GetirGuncelle", GetirGuncelleMetot(personelEgitimView, id));

        }

        private PersonelEgitimView GetirGuncelleMetot(PersonelEgitimView personelEgitimView, int id)
        {
            var egitim = db.PersonelEgitim.Find(id);
            var personel = db.PersonelOzlukBilgileri.Find(egitim.PersonelId);


            personelEgitimView.PersonelEgitimid = id;
            personelEgitimView.PersonelId = personel.Id;
            personelEgitimView.Tc = personel.TcKimlik;
            personelEgitimView.Ad = personel.Ad;
            personelEgitimView.Soyad = personel.Soyad;
            personelEgitimView.Departmanad = personel.Departmanlar.DepartmanAdi;
            personelEgitimView.EgitimDurumu = egitim.EgitimDurumu;
            personelEgitimView.SonMezunOlduguUkulAdı = egitim.SonMezunOlduguUkulAdı;
           
            return personelEgitimView;
        }
        public ActionResult Guncelle(PersonelEgitimView personelEgitimView )
        {

            try
            {
               
               var personelEgitim = db.PersonelEgitim.FirstOrDefault(x => x.Id == personelEgitimView.PersonelEgitimid);

                personelEgitim.EgitimDurumu = personelEgitimView.EgitimDurumu;
                personelEgitim.SonMezunOlduguUkulAdı = personelEgitimView.SonMezunOlduguUkulAdı;
                db.SaveChanges();
                return RedirectToAction("Listele");

            }
            catch (Exception ex)
            {
                TempData["Warning"] = "Hata !!" + ex.Message;
                return View("GetirGuncelle", GetirGuncelleMetot(personelEgitimView, personelEgitimView.PersonelId));
            }



        }



    }
}