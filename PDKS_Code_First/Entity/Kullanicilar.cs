namespace PDKS_Code_First.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanicilar")]
    public partial class Kullanicilar
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Ad { get; set; }

        [Required]
        [StringLength(25)]
        public string Soyad { get; set; }

        [StringLength(11)]
        public string TcNo { get; set; }

        [StringLength(7)]
        public string SicilNo { get; set; }

        [StringLength(50)]
        public string EPosta { get; set; }

        [StringLength(20)]
        public string KullaniciAdi { get; set; }

        [StringLength(20)]
      
        public string Parola { get; set; }
    }
}
