namespace PDKS_Code_First.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonelCocuk")]
    public partial class PersonelCocuk
    {
        public int Id { get; set; }

        public int PersonelId { get; set; }

        [Required]
        [StringLength(50)]
        public string CocukAdiSoyadi { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime CocukDogumTarihi { get; set; }

        public bool CocukCinsiyet { get; set; }

        public virtual PersonelOzlukBilgileri PersonelOzlukBilgileri { get; set; }
    }
}
