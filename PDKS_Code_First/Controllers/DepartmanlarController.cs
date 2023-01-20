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
    public class DepartmanlarController : Controller
    {
        // GET: Departmanlar
        PDKSCodeFirstContext db = new PDKSCodeFirstContext();
        
        [Authorize]
        public ActionResult Listele(int sayfa=1)
        {
            var departmanlarliste = db.Departmanlar.ToList().ToPagedList(sayfa, 3);
            return View(departmanlarliste);
        }
        [Authorize]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Departmanlar departmanlar)
        {
            try
            {
                var durum = db.Departmanlar.FirstOrDefault(x => x.DepartmanAdi == departmanlar.DepartmanAdi);
                if (durum==null)
                {
                    db.Departmanlar.Add(departmanlar);
                    db.SaveChanges();
                    return RedirectToAction("Listele");
                }
                else
                {
                    TempData["Warning"] = "Aynı departman kayıtlıdır. Tekrar kayıt yapılamaz";
                    return View("Ekle");
                }
            }
            catch (Exception ex)
            {

                TempData["Warning"] = "Hata !!" + ex.Message;
                return View("Ekle");
            }           
        }
        [Authorize]
        public ActionResult Sil(int id)
        {
            try
            {
                var durum1 = db.PersonelKiyafet.FirstOrDefault(x => x.DepartmanId == id);
                var durum2 = db.PersonelOzlukBilgileri.FirstOrDefault(x => x.DepartmanId == id);
                if (durum1 == null && durum2 == null )
                {
                    var departman = db.Departmanlar.FirstOrDefault(x => x.Id == id);
                    db.Departmanlar.Remove(departman);
                    db.SaveChanges();
                    return RedirectToAction("Listele");
                }
                else
                {
                    
                    TempData["Warning"] = "Departmana kayıtlı personel vardır. Silinemez!!";
                    return RedirectToAction("Listele");
                }
            }
            catch (Exception ex)
            {

                TempData["Warning"] = "Hata !!" + ex.Message;
                return View("Ekle");
            }
         
            
        }
        [Authorize]
        public ActionResult Getir(int id)
        {
           
            var departman = db.Departmanlar.Find(id);
            return View("Getir", departman);
        }

        [Authorize]
        public ActionResult Guncelle(Departmanlar departman)
        {
            try
            {
                var durum = db.Departmanlar.FirstOrDefault(x => x.DepartmanAdi == departman.DepartmanAdi);
                var guncel = db.Departmanlar.Find(departman.Id);

                if (durum!=null)
                {
                    if (durum.Id != guncel.Id)
                    {
                        TempData["Warning"] = "Aynı isimde kayıtlı departman var.Bu isimle güncelleme yapılamaz";
                        return View("Getir");
                    }
                    else
                    {
                        guncel.Id = departman.Id;
                        guncel.DepartmanAdi = departman.DepartmanAdi;
                        db.SaveChanges();
                        return RedirectToAction("Listele");

                    }
                }
                else
                {
                    guncel.Id = departman.Id;
                    guncel.DepartmanAdi = departman.DepartmanAdi;
                    db.SaveChanges();
                    return RedirectToAction("Listele");
                }       
                
                
            }
            catch (Exception ex)
            {
                
                TempData["Warning"] = "Hata !!" + ex.Message;
                return View("Getir");
            }

        }
    }
}