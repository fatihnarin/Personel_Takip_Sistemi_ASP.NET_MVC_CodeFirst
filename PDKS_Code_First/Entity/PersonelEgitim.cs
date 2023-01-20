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

        [Required]
        public string EgitimBilgisi { get; set; }

        public virtual PersonelOzlukBilgileri PersonelOzlukBilgileri { get; set; }
    }
}
