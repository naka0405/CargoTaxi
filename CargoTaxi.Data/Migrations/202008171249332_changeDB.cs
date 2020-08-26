namespace CargoTaxi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Orders", "Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
        }
    }
}
