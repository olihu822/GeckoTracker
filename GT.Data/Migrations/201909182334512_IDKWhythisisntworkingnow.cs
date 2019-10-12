namespace GT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDKWhythisisntworkingnow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gecko", "GeckoSex", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Gecko", "GeckoSex");
        }
    }
}
