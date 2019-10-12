namespace GT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pairings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pairing",
                c => new
                    {
                        PairingID = c.Int(nullable: false, identity: true),
                        MaleGeckoID = c.Int(nullable: false),
                        FemaleGeckoID = c.Int(nullable: false),
                        Season = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PairingID)
                .ForeignKey("dbo.Gecko", t => t.FemaleGeckoID)
                .ForeignKey("dbo.Gecko", t => t.MaleGeckoID)
                .Index(t => t.MaleGeckoID)
                .Index(t => t.FemaleGeckoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pairing", "MaleGeckoID", "dbo.Gecko");
            DropForeignKey("dbo.Pairing", "FemaleGeckoID", "dbo.Gecko");
            DropIndex("dbo.Pairing", new[] { "FemaleGeckoID" });
            DropIndex("dbo.Pairing", new[] { "MaleGeckoID" });
            DropTable("dbo.Pairing");
        }
    }
}
