namespace CargoTaxi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_columnFirstName_toUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
