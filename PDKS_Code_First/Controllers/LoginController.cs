using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PDKS_Code_First.Entity;
using System.Net.Mail;
namespace PDKS_Code_First.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        PDKSCodeFirstContext db = new PDKSCodeFirstContext();
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(Kullanicilar t)
        {
            var bilgiler = db.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi==t.KullaniciAdi && x.Parola == t.Parola);

            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAdi, false);
                return RedirectToAction("Index", "AnaSayfa");
            }
            else
            {
                return View();
            }

        }
        [HttpGet]
        public ActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(Classes.Class1.LoginKayit p)
        {
            try
            {
                Kullanicilar k = new Kullanicilar();
                var kontrol = db.SistemeKayitOlabilecekler.FirstOrDefault(x => x.TcNo == p.tcno && x.SicilNo == p.sicilno
                  && x.Ad == p.ad && x.SoyAd == p.soyad);
                var kontrol2 = db.Kullanicilar.FirstOrDefault(x => x.TcNo == p.tcno && x.SicilNo == p.sicilno);
                if (kontrol != null)
                {
                    if (kontrol2 == null)
                    {
                        k.Ad = p.ad;
                        k.Soyad = p.soyad;
                        k.TcNo = p.tcno;
                        k.SicilNo = p.sicilno;
                        k.EPosta = p.eposta;
                        k.KullaniciAdi = p.kullaniciadi;
                        k.Parola = p.parola;
                        db.Kullanicilar.Add(k);
                        db.SaveChanges();
                        return RedirectToAction("Giris");
                    }
                    else
                    {
                        TempData["Warning"] = "Aynı bilgile ait kullanızı zaten var";
                        return View();
                    }


                }
                else
                {
                    TempData["Warning"] = "Girdiğiniz bilgilerde İnsan Kaynakları Personelimiz bulunmamaktadır." +
                        "Personelimiz olmayan sisteme KAYIT OLAMAZ!!!";
                    return View();
                }
            }
            catch (Exception)
            {

                return View();
            }


        }
        [HttpGet]
        public ActionResult SifremiUnuttum()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SifremiUnuttum(Kullanicilar p)
        {
            var kontrol = db.Kullanicilar.FirstOrDefault(x => x.TcNo == p.TcNo &&
              x.KullaniciAdi == p.KullaniciAdi && x.EPosta == p.EPosta);
            if (kontrol != null)
            {

                MailMessage mesaj = new MailMessage();

                mesaj.To.Add("fatihnarinn@hotmail.com");
                mesaj.From = new MailAddress("fatihnarinn@hotmail.com");
                mesaj.Subject = "PDKS Şifre Tabebi";
                mesaj.Body = "Merhaba sifre talebinde bulundunuz <br/> Şifreniz : " + kontrol.Parola.ToString() + " <br/>Şifrenizi kimseyle paylaşmayınız. İyi Günler :)";
                mesaj.IsBodyHtml = true;//html kodları

                SmtpClient a = new SmtpClient();
                a.Credentials = new System.Net.NetworkCredential("fatihnarinn@hotmail.com", "***************");
                a.Port = 587;
                a.Host = "smtp.office365.com"; //"outlook.office365.com"; //
                a.EnableSsl = true;

                try
                {
                    a.Send(mesaj);
                    TempData["Warning"] = "Kullanıcı Bilgileriniz e posta adresinize gönderildi. Lütfen e posta adresinizi kontrol ediniz";

                }
                catch (SmtpException ex)
                {

                    TempData["Warning"] = "Hata !!" + ex.Message;
                }

            }
            else
            {
                TempData["Warning"] = "Girmiş olduğunuz bilgilerde kullanıcı bulunamadı !!";
            }
            return View();
        }
        public ActionResult Cikis()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Giris", "Login");
        }
    }
}