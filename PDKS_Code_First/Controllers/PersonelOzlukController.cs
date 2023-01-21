using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PDKS_Code_First.Entity;
using PagedList;
using PagedList.Mvc;
using System.Net;

namespace PDKS_Code_First.Controllers
{
    public class PersonelOzlukController : Controller
    {
        // GET: PersonelOzluk
        PDKSCodeFirstContext db = new PDKSCodeFirstContext();
    
        public ActionResult Listele(int sayfa=1)
        {

            var personelozlukliste = db.PersonelOzlukBilgileri.ToList().ToPagedList(sayfa,10);     
            return View(personelozlukliste);
        }

     
        public ActionResult Ara(string tc, string ad, string soyad)
        {

            var personel = from x in db.PersonelOzlukBilgileri select x;
            if (!string.IsNullOrEmpty(tc) || !string.IsNullOrEmpty(ad) || !string.IsNullOrEmpty(soyad) )
            {
                personel = personel.Where(x => x.TcKimlik.Contains(tc)&& x.Ad.Contains(ad)&& x.Soyad.Contains(soyad));
            }

            return View(personel.ToList());
        }

       
        public ActionResult Ekle()
        {
            ViewBag.drop = DepartmanList(); //controlerdan view e taşımak için
            return View();
        }
        [HttpPost]
      
        public ActionResult Ekle(PersonelOzlukBilgileri personel)
        {

            try
            {
                var durum = db.PersonelOzlukBilgileri.FirstOrDefault(x => x.TcKimlik == personel.TcKimlik || x.KurumSicilNo == personel.KurumSicilNo);

                var departman1 = db.Departmanlar.Where(x => x.Id == personel.Departmanlar.Id).FirstOrDefault();
                personel.Departmanlar= departman1;
                
                if (durum == null)
                {
                    if (personel.Cinsiyet==false &&personel.Askerlik==null)
                    {
                        ViewBag.drop = DepartmanList(); //Kayıt olmayınca hatayı önlemek için                           
                        ViewBag.askerlik = "Erkek personelin askerlik durumu belirtirmelidir.";
                        return View("Ekle");
                    }
                    else if (personel.Cinsiyet == true && personel.Askerlik != null)
                    {
                        ViewBag.drop = DepartmanList(); //Kayıt olmayınca hatayı önlemek için                           
                        ViewBag.askerlik = "Kadın personele askerlik bilgisi girilemez.";
                        return View("Ekle");
                    }
                    else if (personel.MedeniDurum==true &&(personel.EsiAdiSoyadi==null||personel.EsiIsDurumu==null|| personel.EsiTc==null||personel.EsiTelefon==null))
                    {
                        ViewBag.drop = DepartmanList(); //Kayıt olmayınca hatayı önlemek için                           
                        ViewBag.es = "Evli personelin eş bilgileri girilmelidir..";
                        return View("Ekle");
                    }                 
                    else if (personel.AktifPasif==false && personel.CikisTarihi==null)
                    {
                        ViewBag.drop = DepartmanList(); //Kayıt olmayınca hatayı önlemek için                           
                        ViewBag.cikis = "Durumu pasif olan personelin işten çıkış tarihi girilmelidir.";
                        return View("Ekle");
                    }
                    else
                    {
                  
                         if (personel.İseGirisTarihi < personel.CikisTarihi)
                        {
                            ViewBag.drop = DepartmanList(); //Kayıt olmayınca hatayı önlemek için                           
                            ViewBag.giristarih = "İşe giriş tarih çıkış tarihinden sonra olamaz.";
                            ViewBag.cikistarih = "İşten çıkış tarihi işe giriş tarihinden sonra olmalıdır.";
                            return View("Ekle");
                        }
                        else if (personel.DogumTarihi > personel.İseGirisTarihi)
                        {
                            ViewBag.drop = DepartmanList(); //Kayıt olmayınca hatayı önlemek için                           
                            ViewBag.dogumtarih = "Doğum tarihi ise giriş tarihinden önce olmamaz.";
                            return View("Ekle");
                        }
                        else if(personel.İseGirisTarihi>DateTime.Today)
                        {
                            ViewBag.drop = DepartmanList(); //Kayıt olmayınca hatayı önlemek için                           
                            ViewBag.giris1tarih = "İşe giriş tarihi ileri bir tarih olamaz.";
                            return View("Ekle");
                        }
                        else
                        {
                            db.PersonelOzlukBilgileri.Add(personel);
                            db.SaveChanges();
                            return RedirectToAction("Listele");
                        }                                               
                    }                                       
                }
                else 
                {     
                    ViewBag.drop = DepartmanList(); //Kayıt olmayınca hatayı önlemek için
                    TempData["Warning"] = "Aynı TC kimlik veya Sicil nolu personel kayıtlıdır. Tekrar kayıt yapılamaz";
                    return View("Ekle");
                }                
            }
            catch (Exception ex)
            {               
                ViewBag.drop = DepartmanList(); //Kayıt olmayınca hatayı önlemek için

                TempData["Warning"] = "Hata !!" + ex.Message;
                    return View("Ekle");                
            }        
        }


        //[Authorize]
        public ActionResult Sil(int id)
        {
            var durum1 = db.IzinTakip.FirstOrDefault(x => x.PersonelId == id);
            var durum2 = db.PersonelCocuk.FirstOrDefault(x => x.PersonelId == id);
            var durum3 = db.PersonelEgitim.FirstOrDefault(x => x.PersonelId == id);
            var durum4 = db.PersonelKiyafet.FirstOrDefault(x => x.PersonelId == id);
            var durum5 = db.PersonelPuantaj.FirstOrDefault(x => x.PersonelId == id);
            var durum6 = db.PersonelSaglikDurumlari.FirstOrDefault(x => x.PersonelId == id);
            if (durum1==null&& durum2 == null && durum3 == null && durum4 == null && durum5 == null && durum6 == null)
            {
                var personel = db.PersonelOzlukBilgileri.FirstOrDefault(x => x.Id == id);
                db.PersonelOzlukBilgileri.Remove(personel);
                db.SaveChanges();
                return RedirectToAction("Listele");
            }
            else
            {
                var personel = db.PersonelOzlukBilgileri.FirstOrDefault(x => x.Id == id);
                TempData["Warning"] = personel.TcKimlik.ToString() + " TC kimlik numaları personelin diğer tablolarda kaydı bulunmaktadır. " +
                    "Personelin kaydını silebilmeniz için diğer tablolarda kaydının bulunmaması gerekmektedir!!";
                return RedirectToAction("Listele");
            }
        }
        //[Authorize]
        public ActionResult Getir(int id)
        {
            ViewBag.drop = DepartmanList(); //controlerdan view e taşımak için
            var personel = db.PersonelOzlukBilgileri.Find(id);
            return View("Getir", personel);
        }
        public ActionResult Guncelle(PersonelOzlukBilgileri personel)
        {
            try
            {
                var guncel = db.PersonelOzlukBilgileri.Find(personel.Id);


                    if (personel.Cinsiyet == false && personel.Askerlik == null)
                    {
                        ViewBag.drop = DepartmanList(); //Kayıt olmayınca hatayı önlemek için                           
                        ViewBag.askerlik = "Erkek personelin askerlik durumu belirtirmelidir.";
                        return View("Getir");
                    }
                    else if (personel.Cinsiyet == true && personel.Askerlik != null)
                    {
                        ViewBag.drop = DepartmanList(); //Kayıt olmayınca hatayı önlemek için                           
                        ViewBag.askerlik = "Kadın personele askerlik bilgisi girilemez.";
                        return View("Getir");
                    }
                    else if (personel.MedeniDurum == true && (personel.EsiAdiSoyadi == null || personel.EsiIsDurumu == null || personel.EsiTc == null || personel.EsiTelefon == null))
                    {
                        ViewBag.drop = DepartmanList(); //Kayıt olmayınca hatayı önlemek için                           
                        ViewBag.es = "Evli personelin eş bilgileri girilmelidir..";
                        return View("Getir");
                    }
                    else if (personel.AktifPasif == false && personel.CikisTarihi == null)
                    {
                        ViewBag.drop = DepartmanList(); //Kayıt olmayınca hatayı önlemek için                           
                        ViewBag.cikis = "Durumu pasif olan personelin işten çıkış tarihi girilmelidir.";
                        return View("Getir");
                    }
                    else
                    {

                        if (personel.İseGirisTarihi < personel.CikisTarihi)
                        {
                            ViewBag.drop = DepartmanList(); //Kayıt olmayınca hatayı önlemek için                           
                            ViewBag.giristarih = "İşe giriş tarih çıkış tarihinden sonra olamaz.";
                            ViewBag.cikistarih = "İşten çıkış tarihi işe giriş tarihinden sonra olmalıdır.";
                            return View("Getir");
                        }
                        else if (personel.DogumTarihi > personel.İseGirisTarihi)
                        {
                            ViewBag.drop = DepartmanList(); //Kayıt olmayınca hatayı önlemek için                           
                            ViewBag.dogumtarih = "Doğum tarihi ise giriş tarihinden önce olmamaz.";
                            return View("Getir");
                        }
                        else if (personel.İseGirisTarihi > DateTime.Today)
                        {
                            ViewBag.drop = DepartmanList(); //Kayıt olmayınca hatayı önlemek için                           
                            ViewBag.giris1tarih = "İşe giriş tarihi ileri bir tarih olamaz.";
                            return View("Getir");
                        }
                        else
                        {
                        guncel.Id = personel.Id;
                        guncel.TcKimlik = personel.TcKimlik;
                        guncel.Ad = personel.Ad;
                        guncel.Soyad = personel.Soyad;
                        guncel.Cinsiyet = personel.Cinsiyet;
                        guncel.Unvan = personel.Unvan;
                        guncel.KurumSicilNo = personel.KurumSicilNo;
                        guncel.CepTelefonu = personel.CepTelefonu;
                        guncel.Eposta = personel.Eposta;
                        guncel.MedeniDurum = personel.MedeniDurum;
                        guncel.EvAdresi = personel.EvAdresi;
                        guncel.Askerlik = personel.Askerlik;
                        guncel.Ehliyet = personel.Ehliyet;
                        guncel.EngellilikDurumu = personel.EngellilikDurumu;
                        guncel.DepartmanId = personel.Departmanlar.Id;
                        guncel.DogumTarihi = personel.DogumTarihi;
                        guncel.İseGirisTarihi = personel.İseGirisTarihi;
                        guncel.AktifPasif = personel.AktifPasif;
                        guncel.CikisTarihi = personel.CikisTarihi;
                        guncel.EsiTc = personel.EsiTc;
                        guncel.EsiAdiSoyadi = personel.EsiAdiSoyadi;
                        guncel.EsiTelefon = personel.EsiTelefon;
                        guncel.EsiIsDurumu = personel.EsiIsDurumu;


                        db.SaveChanges();
                        return RedirectToAction("Listele");
                    }
                    }

            }
            catch (Exception ex)
            {
                ViewBag.drop = DepartmanList(); //Kayıt olmayınca hatayı önlemek için

                TempData["Warning"] = "Hata !!" + ex.Message;
                return View("Getir");
            }            
        }

        public List<SelectListItem> DepartmanList()
        {
            List<SelectListItem> departman = (from x in db.Departmanlar.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.DepartmanAdi,
                                                  Value = x.Id.ToString()
                                              }).ToList();
            return departman; 
        }

        
    }
}