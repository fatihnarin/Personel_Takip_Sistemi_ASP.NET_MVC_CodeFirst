namespace PDKS_Code_First.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonelEgitim")]
    public partial class PersonelEgitim
    {
        public int Id { get; set; }

        public int PersonelId { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan!!!")]
        public EgitimDurum EgitimDurumu { get; set; }

       
        public string SonMezunOlduguUkulAdý { get; set; }

        public virtual PersonelOzlukBilgileri PersonelOzlukBilgileri { get; set; }
        public enum EgitimDurum:byte
        {           
            Okuma_Yazma_Bilmiyor =0,
            Okur_Yazar=1,
            Ýlkokul=2,
            Ortaokul=3,
            Ilkogretim=4,
            Lise=5,
            Onlisans=6,
            Lisans=7,
            Yuksek_Lisans=8,
            Doktora=9
        }
    }
}
