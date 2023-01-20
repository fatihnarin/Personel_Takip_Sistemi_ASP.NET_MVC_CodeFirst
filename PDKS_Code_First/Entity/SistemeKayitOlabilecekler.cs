namespace PDKS_Code_First.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SistemeKayitOlabilecekler")]
    public partial class SistemeKayitOlabilecekler
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [Required]
        [StringLength(11)]
        public string TcNo { get; set; }

        [Required]
        [StringLength(7)]
        public string SicilNo { get; set; }

        [Required]
        [StringLength(25)]
        public string Ad { get; set; }

        [Required]
        [StringLength(25)]
        public string SoyAd { get; set; }
    }
}
