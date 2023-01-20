using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PDKS_Code_First.Entity;



namespace PDKS_Code_First.Classes
{
    public class Class1
    {
        public class LoginKayit
        {
            public string tcno { get; set; }
            public string sicilno { get; set; }
            public string ad { get; set; }
            public string soyad { get; set; }
            public string eposta { get; set; }
            public string kullaniciadi { get; set; }
            public string parola { get; set; }
        }
        public class IzinTakipView
        {
            public int izintakipid { get; set; }
            public int PersonelId { get; set; }
            public string Tc { get; set; }
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public string Departmanad { get; set; }          
            public DateTime talep { get; set; }
            public DateTime bas { get; set; }
            public DateTime son { get; set; }
            public int gun { get; set; }
            public IzinTakip.izintip tip { get; set; }
        }
        public class PersonelKiyafetView
        {
            public int kiyafetid { get; set; }
            public int PersonelId { get; set; }
            public string Tc { get; set; }
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public string Departmanad { get; set; }
            public byte DepartmanId { get; set; }
            public string Isteknedeni { get; set; }
            public PersonelKiyafet.Renkler Renk { get; set; }
            public PersonelKiyafet.kiymodel Model { get; set; }
            public PersonelKiyafet.AltBeden AltBeden { get; set; }
            public PersonelKiyafet.KafaBeden KafaBeden { get; set; }
            public PersonelKiyafet.UstBeden UstBeden { get; set; }
            public byte Ayakkapi { get; set; }
            public byte Kilo { get; set; }
            public byte Boy { get; set; }
        }

    }
}