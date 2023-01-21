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
        [MinLength(2, ErrorMessage = "�sim alan� en az 2 Karakter olmal�d�r !")]
        [MaxLength(25, ErrorMessage = "�sim alan� en fazla 25 Karakter olmal�d�r !")]
        [RegularExpression(("[a-zA-Z �������O���� ]*"), ErrorMessage = "Sadece harf kullan�n�z!")]

        public string Ad { get; set; }

        [Required]
        [StringLength(25)]
        [MinLength(2, ErrorMessage = "Soyisim alan� en az 2 Karakter olmal�d�r !")]
        [MaxLength(25, ErrorMessage = "Soyisim alan� en fazla 25 Karakter olmal�d�r !")]
        [RegularExpression(("[a-zA-Z �������O���� ]*"), ErrorMessage = "Sadece harf kullan�n�z!")]
        public string Soyad { get; set; }

        [Required]
        [MaxLength(11, ErrorMessage = "TC kimlik numaras� 11 haneli olmal�d�r!")]
        [MinLength(11, ErrorMessage = "TC kimlik numaras� 11 haneli olmal�d�r!")]
        [RegularExpression(@"[0-9]+$", ErrorMessage = "L�tfen Sadece Say� De�erlerini Giriniz")]
        public string TcNo { get; set; }

        [MinLength(7, ErrorMessage = "Kurum Sicil No 7 karakter olmal�d�r!")]
        [MaxLength(7, ErrorMessage = "Kurum Sicil No 7 karakter olmal�d�r!")]
        [RegularExpression(@"[0-9]+$", ErrorMessage = "L�tfen Sadece Say� De�erlerini Giriniz")]
        public string SicilNo { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Ge�erli Bir E-Posta Adresi Giriniz")]
        [MaxLength(50, ErrorMessage = "En fazla 50 karakterli bir e posta giriniz!")]
        public string EPosta { get; set; }

         [Required]
        [StringLength(20)]
        [MinLength(1, ErrorMessage = "Kullan�c� ad� alan� en az 2 Karakter olmal�d�r !")]
        [MaxLength(20, ErrorMessage = "Kullan�c� alan� en fazla 25 Karakter olmal�d�r !")]

        public string KullaniciAdi { get; set; }

      
        [Required]
        [StringLength(20)]
        [MinLength(1, ErrorMessage = "Parola alan� en az 2 Karakter olmal�d�r !")]
        [MaxLength(20, ErrorMessage = "Parola alan� en fazla 25 Karakter olmal�d�r !")]
        public string Parola { get; set; }
    }
}
