namespace CargoTaxi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_prop_PartOfDay_for_Order : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "PartOfDay", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "PartOfDay");
        }
    }
}
