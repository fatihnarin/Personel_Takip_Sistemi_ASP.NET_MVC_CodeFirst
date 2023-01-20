
namespace PDKS_Code_First.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonelBelgeler")]
    public partial class PersonelBelgeler
    {
        public int Id { get; set; }

        public int PersonelId { get; set; }

        [Required]
        [StringLength(30)]
        public string BelgeAdi { get; set; }

        [Required]
        public string DosyaYolu { get; set; }

        public int BelgeTipi { get; set; }

        public virtual PersonelOzlukBilgileri PersonelOzlukBilgileri { get; set; }
        public enum belgetipi : byte
        {
            Vesikalık = 1,
            İkahmetgah = 2,
            AdliSicil = 3,
            Diploma = 4,
            Kimlik_Fotokopisi = 5
        }
    }
}

