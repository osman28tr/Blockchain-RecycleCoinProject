namespace RecycleCoin.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_sp_for_getUserRecycleItemsByUserId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRecycleItems", "Amount", c => c.Int(nullable: false));
            Sql($@"CREATE PROCEDURE `sp_getUserRecycleItemsByUserId`(IN userId varchar(128))
                    BEGIN
	                    SELECT * FROM recyclecoindb.userrecycleitems ur where ur.UserId = userId ; 
                    END");
        }

        public override void Down()
        {
            DropColumn("dbo.UserRecycleItems", "Amount");
            Sql($@"DROP PROCEDURE `recyclecoindb`.`sp_getUserRecycleItemsByUserId`;");
        }
    }
}
