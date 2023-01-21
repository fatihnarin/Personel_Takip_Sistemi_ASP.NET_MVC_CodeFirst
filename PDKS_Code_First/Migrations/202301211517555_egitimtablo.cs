namespace PDKS_Code_First.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class egitimtablo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PersonelEgitim", "SonMezunOlduguUkulAdı", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PersonelEgitim", "SonMezunOlduguUkulAdı", c => c.String(nullable: false));
        }
    }
}
