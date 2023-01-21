namespace PDKS_Code_First.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonelKiyafet")]
    public partial class PersonelKiyafet
    {
        public int Id { get; set; }

        public int PersonelId { get; set; }

        public byte DepartmanId { get; set; }

       
        [StringLength(20)]
        [MaxLength(20, ErrorMessage = "En fazla 20 karakterden oluþur!")]
        [Required(ErrorMessage = "Ýstek nedeni boþ býrakýlamaz")]
        public string IstekNedeni { get; set; }

        public Renkler Renk { get; set; }

        public kiymodel Model { get; set; }

        public UstBeden UstBedenNo { get; set; }

        public AltBeden AltBedenNo { get; set; }

        public KafaBeden KafaBedenNo { get; set; }

        public byte AyakkabiNo { get; set; }

        public byte Boy { get; set; }

        public byte Kilo { get; set; }

        public virtual Departmanlar Departmanlar { get; set; }

        public virtual PersonelOzlukBilgileri PersonelOzlukBilgileri { get; set; }
        public enum Renkler :byte
        {
            Bordo=1,
            Mavi=2,
            Yeþi=3,
            Siyah=4
        }
        public enum AltBeden:byte
        {
            S=1,
            M=2,
            L=3,
            XL=4,
            XXL=5
        }
        public enum UstBeden : byte
        {
            S = 1,
            M = 2,
            L = 3,
            XL = 4,
            XXL = 5
        }
        public enum KafaBeden : byte
        {
            S = 1,
            M = 2,
            L = 3,
            XL = 4,
            XXL = 5
        }
        public enum kiymodel:byte
        {
            DarKesim=1,
            NormalKesim=2,
            BolKesim=3
        }

    }
}
