namespace PDKS_Code_First.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonelSaglikDurumlari")]
    public partial class PersonelSaglikDurumlari
    {
        public int Id { get; set; }

        public int PersonelId { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan!!")]
        public bool Alerji { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan!!")]
        public bool KalpHastaligi { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan!!")]
        public bool KasEklem { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan!!")]
        public bool GormeKusuru { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan!!")]
        public bool IsitmeKaybi { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan!!")]
        public bool BagisiklikGuclugu { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan!!")]
        public bool KronikHastalik { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan!!")]
        public bool AstimKoah { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan!!")]
        public bool SindirimRahatsizliklari { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan!!")]
        public string Aciklama { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan!!")]
        public bool RuhsalHastalik { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan!!")]
        public bool ZihinselHastalik { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan!!")]
        public Kan KanGrubu { get; set; }

        public virtual PersonelOzlukBilgileri PersonelOzlukBilgileri { get; set; }

        public enum Kan:byte
        {
            A_RH_Pozitif=0,
            A_RH_Negatih=1,
            B_RH_Pozitif = 2,
            B_RH_Negatih = 3,
            O_RH_Pozitif = 4,
            O_RH_Negatih = 5,
            AB_RH_Pozitif = 6,
            AB_RH_Negatih = 7




        }
    }
}
