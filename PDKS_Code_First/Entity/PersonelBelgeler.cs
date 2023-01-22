
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
        public string BelgeAdi { get; set; }      
        public byte[] BelgeYolu { get; set; }
        public belgetturu BelgeTuru { get; set; }
        public string BelgeTipi { get; set; }
        public virtual PersonelOzlukBilgileri PersonelOzlukBilgileri { get; set; }
        public enum belgetturu : byte
        {
            Vesikalık = 0,
            İkahmetgah = 1,
            AdliSicil = 2,
            Diploma = 3,
            Kimlik_Fotokopisi = 4
        }
    }
}

