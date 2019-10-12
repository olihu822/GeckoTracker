namespace GT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GeckosToGeckoDbContext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gecko", "OwnerID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Gecko", "OwnerID");
        }
    }
}
