namespace RecycleCoin.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_keyPair : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PublicKey", c => c.String(unicode: false));
            AddColumn("dbo.AspNetUsers", "PrivateKey", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PrivateKey");
            DropColumn("dbo.AspNetUsers", "PublicKey");
        }
    }
}
