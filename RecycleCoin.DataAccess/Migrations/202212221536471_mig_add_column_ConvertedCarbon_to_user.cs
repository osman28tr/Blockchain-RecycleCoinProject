namespace RecycleCoin.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_column_ConvertedCarbon_to_user : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ConvertedCarbon", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ConvertedCarbon");
        }
    }
}
