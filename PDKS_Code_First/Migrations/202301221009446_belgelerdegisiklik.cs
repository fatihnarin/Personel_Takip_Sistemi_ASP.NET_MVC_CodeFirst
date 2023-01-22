namespace PDKS_Code_First.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class belgelerdegisiklik : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PersonelBelgeler", "BelgeTipi", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PersonelBelgeler", "BelgeTipi", c => c.Byte(nullable: false));
        }
    }
}
