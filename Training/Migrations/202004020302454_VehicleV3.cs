namespace Training.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehicleV3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "Fuel", c => c.String());
            AddColumn("dbo.Vehicles", "Capacity", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "RegistrationNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "RegistrationNumber");
            DropColumn("dbo.Vehicles", "Capacity");
            DropColumn("dbo.Vehicles", "Fuel");
        }
    }
}
