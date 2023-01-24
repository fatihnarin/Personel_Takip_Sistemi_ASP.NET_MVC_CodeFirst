using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using PDKS_Code_First.Entity;



namespace PDKS_Code_First.Classes
{
    public class Class1
    {
        public class LoginKayit
        {
            [Required(ErrorMessage = "Zorunlu Alan!!!")]
            public string tcno { get; set; }
            [Required(ErrorMessage = "Zorunlu Alan!!!")]
            public string sicilno { get; set; }
            [Required(ErrorMessage = "Zorunlu Alan!!!")]
            public string ad { get; set; }
            [Required(ErrorMessage = "Zorunlu Alan!!!")]
            public string soyad { get; set; }
            [Required(ErrorMessage = "Zorunlu Alan!!!")]
            public string eposta { get; set; }
            [Required(ErrorMessage = "Zorunlu Alan!!!")]
            public string kullaniciadi { get; set; }
            [Required(ErrorMessage = "Zorunlu Alan!!!")]
            public string parola { get; set; }

        }
        public class Personel
        {          
            public int PersonelId { get; set; }
            public string Tc { get; set; }
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public string Departmanad { get; set; }
        }
        public class IzinTakipView:Personel
        {
            public int izintakipid { get; set; }

            [Required(ErrorMessage = "Talep tarihi boş bırakılamaz")]
            public DateTime talep { get; set; }
           
            [Required(ErrorMessage = "İzin başlama tarihi boş bırakılamaz")]
            public DateTime bas { get; set; }
            
            [Required(ErrorMessage = "İzin bitiş tarihi boş bırakılamaz")]
            public DateTime son { get; set; }
            
            public int gun { get; set; }
            [Required(ErrorMessage = "İzin tipi boş bırakılamaz")]
            public IzinTakip.izintip tip { get; set; }
        }
        public class PersonelKiyafetView:Personel
        {
            public int kiyafetid { get; set; }
 
            public byte DepartmanId { get; set; }
            [Required(ErrorMessage = "İstek nedeni boş bırakılamaz")]
            public string Isteknedeni { get; set; }
            public PersonelKiyafet.Renkler Renk { get; set; }
           
            [Required(ErrorMessage = "Zorunlu Alan!!")]
            public PersonelKiyafet.kiymodel Model { get; set; }
            public PersonelKiyafet.AltBeden AltBeden { get; set; }
            public PersonelKiyafet.KafaBeden KafaBeden { get; set; }
            public PersonelKiyafet.UstBeden UstBeden { get; set; }
            public byte Ayakkapi { get; set; }
            public byte Kilo { get; set; }
            public byte Boy { get; set; }
        }
        public class PersonelCocukView:Personel
        {
            public int Cocukid { get; set; }


            [Required(ErrorMessage = "TC Kimlik numarası boş bırakılamaz")]
            [MaxLength(11, ErrorMessage = "TC kimlik numarası 11 haneli olmalıdır!")]
            [MinLength(11, ErrorMessage = "TC kimlik numarası 11 haneli olmalıdır!")]
            [RegularExpression(@"[0-9]+$", ErrorMessage = "Lütfen Sadece Sayı Değerlerini Giriniz")]
            public string CocukTc { get; set; }

            [Required(ErrorMessage = "Çocuk Ad-Soyad boş bırakılamaz")]
            [MaxLength(50, ErrorMessage = "Ad Soyad en fazla 50 karakterden oluşur!")]
            [MinLength(5, ErrorMessage = "Ad Soyad en az 5 karakterden oluşur!")]
            [RegularExpression(("[a-zA-Z çÇğĞıİöOşŞüÜ ]*"), ErrorMessage = "Sadece harf kullanınız!")]
            public string CocukAdiSoyadi { get; set; }

            [Required(ErrorMessage = "Doğum tarihi boş bırakılamaz")]

            [Column(TypeName = "smalldatetime")]
            public DateTime CocukDogumTarihi { get; set; }

            [Required(ErrorMessage = "Cinsiyet alanı boş bırakılamaz")]
            public bool CocukCinsiyet { get; set; }
        }
        public class PersonelEgitimView:Personel
        {
            public int PersonelEgitimid { get; set; }

            public string SonMezunOlduguUkulAdı { get; set; }

            [Required(ErrorMessage = "Eğitim durumu boş bırakıramaz!!")]

            public PersonelEgitim.EgitimDurum EgitimDurumu { get; set; }
        }

        public class PersonelSaglikView:Personel
        {
            public int PersonelSaglikid { get; set; }

            [Required(ErrorMessage = "Zorunlu Alan!!")]
            public bool Alerji { get; set; }

            [Required(ErrorMessage = "Zorunlu Alan!!")]
            public bool KalpHastaligi { get; set; }

            [Required(ErrorMessage = "Zorunlu Alan!!")]
            public bool KasEklem { get; set; }

            [Required(ErrorMessage = "Zorunlu Alan!!")]
            public bool GormeKusuru { get; set; }

            [Required(ErrorMessage = "Zorunlu Alan!!")]
            public bool IsitmeKaybi { get; set; }

            [Required(ErrorMessage = "Zorunlu Alan!!")]
            public bool BagisiklikGuclugu { get; set; }

            [Required(ErrorMessage = "Zorunlu Alan!!")]
            public bool KronikHastalik { get; set; }

            [Required(ErrorMessage = "Zorunlu Alan!!")]
            public bool AstimKoah { get; set; }

            [Required(ErrorMessage = "Zorunlu Alan!!")]
            public bool SindirimRahatsizliklari { get; set; }

            [Required(ErrorMessage = "Zorunlu Alan!!")]
            public string Aciklama { get; set; }

            [Required(ErrorMessage = "Zorunlu Alan!!")]
            public bool RuhsalHastalik { get; set; }

            [Required(ErrorMessage = "Zorunlu Alan!!")]
            public bool ZihinselHastalik { get; set; }

            [Required(ErrorMessage = "Zorunlu Alan!!")]
            public PersonelSaglikDurumlari.Kan KanGrubu { get; set; }
        }

        public class PersonelBelgelerView:Personel
        {
            public int PersonelBelgeid { get; set; }

            public int Id { get; set; }
            public string BelgeAdi { get; set; }
            public byte[] BelgeYolu { get; set; }
            public PersonelBelgeler.belgetturu BelgeTuru { get; set; }
            public string BelgeTipi { get; set; }

        }
    }
}