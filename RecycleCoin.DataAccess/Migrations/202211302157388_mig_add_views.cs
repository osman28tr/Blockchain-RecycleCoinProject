namespace RecycleCoin.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_add_views : DbMigration
    {
        public override void Up()
        {
            // order by user name view
            Sql($@"CREATE VIEW `name_OrderByView` AS
                   SELECT 
                       ur.Id,
                       ur.UserId,
                       ur.ProductId,
                       ur.RecycleDate,
                       ur.RecycleCarbon,
                       ur.Amount
                   FROM
                       recyclecoindb.userrecycleitems ur
                           INNER JOIN
                       recyclecoindb.aspnetusers u ON ur.UserId = u.Id
                   ORDER BY u.Name;");

            //order by date view
            Sql($@"CREATE VIEW `date_OrderByView` AS
                   SELECT 
                       *
                   FROM
                       recyclecoindb.userrecycleitems ur
                   ORDER BY ur.RecycleDate;");

            //order by product name view
            Sql($@"CREATE VIEW `product_OrderByView` AS
                   SELECT 
	                   ur.Id,
                       ur.UserId,
                       ur.ProductId,
                       ur.RecycleDate,
                       ur.RecycleCarbon, 
                       ur.Amount
                   FROM
                       recyclecoindb.userrecycleitems ur
                       inner join recyclecoindb.products p on ur.ProductId = p.Id
                   ORDER BY p.Name;");

            //order by amount view
            Sql($@"CREATE VIEW `amount_OrderByView` AS
                   SELECT 
                       *
                   FROM
                       recyclecoindb.userrecycleitems ur
                   ORDER BY ur.Amount;");

            //order by carbon view 
            Sql($@"CREATE VIEW `carbon_OrderByView` AS
                   SELECT 
                       *
                   FROM
                       recyclecoindb.userrecycleitems ur
                   ORDER BY ur.RecycleCarbon;");
        }

        public override void Down()
        {
            Sql(@"DROP VIEW `recyclecoindb`.`name_OrderByView`;");
            Sql(@"DROP VIEW `recyclecoindb`.`date_OrderByView`;");
            Sql(@"DROP VIEW `recyclecoindb`.`product_OrderByView`;");
            Sql(@"DROP VIEW `recyclecoindb`.`amount_OrderByView`;");
            Sql(@"DROP VIEW `recyclecoindb`.`carbon_OrderByView`;");
        }
    }
}
