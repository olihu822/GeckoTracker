namespace GT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangetoChar : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Gecko", "GeckoSex");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gecko", "GeckoSex", c => c.String(nullable: false));
        }
    }
}
