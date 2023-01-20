namespace PDKS_Code_First.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IzinTakip")]
    public partial class IzinTakip
    {
        public int Id { get; set; }

        public int PersonelId { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime IzinTalepTarihi { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime IzinBaslangicTarihi { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime İzinBitisTarihi { get; set; }

        public byte IzinliGunSayisi { get; set; }

        public izintip IzinTipi { get; set; }

        public virtual PersonelOzlukBilgileri PersonelOzlukBilgileri { get; set; }

        public enum izintip:byte
        {
            Yıllık_İzin=1,
            Analık_İzni=2,
            Babalık_İzni=3,
            Evlilik_İzni=4,
            Ölüm_İzni=5,
            Ücretli_İzin=6,
            Mazeret_İzni=7

        }
    }
}
