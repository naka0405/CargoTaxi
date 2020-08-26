namespace CargoTaxi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_columns_StartTime_FinishTime_toOrders : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "StartTime", c => c.String());
            AddColumn("dbo.Orders", "FinishTime", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "FinishTime");
            DropColumn("dbo.Orders", "StartTime");
        }
    }
}
