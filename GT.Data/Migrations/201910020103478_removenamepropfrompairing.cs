namespace GT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removenamepropfrompairing : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pairing", "MaleGeckoName");
            DropColumn("dbo.Pairing", "FemaleGeckoName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pairing", "FemaleGeckoName", c => c.String());
            AddColumn("dbo.Pairing", "MaleGeckoName", c => c.String());
        }
    }
}
