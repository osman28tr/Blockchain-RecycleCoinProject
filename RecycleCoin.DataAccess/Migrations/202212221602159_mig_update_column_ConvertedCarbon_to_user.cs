namespace RecycleCoin.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_update_column_ConvertedCarbon_to_user : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "ConvertedCarbon", c => c.Decimal(nullable: false, precision: 18, scale: 8));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "ConvertedCarbon", c => c.Double(nullable: false));
        }
    }
}
