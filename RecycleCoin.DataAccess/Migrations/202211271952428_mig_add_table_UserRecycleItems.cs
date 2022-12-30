namespace RecycleCoin.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_table_UserRecycleItems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRecycleItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128, storeType: "nvarchar"),
                        ProductId = c.Int(nullable: false),
                        RecycleDate = c.DateTime(nullable: false, precision: 0),
                        RecycleCarbon = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRecycleItems", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserRecycleItems", "ProductId", "dbo.Products");
            DropIndex("dbo.UserRecycleItems", new[] { "ProductId" });
            DropIndex("dbo.UserRecycleItems", new[] { "UserId" });
            DropTable("dbo.UserRecycleItems");
        }
    }
}
