namespace PDKS_Code_First.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tekrar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departmanlar",
                c => new
                    {
                        Id = c.Byte(nullable: false, identity: true),
                        DepartmanAdi = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonelKiyafet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonelId = c.Int(nullable: false),
                        DepartmanId = c.Byte(nullable: false),
                        IstekNedeni = c.String(nullable: false, maxLength: 20),
                        Renk = c.Byte(nullable: false),
                        Model = c.Byte(nullable: false),
                        UstBedenNo = c.Byte(nullable: false),
                        AltBedenNo = c.Byte(nullable: false),
                        KafaBedenNo = c.Byte(nullable: false),
                        AyakkabiNo = c.Byte(nullable: false),
                        Boy = c.Byte(nullable: false),
                        Kilo = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonelOzlukBilgileri", t => t.PersonelId)
                .ForeignKey("dbo.Departmanlar", t => t.DepartmanId)
                .Index(t => t.PersonelId)
                .Index(t => t.DepartmanId);
            
            CreateTable(
                "dbo.PersonelOzlukBilgileri",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TcKimlik = c.String(nullable: false, maxLength: 11, fixedLength: true, unicode: false),
                        Ad = c.String(nullable: false, maxLength: 25),
                        Soyad = c.String(nullable: false, maxLength: 25),
                        Cinsiyet = c.Boolean(nullable: false),
                        Unvan = c.String(nullable: false, maxLength: 20),
                        KurumSicilNo = c.String(nullable: false, maxLength: 7, fixedLength: true, unicode: false),
                        CepTelefonu = c.String(nullable: false, maxLength: 16),
                        Eposta = c.String(nullable: false, maxLength: 50),
                        MedeniDurum = c.Boolean(nullable: false),
                        EvAdresi = c.String(nullable: false),
                        Askerlik = c.String(maxLength: 10),
                        Ehliyet = c.String(maxLength: 10),
                        EngellilikDurumu = c.Boolean(nullable: false),
                        DepartmanId = c.Byte(nullable: false),
                        DogumTarihi = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        İseGirisTarihi = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        AktifPasif = c.Boolean(nullable: false),
                        CikisTarihi = c.DateTime(storeType: "smalldatetime"),
                        EsiTc = c.String(maxLength: 11, fixedLength: true, unicode: false),
                        EsiAdiSoyadi = c.String(maxLength: 50),
                        EsiTelefon = c.String(maxLength: 16),
                        EsiIsDurumu = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departmanlar", t => t.DepartmanId)
                .Index(t => t.DepartmanId);
            
            CreateTable(
                "dbo.IzinTakip",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonelId = c.Int(nullable: false),
                        IzinTalepTarihi = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        IzinBaslangicTarihi = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        İzinBitisTarihi = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        IzinliGunSayisi = c.Byte(nullable: false),
                        IzinTipi = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonelOzlukBilgileri", t => t.PersonelId)
                .Index(t => t.PersonelId);
            
            CreateTable(
                "dbo.PersonelBelgeler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonelId = c.Int(nullable: false),
                        BelgeAdi = c.String(nullable: false, maxLength: 30),
                        DosyaYolu = c.String(nullable: false),
                        BelgeTipi = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonelOzlukBilgileri", t => t.PersonelId)
                .Index(t => t.PersonelId);
            
            CreateTable(
                "dbo.PersonelCocuk",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonelId = c.Int(nullable: false),
                        CocukAdiSoyadi = c.String(nullable: false, maxLength: 50),
                        CocukDogumTarihi = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        CocukCinsiyet = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonelOzlukBilgileri", t => t.PersonelId)
                .Index(t => t.PersonelId);
            
            CreateTable(
                "dbo.PersonelEgitim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonelId = c.Int(nullable: false),
                        EgitimBilgisi = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonelOzlukBilgileri", t => t.PersonelId)
                .Index(t => t.PersonelId);
            
            CreateTable(
                "dbo.PersonelPuantaj",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonelId = c.Int(nullable: false),
                        GirisZamani = c.DateTime(nullable: false, storeType: "date"),
                        CikisZamani = c.DateTime(nullable: false, storeType: "date"),
                        Mazeret = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonelOzlukBilgileri", t => t.PersonelId)
                .Index(t => t.PersonelId);
            
            CreateTable(
                "dbo.PersonelSaglikDurumlari",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonelId = c.Int(nullable: false),
                        Alerji = c.Boolean(nullable: false),
                        KalpHastaligi = c.Boolean(nullable: false),
                        KasEklem = c.Boolean(nullable: false),
                        GormeKusuru = c.Boolean(nullable: false),
                        IsitmeKaybi = c.Boolean(nullable: false),
                        BagisiklikGuclugu = c.Boolean(nullable: false),
                        KronikHastalik = c.Boolean(nullable: false),
                        AstimKoah = c.Boolean(nullable: false),
                        SindirimRahatsizliklari = c.Boolean(nullable: false),
                        Aciklama = c.String(),
                        RuhsalHastalik = c.Boolean(nullable: false),
                        ZihinselHastalik = c.Boolean(nullable: false),
                        KanGrubu = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonelOzlukBilgileri", t => t.PersonelId)
                .Index(t => t.PersonelId);
            
            CreateTable(
                "dbo.Kullanicilar",
                c => new
                    {
                        Id = c.Byte(nullable: false, identity: true),
                        Ad = c.String(nullable: false, maxLength: 25),
                        Soyad = c.String(nullable: false, maxLength: 25),
                        TcNo = c.String(maxLength: 11, fixedLength: true, unicode: false),
                        SicilNo = c.String(maxLength: 7, fixedLength: true, unicode: false),
                        EPosta = c.String(maxLength: 50),
                        KullaniciAdi = c.String(maxLength: 20),
                        Parola = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SistemeKayitOlabilecekler",
                c => new
                    {
                        Id = c.Byte(nullable: false, identity: true),
                        TcNo = c.String(nullable: false, maxLength: 11, fixedLength: true, unicode: false),
                        SicilNo = c.String(nullable: false, maxLength: 7, fixedLength: true, unicode: false),
                        Ad = c.String(nullable: false, maxLength: 25),
                        SoyAd = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonelOzlukBilgileri", "DepartmanId", "dbo.Departmanlar");
            DropForeignKey("dbo.PersonelKiyafet", "DepartmanId", "dbo.Departmanlar");
            DropForeignKey("dbo.PersonelSaglikDurumlari", "PersonelId", "dbo.PersonelOzlukBilgileri");
            DropForeignKey("dbo.PersonelPuantaj", "PersonelId", "dbo.PersonelOzlukBilgileri");
            DropForeignKey("dbo.PersonelKiyafet", "PersonelId", "dbo.PersonelOzlukBilgileri");
            DropForeignKey("dbo.PersonelEgitim", "PersonelId", "dbo.PersonelOzlukBilgileri");
            DropForeignKey("dbo.PersonelCocuk", "PersonelId", "dbo.PersonelOzlukBilgileri");
            DropForeignKey("dbo.PersonelBelgeler", "PersonelId", "dbo.PersonelOzlukBilgileri");
            DropForeignKey("dbo.IzinTakip", "PersonelId", "dbo.PersonelOzlukBilgileri");
            DropIndex("dbo.PersonelSaglikDurumlari", new[] { "PersonelId" });
            DropIndex("dbo.PersonelPuantaj", new[] { "PersonelId" });
            DropIndex("dbo.PersonelEgitim", new[] { "PersonelId" });
            DropIndex("dbo.PersonelCocuk", new[] { "PersonelId" });
            DropIndex("dbo.PersonelBelgeler", new[] { "PersonelId" });
            DropIndex("dbo.IzinTakip", new[] { "PersonelId" });
            DropIndex("dbo.PersonelOzlukBilgileri", new[] { "DepartmanId" });
            DropIndex("dbo.PersonelKiyafet", new[] { "DepartmanId" });
            DropIndex("dbo.PersonelKiyafet", new[] { "PersonelId" });
            DropTable("dbo.SistemeKayitOlabilecekler");
            DropTable("dbo.Kullanicilar");
            DropTable("dbo.PersonelSaglikDurumlari");
            DropTable("dbo.PersonelPuantaj");
            DropTable("dbo.PersonelEgitim");
            DropTable("dbo.PersonelCocuk");
            DropTable("dbo.PersonelBelgeler");
            DropTable("dbo.IzinTakip");
            DropTable("dbo.PersonelOzlukBilgileri");
            DropTable("dbo.PersonelKiyafet");
            DropTable("dbo.Departmanlar");
        }
    }
}
