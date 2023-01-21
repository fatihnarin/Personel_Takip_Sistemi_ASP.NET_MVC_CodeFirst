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

        [Required(ErrorMessage = "TC Kimlik numarasý boþ býrakýlamaz")]
        [MaxLength(11, ErrorMessage = "TC kimlik numarasý 11 haneli olmalýdýr!")]
        [MinLength(11, ErrorMessage = "TC kimlik numarasý 11 haneli olmalýdýr!")]
        [RegularExpression(@"[0-9]+$", ErrorMessage = "Lütfen Sadece Sayý Deðerlerini Giriniz")]
        public string CocukTc { get; set; }
        
        [Required(ErrorMessage = "Çocuk Ad-Soyad boþ býrakýlamaz")]
        [MaxLength(50, ErrorMessage = "Ad Soyad en fazla 50 karakterden oluþur!")]
        [MinLength(5, ErrorMessage = "Ad Soyad en az 5 karakterden oluþur!")]
        [RegularExpression(("[a-zA-Z çÇðÐýÝöOþÞüÜ ]*"), ErrorMessage = "Sadece harf kullanýnýz!")]
        public string CocukAdiSoyadi { get; set; }

        [Required(ErrorMessage = "Doðum tarihi boþ býrakýlamaz")]
        [Column(TypeName = "smalldatetime")]
        public DateTime CocukDogumTarihi { get; set; }

        [Required(ErrorMessage = "Cinsiyet alaný boþ býrakýlamaz")]
        public bool CocukCinsiyet { get; set; }

        public virtual PersonelOzlukBilgileri PersonelOzlukBilgileri { get; set; }
       

    }
}
