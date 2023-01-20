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

        public bool Alerji { get; set; }

        public bool KalpHastaligi { get; set; }

        public bool KasEklem { get; set; }

        public bool GormeKusuru { get; set; }

        public bool IsitmeKaybi { get; set; }

        public bool BagisiklikGuclugu { get; set; }

        public bool KronikHastalik { get; set; }

        public bool AstimKoah { get; set; }

        public bool SindirimRahatsizliklari { get; set; }

        public string Aciklama { get; set; }

        public bool RuhsalHastalik { get; set; }

        public bool ZihinselHastalik { get; set; }

        public int KanGrubu { get; set; }

        public virtual PersonelOzlukBilgileri PersonelOzlukBilgileri { get; set; }
    }
}
