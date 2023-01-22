using PDKS_Code_First.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static PDKS_Code_First.Classes.Class1;

namespace PDKS_Code_First.Controllers
{
    public class BelgelerController : Controller
    {
        // GET: Belgeler
        PDKSCodeFirstContext db = new PDKSCodeFirstContext();
        [Authorize]
        public ActionResult Listele(string tc, string ad, string soyad)
        {
            // Tüm dosyaları veritabanından alın

            var belgeler = from x in db.PersonelBelgeler select x;
            if (!string.IsNullOrEmpty(tc) || !string.IsNullOrEmpty(ad) || !string.IsNullOrEmpty(soyad))
            {
                belgeler = belgeler.Where(x => x.PersonelOzlukBilgileri.TcKimlik.Contains(tc) && x.PersonelOzlukBilgileri.Ad.Contains(ad) && x.PersonelOzlukBilgileri.Soyad.Contains(soyad));
            }
            return View(belgeler.ToList());

        }
        [Authorize]
        public ActionResult EkleListe(string tc, string ad, string soyad)
        {
            var personelbelge = from x in db.PersonelOzlukBilgileri select x;
            if (!string.IsNullOrEmpty(tc) || !string.IsNullOrEmpty(ad) || !string.IsNullOrEmpty(soyad))
            {
                personelbelge = personelbelge.Where(x => x.TcKimlik.Contains(tc) && x.Ad.Contains(ad) && x.Soyad.Contains(soyad));
            }

            return View(personelbelge.ToList());
        }

        [Authorize]
        public ActionResult GetirEkle(int id)
        {

            PersonelBelgelerView personelBelgelerView = new PersonelBelgelerView();

            return View("GetirEkle", GetirekleMetot(personelBelgelerView, id));

        }

        private PersonelBelgelerView GetirekleMetot(PersonelBelgelerView personelBelgelerView, int id)
        {
            var personel = db.PersonelOzlukBilgileri.Find(id);

            personelBelgelerView.PersonelId = personel.Id;
            personelBelgelerView.Tc = personel.TcKimlik;
            personelBelgelerView.Ad = personel.Ad;
            personelBelgelerView.Soyad = personel.Soyad;
            personelBelgelerView.Departmanad = personel.Departmanlar.DepartmanAdi;
            return personelBelgelerView;
        }
        public ActionResult Ekle(PersonelBelgelerView personelBelgelerView, HttpPostedFileBase file)
        {
            try
            {
                
                if (file != null && file.ContentLength > 0)
                {
                    byte[] fileContent = new byte[file.ContentLength];
                    file.InputStream.Read(fileContent, 0, file.ContentLength);

                    // Dosyanın diğer bilgilerini alın
                    string fileName = Path.GetFileName(file.FileName);
                    string fileType = file.ContentType;

                    // Dosyayı veritabanına kaydedin
                    var newFile = new PersonelBelgeler
                    {
                        BelgeAdi = fileName,
                        BelgeTipi = fileType,
                        BelgeYolu = fileContent,
                        PersonelId = personelBelgelerView.PersonelId,
                        BelgeTuru=personelBelgelerView.BelgeTuru
                    };

                    db.PersonelBelgeler.Add(newFile);
                    db.SaveChanges();

                    // Dosyanın ID'sini veya URL'sini geri dönün
                    //int uploadedFileId = newFile.Id;                    
                    //return RedirectToAction("Download", new { id = uploadedFileId });
                    return RedirectToAction("Listele");
                }
                else
                {
                    ViewBag.dosya = "Dosya seçmediniz veya geçersiz dosya!!!";
                    return View("GetirEkle", GetirekleMetot(personelBelgelerView, personelBelgelerView.PersonelId));

                }

            }
            catch (Exception ex)
            {
                TempData["Warning"] = "Hata !!" + ex.Message;
                return View("GetirEkle", GetirekleMetot(personelBelgelerView, personelBelgelerView.PersonelId));
            }
        }

        public ActionResult Download(int id)
        {
            // Dosyayı veritabanından alın
            var file = db.PersonelBelgeler.Find(id);
            if (file != null)
            {
                // Dosyayı indir
                return File(file.BelgeYolu, file.BelgeTipi, file.BelgeAdi);
            }
            else
            {
                // Dosya bulunamadı
                ViewBag.dosyabulunamadı = "Dosya Bulunamadı !!!";
                return View();
            }
        }
        public ActionResult Sil(int id)
        {
            try
            {
                var dosyasil = db.PersonelBelgeler.FirstOrDefault(x => x.Id == id);
                db.PersonelBelgeler.Remove(dosyasil);
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

            PersonelBelgelerView personelBelgelerView = new PersonelBelgelerView();

            return View("GetirGuncelle", GetirGuncelleMetot(personelBelgelerView, id));

        }

        private PersonelBelgelerView GetirGuncelleMetot(PersonelBelgelerView personelBelgelerView, int id)
        {
            var belge = db.PersonelBelgeler.Find(id);
            var personel = db.PersonelOzlukBilgileri.Find(belge.PersonelId);


            personelBelgelerView.PersonelBelgeid = id;
            personelBelgelerView.PersonelId = personel.Id;
            personelBelgelerView.Tc = personel.TcKimlik;
            personelBelgelerView.Ad = personel.Ad;
            personelBelgelerView.Soyad = personel.Soyad;
            personelBelgelerView.Departmanad = personel.Departmanlar.DepartmanAdi;
            personelBelgelerView.BelgeTuru = belge.BelgeTuru;
            //personelBelgelerView.BelgeAdi = belge.BelgeAdi;
            //personelBelgelerView.BelgeTipi = belge.BelgeTipi;
            //personelBelgelerView.BelgeYolu = belge.BelgeYolu;

            return personelBelgelerView;
        }
        public ActionResult Guncelle(PersonelBelgelerView personelBelgelerView, HttpPostedFileBase file)
        {

            try
            {

                    var personelbelge = db.PersonelBelgeler.FirstOrDefault(x => x.Id == personelBelgelerView.PersonelBelgeid);
              
                    personelbelge.BelgeTuru = personelBelgelerView.BelgeTuru;
                                                  
                    db.SaveChanges();

                    return RedirectToAction("Listele");
                     
            }
            catch (Exception ex)
            {
                TempData["Warning"] = "Hata !!" + ex.Message;
                return View("GetirGuncelle", GetirGuncelleMetot(personelBelgelerView, personelBelgelerView.PersonelBelgeid));
            }



        }
    }


}