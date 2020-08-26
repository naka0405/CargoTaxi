namespace CargoTaxi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_format_DateTime_onDate_inOrder : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.Orders", "Date", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
    }
}
