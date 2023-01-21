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

        [Required(ErrorMessage = "TC Kimlik numaras� bo� b�rak�lamaz")]
        [MaxLength(11, ErrorMessage = "TC kimlik numaras� 11 haneli olmal�d�r!")]
        [MinLength(11, ErrorMessage = "TC kimlik numaras� 11 haneli olmal�d�r!")]
        [RegularExpression(@"[0-9]+$", ErrorMessage = "L�tfen Sadece Say� De�erlerini Giriniz")]
        public string CocukTc { get; set; }
        
        [Required(ErrorMessage = "�ocuk Ad-Soyad bo� b�rak�lamaz")]
        [MaxLength(50, ErrorMessage = "Ad Soyad en fazla 50 karakterden olu�ur!")]
        [MinLength(5, ErrorMessage = "Ad Soyad en az 5 karakterden olu�ur!")]
        [RegularExpression(("[a-zA-Z �������O���� ]*"), ErrorMessage = "Sadece harf kullan�n�z!")]
        public string CocukAdiSoyadi { get; set; }

        [Required(ErrorMessage = "Do�um tarihi bo� b�rak�lamaz")]
        [Column(TypeName = "smalldatetime")]
        public DateTime CocukDogumTarihi { get; set; }

        [Required(ErrorMessage = "Cinsiyet alan� bo� b�rak�lamaz")]
        public bool CocukCinsiyet { get; set; }

        public virtual PersonelOzlukBilgileri PersonelOzlukBilgileri { get; set; }
       

    }
}
