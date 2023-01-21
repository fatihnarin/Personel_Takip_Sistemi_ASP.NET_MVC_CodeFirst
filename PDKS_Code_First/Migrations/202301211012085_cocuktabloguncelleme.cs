namespace PDKS_Code_First.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cocuktabloguncelleme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonelCocuk", "CocukTc", c => c.String(nullable: false, maxLength: 11));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PersonelCocuk", "CocukTc");
        }
    }
}
