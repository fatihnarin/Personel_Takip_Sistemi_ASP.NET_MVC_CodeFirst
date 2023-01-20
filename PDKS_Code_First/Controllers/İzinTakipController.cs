using PDKS_Code_First.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static PDKS_Code_First.Classes.Class1;

namespace PDKS_Code_First.Controllers
{
    public class İzinTakipController : Controller
    {
        // GET: İzinTakip
        PDKSCodeFirstContext db = new PDKSCodeFirstContext();
        public ActionResult Listele(string tc, string ad, string soyad)
        {
            var personelizin = from x in db.IzinTakip select x;
            if (!string.IsNullOrEmpty(tc) || !string.IsNullOrEmpty(ad) || !string.IsNullOrEmpty(soyad))
            {
                personelizin = personelizin.Where(x => x.PersonelOzlukBilgileri.TcKimlik.Contains(tc) && x.PersonelOzlukBilgileri.Ad.Contains(ad) && x.PersonelOzlukBilgileri.Soyad.Contains(soyad));
            }

            return View(personelizin.ToList());
        }
        public ActionResult EkleListe(string tc, string ad, string soyad)
        {
            var personelizin = from x in db.PersonelOzlukBilgileri select x;
            if (!string.IsNullOrEmpty(tc) || !string.IsNullOrEmpty(ad) || !string.IsNullOrEmpty(soyad))
            {
                personelizin = personelizin.Where(x => x.TcKimlik.Contains(tc) && x.Ad.Contains(ad) && x.Soyad.Contains(soyad));
            }

            return View(personelizin.ToList());
        }
        public ActionResult GetirEkle(int id)
        {
           
            IzinTakipView ızinTakipView = new IzinTakipView();
            
            return View("GetirEkle", GetirekleMetot(ızinTakipView, id));

        }

        private IzinTakipView GetirekleMetot(IzinTakipView ızinTakipView, int id)
        {
            var personel = db.PersonelOzlukBilgileri.Find(id);

            ızinTakipView.PersonelId = personel.Id;
            ızinTakipView.Tc = personel.TcKimlik;
            ızinTakipView.Ad = personel.Ad;
            ızinTakipView.Soyad = personel.Soyad;
            ızinTakipView.Departmanad = personel.Departmanlar.DepartmanAdi;
            return ızinTakipView;
        }

        public ActionResult Ekle(IzinTakipView ızinTakipView )
        {
            try
            {
                IzinTakip ızinTakip = new IzinTakip();
                
                if (ızinTakipView.talep!=null && ızinTakipView.bas!=null&& ızinTakipView.son!=null)
                {
                    if (ızinTakipView.talep > ızinTakipView.bas)
                    {
                        ViewBag.talep = "Talep izin başlangıçından sonra olamaz";
                        return View("GetirEkle", GetirekleMetot(ızinTakipView, ızinTakipView.PersonelId));
                      
                    }
                    else if (ızinTakipView.bas >= ızinTakipView.son)
                    {
                        ViewBag.bas = "İzin başlangıcı bitiş tarihine eşit veya sonra olamaz";
                        ViewBag.son = "İzin bitişi başlangıç tarihine eşit veya sonra olamaz";
                        return View("GetirEkle", GetirekleMetot(ızinTakipView, ızinTakipView.PersonelId));
                    }
                    else if (ızinTakipView.tip == 0)
                    {
                        ViewBag.tip = "İzin tip boş olomaz";
                        return View("GetirEkle", GetirekleMetot(ızinTakipView, ızinTakipView.PersonelId));
                    }
                    else
                    {
                        TimeSpan fark = Convert.ToDateTime(ızinTakipView.son) - Convert.ToDateTime(ızinTakipView.bas);
                        ızinTakip.IzinliGunSayisi = Convert.ToByte(fark.TotalDays);
                        ızinTakip.PersonelId = ızinTakipView.PersonelId;
                        ızinTakip.IzinTalepTarihi = ızinTakipView.talep;
                        ızinTakip.IzinBaslangicTarihi = ızinTakipView.bas;
                        ızinTakip.İzinBitisTarihi = ızinTakipView.son;
                        ızinTakip.IzinTipi = ızinTakipView.tip;
                        db.IzinTakip.Add(ızinTakip);
                        db.SaveChanges();
                        return RedirectToAction("Listele");
                    }
                }
                else
                {
                    ViewBag.tarih = "tarih alanları boş olomaz";
                    return View("GetirEkle", GetirekleMetot(ızinTakipView, ızinTakipView.PersonelId));
                }

               
            }
            catch (Exception ex)
            {
                TempData["Warning"] = "Hata !!" + ex.Message;
                return View("GetirEkle", GetirekleMetot(ızinTakipView, ızinTakipView.PersonelId));
            }
           
            

        }
        public ActionResult Sil(int id)
        {
            try
            {
                var izinsil = db.IzinTakip.FirstOrDefault(x => x.Id == id);
                db.IzinTakip.Remove(izinsil);
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

            IzinTakipView ızinTakipView = new IzinTakipView();
            return View("GetirGuncelle", GetirGuncelleMetot(ızinTakipView, id));
        }
        private IzinTakipView GetirGuncelleMetot(IzinTakipView ızinTakipView, int id)
        {

            var izin = db.IzinTakip.Find(id);
            var personel = db.PersonelOzlukBilgileri.Find(izin.PersonelId);

            ızinTakipView.izintakipid = id;
            ızinTakipView.PersonelId = personel.Id;
            ızinTakipView.Tc = personel.TcKimlik;
            ızinTakipView.Ad = personel.Ad;
            ızinTakipView.Soyad = personel.Soyad;
            ızinTakipView.Departmanad = personel.Departmanlar.DepartmanAdi;
            ızinTakipView.talep = izin.IzinTalepTarihi;
            ızinTakipView.bas = izin.IzinBaslangicTarihi;
            ızinTakipView.son = izin.İzinBitisTarihi;
            ızinTakipView.gun = izin.IzinliGunSayisi;
            ızinTakipView.tip = izin.IzinTipi;
            return ızinTakipView;
        }
        public ActionResult Guncelle(IzinTakipView ızinTakipView)
        {
            try
            {
               

                if (ızinTakipView.talep != null && ızinTakipView.bas != null && ızinTakipView.son != null)
                {
                    if (ızinTakipView.talep > ızinTakipView.bas)
                    {
                        ViewBag.talep = "Talep izin başlangıçından sonra olamaz";
                        return View("GetirGuncelle", GetirGuncelleMetot(ızinTakipView, ızinTakipView.PersonelId));

                    }
                    else if (ızinTakipView.bas >= ızinTakipView.son)
                    {
                        ViewBag.bas = "İzin başlangıcı bitiş tarihine eşit veya sonra olamaz";
                        ViewBag.son = "İzin bitişi başlangıç tarihine eşit veya sonra olamaz";
                        return View("GetirGuncelle", GetirGuncelleMetot(ızinTakipView, ızinTakipView.PersonelId));
                    }
                    else if (ızinTakipView.tip == 0)
                    {
                        ViewBag.tip = "İzin tip boş olomaz";
                        return View("GetirGuncelle", GetirGuncelleMetot(ızinTakipView, ızinTakipView.PersonelId));
                    }
                    else
                    {
                        var ızinTakip = db.IzinTakip.FirstOrDefault(x => x.Id == ızinTakipView.izintakipid);
                        TimeSpan fark = Convert.ToDateTime(ızinTakipView.son) - Convert.ToDateTime(ızinTakipView.bas);
                        ızinTakip.IzinliGunSayisi = Convert.ToByte(fark.TotalDays);
                        ızinTakip.PersonelId = ızinTakipView.PersonelId;
                        ızinTakip.IzinTalepTarihi = ızinTakipView.talep;
                        ızinTakip.IzinBaslangicTarihi = ızinTakipView.bas;
                        ızinTakip.İzinBitisTarihi = ızinTakipView.son;
                        ızinTakip.IzinTipi = ızinTakipView.tip;
                        db.IzinTakip.Add(ızinTakip);
                        db.SaveChanges();
                        return RedirectToAction("Listele");
                    }
                }
                else
                {
                    ViewBag.tarih = "tarih alanları boş olomaz";
                    return View("GetirGuncelle", GetirGuncelleMetot(ızinTakipView, ızinTakipView.PersonelId));
                }


            }
            catch (Exception ex)
            {
                TempData["Warning"] = "Hata !!" + ex.Message;
                return View("GetirGuncelle", GetirGuncelleMetot(ızinTakipView, ızinTakipView.PersonelId));
            }



        }


    }
}