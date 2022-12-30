namespace RecycleCoin.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_TcNo_and_Year_columns_to_User : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "TcNo", c => c.Long(nullable: false));
            AddColumn("dbo.AspNetUsers", "Year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Year");
            DropColumn("dbo.AspNetUsers", "TcNo");
        }
    }
}
