namespace RecycleCoin.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_db_function_for_statistic_panel : DbMigration
    {
        public override void Up()
        {

            Sql(@"CREATE FUNCTION `bestRecycleAmount`(
                    filterDate int
                ) RETURNS int
                    DETERMINISTIC
                begin
                    declare res int;
                SELECT 
                    SUM(Amount) into res
                FROM
                    recyclecoindb.userrecycleitems
                WHERE
                    RecycleDate BETWEEN CURDATE() - INTERVAL filterDate DAY AND CURDATE()
                GROUP BY UserId
                HAVING SUM(Amount)
                ORDER BY SUM(Amount) DESC
                LIMIT 1;
                    return res;
                end");

            Sql(@"CREATE FUNCTION `bestRecycleUserID`(
                    filterDate int
                ) RETURNS char(128) CHARSET utf8mb4
                    DETERMINISTIC
                begin
                    declare res char(128);
                SELECT 
                    UserId
                INTO res FROM
                    recyclecoindb.userrecycleitems
                WHERE
                    RecycleDate BETWEEN CURDATE() - INTERVAL filterDate DAY AND CURDATE()
                GROUP BY UserId
                HAVING SUM(Amount)
                ORDER BY SUM(Amount) DESC
                LIMIT 1;
                    return res;
                end");
        }

        public override void Down()
        {
            Sql("DROP FUNCTION `recyclecoindb`.`bestRecycleAmount`;");
            Sql("DROP FUNCTION `recyclecoindb`.`bestRecycleUserID`;");
        }
    }
}
