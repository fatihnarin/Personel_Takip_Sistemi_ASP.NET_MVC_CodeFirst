namespace PDKS_Code_First.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonelOzlukBilgileri")]
    public partial class PersonelOzlukBilgileri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PersonelOzlukBilgileri()
        {
            IzinTakip = new HashSet<IzinTakip>();
            PersonelCocuk = new HashSet<PersonelCocuk>();
            PersonelEgitim = new HashSet<PersonelEgitim>();
            PersonelKiyafet = new HashSet<PersonelKiyafet>();
            PersonelPuantaj = new HashSet<PersonelPuantaj>();
            PersonelSaglikDurumlari = new HashSet<PersonelSaglikDurumlari>();
            PersonelBelgeler = new HashSet<PersonelBelgeler>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(11)]
        //[Required(ErrorMessage = "Zorunlu Alan !")]
        [MaxLength(11, ErrorMessage = "TC kimlik numarası 11 haneli olmalıdır!")]
        [MinLength(11, ErrorMessage = "TC kimlik numarası 11 haneli olmalıdır!")]
        //[Display(Name = "Tc Kimlik Numarası")]
        [RegularExpression(@"[0-9]+$", ErrorMessage = "Lütfen Sadece Sayı Değerlerini Giriniz")]
        public string TcKimlik { get; set; }

        [Required]
        [StringLength(25)]
        [MinLength(2, ErrorMessage = "İsim alanı en az 2 Karakter olmalıdır !")]
        [MaxLength(25, ErrorMessage = "İsim alanı en fazla 25 Karakter olmalıdır !")]
        [RegularExpression(("[a-zA-Z çüöğşıİĞÇÜŞ]*"), ErrorMessage = "Sadece harf kullanınız!")]

        public string Ad { get; set; }

        [Required]
        [StringLength(25)]
        [MinLength(2, ErrorMessage = "Soyisim alanı en az 2 Karakter olmalıdır !")]
        [MaxLength(25, ErrorMessage = "Soyisim alanı en fazla 25 Karakter olmalıdır !")]
        [RegularExpression(@"[a-zA-Z çüöğşıİĞÇÜŞ]*", ErrorMessage = "Sadece harf kullanınız!")]

        public string Soyad { get; set; }

       

        public bool Cinsiyet { get; set; }
        [Required]
        [StringLength(20)]
        [MinLength(2, ErrorMessage = "Unvan alanı en az 2 Karakter olmalıdır !")]
        [MaxLength(20, ErrorMessage = "Unvan alanı en fazla 20 Karakter olmalıdır !")]
        [RegularExpression(("[a-zA-Z çüöğşıİĞÇÜŞ]*"), ErrorMessage = "Sadece harf kullanınız!")]
        public string Unvan { get; set; }

        [Required]
        [StringLength(7)]
        [MinLength(7, ErrorMessage = "Kurum Sicil No 7 karakter olmalıdır!")]
        [MaxLength(7, ErrorMessage = "Kurum Sicil No 7 karakter olmalıdır!")]
        [RegularExpression(@"[0-9]+$", ErrorMessage = "Lütfen Sadece Sayı Değerlerini Giriniz")]

        public string KurumSicilNo { get; set; }

        [Required]
        [StringLength(16)]
        [MaxLength(16, ErrorMessage = "Maksimum 16 karakter giriniz!")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Geçerli Bir Telefon No Giriniz")]


        public string CepTelefonu { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Geçerli Bir E-Posta Adresi Giriniz")]
        [MaxLength(50, ErrorMessage = "En fazla 50 karakterli bir e posta giriniz!")]

        public string Eposta { get; set; }

        public bool MedeniDurum { get; set; }

        [Required]
        public string EvAdresi { get; set; }


       
        [StringLength(10)]
        [MaxLength(10, ErrorMessage = "En fazla 10 karakter olmalı!")]
        public string Askerlik { get; set; }


        [StringLength(10)]
        [MaxLength(10, ErrorMessage = "En fazla 10 karakter olmalı!")]
        public string Ehliyet { get; set; }

        
        public bool EngellilikDurumu { get; set; }

        public byte DepartmanId { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime DogumTarihi { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime İseGirisTarihi { get; set; }

        public bool AktifPasif { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CikisTarihi { get; set; }

        [StringLength(11)]
        [MaxLength(11, ErrorMessage = "TC kimlik numarası 11 haneli olmalıdır!")]
        [MinLength(11, ErrorMessage = "TC kimlik numarası 11 haneli olmalıdır!")]
        [RegularExpression(@"[0-9]+$", ErrorMessage = "Lütfen Sadece Sayı Değerlerini Giriniz")]

        public string EsiTc { get; set; }

        [StringLength(50)]
        [MaxLength(50, ErrorMessage = "Ad Soyad alanı en fazla 50 Karakter olmalıdır !")]
        [RegularExpression(@"[a-zA-Z çüöğşıİĞÇÜŞ]*", ErrorMessage = "Sadece harf kullanınız!")]

        public string EsiAdiSoyadi { get; set; }

       
        [StringLength(16)]
        [MaxLength(16, ErrorMessage = "Maksimum 16 karakter giriniz!")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Geçerli Bir Telefon No Giriniz")]

        public string EsiTelefon { get; set; }

        public bool? EsiIsDurumu { get; set; }

        public virtual Departmanlar Departmanlar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzinTakip> IzinTakip { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonelCocuk> PersonelCocuk { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonelEgitim> PersonelEgitim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonelKiyafet> PersonelKiyafet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonelPuantaj> PersonelPuantaj { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonelSaglikDurumlari> PersonelSaglikDurumlari { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonelBelgeler> PersonelBelgeler { get; set; }


    }
}
