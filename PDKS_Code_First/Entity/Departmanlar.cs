namespace PDKS_Code_First.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Departmanlar")]
    public partial class Departmanlar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Departmanlar()
        {
            PersonelKiyafet = new HashSet<PersonelKiyafet>();
            PersonelOzlukBilgileri = new HashSet<PersonelOzlukBilgileri>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [Required]
        [StringLength(30)]
        [MinLength(2, ErrorMessage = "Departman alaný en az 2 Karakter olmalýdýr !")]
        [MaxLength(30, ErrorMessage = "Departman alaný en fazla 25 Karakter olmalýdýr !")]
        public string DepartmanAdi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonelKiyafet> PersonelKiyafet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonelOzlukBilgileri> PersonelOzlukBilgileri { get; set; }
    }
}
