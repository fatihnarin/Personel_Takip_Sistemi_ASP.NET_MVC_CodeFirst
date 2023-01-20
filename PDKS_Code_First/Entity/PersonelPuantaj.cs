namespace PDKS_Code_First.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonelPuantaj")]
    public partial class PersonelPuantaj
    {
        public int Id { get; set; }

        public int PersonelId { get; set; }

        [Column(TypeName = "date")]
        public DateTime GirisZamani { get; set; }

        [Column(TypeName = "date")]
        public DateTime CikisZamani { get; set; }

        [Required]
        public string Mazeret { get; set; }

        public virtual PersonelOzlukBilgileri PersonelOzlukBilgileri { get; set; }
    }
}
