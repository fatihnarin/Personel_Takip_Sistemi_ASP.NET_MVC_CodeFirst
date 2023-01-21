namespace PDKS_Code_First.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Egitim_saglik_tablosuvedigertablolardaguncelleme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonelEgitim", "EgitimDurumu", c => c.Byte(nullable: false));
            AddColumn("dbo.PersonelEgitim", "SonMezunOlduguUkulAdı", c => c.String(nullable: false));
            AlterColumn("dbo.PersonelOzlukBilgileri", "KurumSicilNo", c => c.String(maxLength: 7, fixedLength: true, unicode: false));
            AlterColumn("dbo.PersonelSaglikDurumlari", "Aciklama", c => c.String(nullable: false));
            AlterColumn("dbo.PersonelSaglikDurumlari", "KanGrubu", c => c.Byte(nullable: false));
            AlterColumn("dbo.Kullanicilar", "TcNo", c => c.String(nullable: false, maxLength: 11, fixedLength: true, unicode: false));
            AlterColumn("dbo.Kullanicilar", "EPosta", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Kullanicilar", "KullaniciAdi", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Kullanicilar", "Parola", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.PersonelEgitim", "EgitimBilgisi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PersonelEgitim", "EgitimBilgisi", c => c.String(nullable: false));
            AlterColumn("dbo.Kullanicilar", "Parola", c => c.String(maxLength: 20));
            AlterColumn("dbo.Kullanicilar", "KullaniciAdi", c => c.String(maxLength: 20));
            AlterColumn("dbo.Kullanicilar", "EPosta", c => c.String(maxLength: 50));
            AlterColumn("dbo.Kullanicilar", "TcNo", c => c.String(maxLength: 11, fixedLength: true, unicode: false));
            AlterColumn("dbo.PersonelSaglikDurumlari", "KanGrubu", c => c.Int(nullable: false));
            AlterColumn("dbo.PersonelSaglikDurumlari", "Aciklama", c => c.String());
            AlterColumn("dbo.PersonelOzlukBilgileri", "KurumSicilNo", c => c.String(nullable: false, maxLength: 7, fixedLength: true, unicode: false));
            DropColumn("dbo.PersonelEgitim", "SonMezunOlduguUkulAdı");
            DropColumn("dbo.PersonelEgitim", "EgitimDurumu");
        }
    }
}
