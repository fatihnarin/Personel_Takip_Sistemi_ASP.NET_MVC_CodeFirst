namespace PDKS_Code_First.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class belgedeneme : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PersonelBelgeler", "BelgeAdi", c => c.String());
            AlterColumn("dbo.PersonelBelgeler", "BelgeYolu", c => c.Binary());
            AlterColumn("dbo.PersonelBelgeler", "BelgeTipi", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PersonelBelgeler", "BelgeTipi", c => c.String(nullable: false));
            AlterColumn("dbo.PersonelBelgeler", "BelgeYolu", c => c.Binary(nullable: false));
            AlterColumn("dbo.PersonelBelgeler", "BelgeAdi", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
