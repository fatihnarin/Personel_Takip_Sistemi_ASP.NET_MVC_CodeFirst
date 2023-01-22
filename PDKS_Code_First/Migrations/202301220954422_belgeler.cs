namespace PDKS_Code_First.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class belgeler : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonelBelgeler", "BelgeYolu", c => c.Byte(nullable: false));
            AlterColumn("dbo.PersonelBelgeler", "BelgeTipi", c => c.Byte(nullable: false));
            DropColumn("dbo.PersonelBelgeler", "DosyaYolu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PersonelBelgeler", "DosyaYolu", c => c.String(nullable: false));
            AlterColumn("dbo.PersonelBelgeler", "BelgeTipi", c => c.Int(nullable: false));
            DropColumn("dbo.PersonelBelgeler", "BelgeYolu");
        }
    }
}
