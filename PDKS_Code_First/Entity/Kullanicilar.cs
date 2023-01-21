namespace PDKS_Code_First.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanicilar")]
    public partial class Kullanicilar
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [Required]
        [StringLength(25)]
        [MinLength(2, ErrorMessage = "Ýsim alaný en az 2 Karakter olmalýdýr !")]
        [MaxLength(25, ErrorMessage = "Ýsim alaný en fazla 25 Karakter olmalýdýr !")]
        [RegularExpression(("[a-zA-Z çÇðÐýÝöOþÞüÜ ]*"), ErrorMessage = "Sadece harf kullanýnýz!")]

        public string Ad { get; set; }

        [Required]
        [StringLength(25)]
        [MinLength(2, ErrorMessage = "Soyisim alaný en az 2 Karakter olmalýdýr !")]
        [MaxLength(25, ErrorMessage = "Soyisim alaný en fazla 25 Karakter olmalýdýr !")]
        [RegularExpression(("[a-zA-Z çÇðÐýÝöOþÞüÜ ]*"), ErrorMessage = "Sadece harf kullanýnýz!")]
        public string Soyad { get; set; }

        [Required]
        [MaxLength(11, ErrorMessage = "TC kimlik numarasý 11 haneli olmalýdýr!")]
        [MinLength(11, ErrorMessage = "TC kimlik numarasý 11 haneli olmalýdýr!")]
        [RegularExpression(@"[0-9]+$", ErrorMessage = "Lütfen Sadece Sayý Deðerlerini Giriniz")]
        public string TcNo { get; set; }

        [MinLength(7, ErrorMessage = "Kurum Sicil No 7 karakter olmalýdýr!")]
        [MaxLength(7, ErrorMessage = "Kurum Sicil No 7 karakter olmalýdýr!")]
        [RegularExpression(@"[0-9]+$", ErrorMessage = "Lütfen Sadece Sayý Deðerlerini Giriniz")]
        public string SicilNo { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Geçerli Bir E-Posta Adresi Giriniz")]
        [MaxLength(50, ErrorMessage = "En fazla 50 karakterli bir e posta giriniz!")]
        public string EPosta { get; set; }

         [Required]
        [StringLength(20)]
        [MinLength(1, ErrorMessage = "Kullanýcý adý alaný en az 2 Karakter olmalýdýr !")]
        [MaxLength(20, ErrorMessage = "Kullanýcý alaný en fazla 25 Karakter olmalýdýr !")]

        public string KullaniciAdi { get; set; }

      
        [Required]
        [StringLength(20)]
        [MinLength(1, ErrorMessage = "Parola alaný en az 2 Karakter olmalýdýr !")]
        [MaxLength(20, ErrorMessage = "Parola alaný en fazla 25 Karakter olmalýdýr !")]
        public string Parola { get; set; }
    }
}
