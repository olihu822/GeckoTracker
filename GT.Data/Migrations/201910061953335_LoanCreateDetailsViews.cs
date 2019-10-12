namespace GT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoanCreateDetailsViews : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Loan",
                c => new
                    {
                        LoanID = c.Int(nullable: false, identity: true),
                        LoanedGeckoID = c.Int(nullable: false),
                        LoanedGeckoName = c.String(),
                        OwnerID = c.Guid(nullable: false),
                        LeaseeName = c.String(nullable: false),
                        LoanStart = c.DateTime(nullable: false),
                        LoanDuration = c.String(),
                    })
                .PrimaryKey(t => t.LoanID)
                .ForeignKey("dbo.Gecko", t => t.LoanedGeckoID, cascadeDelete: true)
                .Index(t => t.LoanedGeckoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loan", "LoanedGeckoID", "dbo.Gecko");
            DropIndex("dbo.Loan", new[] { "LoanedGeckoID" });
            DropTable("dbo.Loan");
        }
    }
}
