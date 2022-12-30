namespace RecycleCoin.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_sp_for_getProductsByCategoryId : DbMigration
    {
        public override void Up()
        {
            Sql($@"CREATE PROCEDURE `sp_getProductsByCategoryId` (IN catId int)
            BEGIN
                select * FROM products where CategoryId = catId;
            END");
        }

        public override void Down()
        {
            Sql($"DROP PROCEDURE `recyclecoindb`.`sp_getProductsByCategoryId`;");
        }
    }
}
