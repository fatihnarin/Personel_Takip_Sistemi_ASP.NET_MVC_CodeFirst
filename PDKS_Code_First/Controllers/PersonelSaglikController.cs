using PDKS_Code_First.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static PDKS_Code_First.Classes.Class1;

namespace PDKS_Code_First.Controllers
{
    public class PersonelSaglikController : Controller
    {
        // GET: PersonelSaglik
        PDKSCodeFirstContext db = new PDKSCodeFirstContext();
        public ActionResult Listele(string tc, string ad, string soyad)
        {
            var personelsaglik = from x in db.PersonelSaglikDurumlari select x;
            if (!string.IsNullOrEmpty(tc) || !string.IsNullOrEmpty(ad) || !string.IsNullOrEmpty(soyad))
            {
                personelsaglik = personelsaglik.Where(x => x.PersonelOzlukBilgileri.TcKimlik.Contains(tc) && x.PersonelOzlukBilgileri.Ad.Contains(ad) && x.PersonelOzlukBilgileri.Soyad.Contains(soyad));
            }

            return View(personelsaglik.ToList());
        }
        public ActionResult EkleListe(string tc, string ad, string soyad)
        {
            var personelsaglik = from x in db.PersonelOzlukBilgileri select x;
            if (!string.IsNullOrEmpty(tc) || !string.IsNullOrEmpty(ad) || !string.IsNullOrEmpty(soyad))
            {
                personelsaglik = personelsaglik.Where(x => x.TcKimlik.Contains(tc) && x.Ad.Contains(ad) && x.Soyad.Contains(soyad));
            }

            return View(personelsaglik.ToList());
        }

        public ActionResult GetirEkle(int id)
        {

            PersonelSaglikView personelSaglikView = new PersonelSaglikView();

            return View("GetirEkle", GetirekleMetot(personelSaglikView, id));

        }

        private PersonelSaglikView GetirekleMetot(PersonelSaglikView personelSaglikView, int id)
        {
            var personel = db.PersonelOzlukBilgileri.Find(id);

            personelSaglikView.PersonelId = personel.Id;
            personelSaglikView.Tc = personel.TcKimlik;
            personelSaglikView.Ad = personel.Ad;
            personelSaglikView.Soyad = personel.Soyad;
            personelSaglikView.Departmanad = personel.Departmanlar.DepartmanAdi;
            return personelSaglikView;
        }
        public ActionResult Ekle(PersonelSaglikView personelSaglikView)
        {
            try
            {
                PersonelSaglikDurumlari personelSaglikDurumlari = new PersonelSaglikDurumlari();

                var bul = db.PersonelSaglikDurumlari.FirstOrDefault(x => x.PersonelId == personelSaglikView.PersonelId);
                if (bul == null)
                {

                    personelSaglikDurumlari.PersonelId = personelSaglikView.PersonelId;
                    personelSaglikDurumlari.Aciklama = personelSaglikView.Aciklama;
                    personelSaglikDurumlari.Alerji= personelSaglikView.Alerji;
                    personelSaglikDurumlari.AstimKoah= personelSaglikView.AstimKoah;
                    personelSaglikDurumlari.BagisiklikGuclugu= personelSaglikView.BagisiklikGuclugu;
                    personelSaglikDurumlari.GormeKusuru= personelSaglikView.GormeKusuru;
                    personelSaglikDurumlari.IsitmeKaybi= personelSaglikView.IsitmeKaybi;
                    personelSaglikDurumlari.KalpHastaligi= personelSaglikView.KalpHastaligi;
                    personelSaglikDurumlari.KanGrubu= personelSaglikView.KanGrubu;
                    personelSaglikDurumlari.KasEklem= personelSaglikView.KasEklem;
                    personelSaglikDurumlari.KronikHastalik= personelSaglikView.KronikHastalik;
                    personelSaglikDurumlari.RuhsalHastalik= personelSaglikView.RuhsalHastalik;
                    personelSaglikDurumlari.SindirimRahatsizliklari= personelSaglikView.SindirimRahatsizliklari;
                    personelSaglikDurumlari.ZihinselHastalik= personelSaglikView.ZihinselHastalik;
                  
                    db.PersonelSaglikDurumlari.Add(personelSaglikDurumlari);
                    db.SaveChanges();
                    return RedirectToAction("Listele");
                }
                else
                {
                    ViewBag.saglik = "Personelin sağlık bilgileri kayıtlıdır. Değişiklik yapmak için güncelleme yapabilirsiniz.";
                    return View("GetirEkle", GetirekleMetot(personelSaglikView, personelSaglikView.PersonelId));
                }
            }
            catch (Exception ex)
            {
                TempData["Warning"] = "Hata !!" + ex.Message;
                return View("GetirEkle", GetirekleMetot(personelSaglikView, personelSaglikView.PersonelId));
            }
        }
        public ActionResult Sil(int id)
        {
            try
            {
                var sagliksil = db.PersonelSaglikDurumlari.FirstOrDefault(x => x.Id == id);
                db.PersonelSaglikDurumlari.Remove(sagliksil);
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

            PersonelSaglikView personelSaglikView = new PersonelSaglikView();

            return View("GetirGuncelle", GetirGuncelleMetot(personelSaglikView, id));

        }

        private PersonelSaglikView  GetirGuncelleMetot(PersonelSaglikView personelSaglikView, int id)
        {
            var saglik = db.PersonelSaglikDurumlari.Find(id);
            var personel = db.PersonelOzlukBilgileri.Find(saglik.PersonelId);


            personelSaglikView.PersonelSaglikid = id;
            personelSaglikView.PersonelId = personel.Id;
            personelSaglikView.Tc = personel.TcKimlik;
            personelSaglikView.Ad = personel.Ad;
            personelSaglikView.Soyad = personel.Soyad;
            personelSaglikView.Departmanad = personel.Departmanlar.DepartmanAdi;
            personelSaglikView.Aciklama=saglik.Aciklama;
            personelSaglikView.Alerji=saglik.Alerji;
            personelSaglikView.AstimKoah=saglik.AstimKoah;
            personelSaglikView.BagisiklikGuclugu=saglik.BagisiklikGuclugu;
            personelSaglikView.GormeKusuru=saglik.GormeKusuru;
            personelSaglikView.IsitmeKaybi=saglik.IsitmeKaybi;
            personelSaglikView.KalpHastaligi=saglik.KalpHastaligi;
            personelSaglikView.KanGrubu=saglik.KanGrubu;
            personelSaglikView.KasEklem=saglik.KasEklem;
            personelSaglikView.KronikHastalik=saglik.KronikHastalik;
            personelSaglikView.RuhsalHastalik=saglik.RuhsalHastalik;
            personelSaglikView.SindirimRahatsizliklari=saglik.SindirimRahatsizliklari;
            personelSaglikView.ZihinselHastalik=saglik.ZihinselHastalik;


            return personelSaglikView;
        }
        public ActionResult Guncelle(PersonelSaglikView personelSaglikView)
        {

            try
            {

                var personelSaglikDurumlari = db.PersonelSaglikDurumlari.FirstOrDefault(x => x.Id == personelSaglikView.PersonelSaglikid);

                
                personelSaglikDurumlari.Aciklama = personelSaglikView.Aciklama;
                personelSaglikDurumlari.Alerji = personelSaglikView.Alerji;
                personelSaglikDurumlari.AstimKoah = personelSaglikView.AstimKoah;
                personelSaglikDurumlari.BagisiklikGuclugu = personelSaglikView.BagisiklikGuclugu;
                personelSaglikDurumlari.GormeKusuru = personelSaglikView.GormeKusuru;
                personelSaglikDurumlari.IsitmeKaybi = personelSaglikView.IsitmeKaybi;
                personelSaglikDurumlari.KalpHastaligi = personelSaglikView.KalpHastaligi;
                personelSaglikDurumlari.KanGrubu = personelSaglikView.KanGrubu;
                personelSaglikDurumlari.KasEklem = personelSaglikView.KasEklem;
                personelSaglikDurumlari.KronikHastalik = personelSaglikView.KronikHastalik;
                personelSaglikDurumlari.RuhsalHastalik = personelSaglikView.RuhsalHastalik;
                personelSaglikDurumlari.SindirimRahatsizliklari = personelSaglikView.SindirimRahatsizliklari;
                personelSaglikDurumlari.ZihinselHastalik = personelSaglikView.ZihinselHastalik;

                db.SaveChanges();
                return RedirectToAction("Listele");

            }
            catch (Exception ex)
            {
                TempData["Warning"] = "Hata !!" + ex.Message;
                return View("GetirGuncelle", GetirGuncelleMetot(personelSaglikView, personelSaglikView.PersonelSaglikid));
            }



        }
    }
}