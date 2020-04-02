namespace Training.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehicleV4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "Year", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "Year");
        }
    }
}
