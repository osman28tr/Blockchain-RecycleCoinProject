namespace RecycleCoin.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_carbon_column_to_user : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Carbon", c => c.Int(nullable: false,defaultValue:0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Carbon");
        }
    }
}
