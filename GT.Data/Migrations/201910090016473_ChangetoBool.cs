namespace GT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangetoBool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gecko", "GeckoSexIsMale", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Gecko", "GeckoSexIsMale");
        }
    }
}
