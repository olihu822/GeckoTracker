namespace GT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class owneridFK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pairing", "OwnerID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pairing", "OwnerID");
        }
    }
}
