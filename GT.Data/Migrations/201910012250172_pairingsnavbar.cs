namespace GT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pairingsnavbar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pairing", "MaleGeckoName", c => c.String());
            AddColumn("dbo.Pairing", "FemaleGeckoName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pairing", "FemaleGeckoName");
            DropColumn("dbo.Pairing", "MaleGeckoName");
        }
    }
}
