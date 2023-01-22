namespace PDKS_Code_First.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class belgelertablosugıncelleme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonelBelgeler", "BelgeTuru", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PersonelBelgeler", "BelgeTuru");
        }
    }
}
