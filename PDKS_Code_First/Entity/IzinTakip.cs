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
       
        [Required(ErrorMessage = "İzin talep tarihi boş bırakılamaz")]
        [Column(TypeName = "smalldatetime")]
        public DateTime IzinTalepTarihi { get; set; }

        [Required(ErrorMessage = "İzin başlangıç tarihi boş bırakılamaz")]
        [Column(TypeName = "smalldatetime")]
        public DateTime IzinBaslangicTarihi { get; set; }

        [Required(ErrorMessage = "İzin bitiş tarihi boş bırakılamaz")]
        [Column(TypeName = "smalldatetime")]
        public DateTime İzinBitisTarihi { get; set; }

        [Required(ErrorMessage = "İzingun sayısı boş bırakılamaz")]
        public byte IzinliGunSayisi { get; set; }

        [Required(ErrorMessage = "İzin tipi boş bırakılamaz")]
        public izintip IzinTipi { get; set; }

        public virtual PersonelOzlukBilgileri PersonelOzlukBilgileri { get; set; }

        public enum izintip:byte
        {
            Yıllık_İzin=0,
            Analık_İzni=1,
            Babalık_İzni=2,
            Evlilik_İzni=3,
            Ölüm_İzni=4,
            Ücretli_İzin=5,
            Mazeret_İzni=6

        }
    }
}
