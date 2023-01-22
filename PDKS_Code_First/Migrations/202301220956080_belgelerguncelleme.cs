namespace PDKS_Code_First.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class belgelerguncelleme : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PersonelBelgeler", "BelgeYolu", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PersonelBelgeler", "BelgeYolu", c => c.Byte(nullable: false));
        }
    }
}
