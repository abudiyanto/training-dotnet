namespace Training.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehicleV5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vehicles", "Year");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "Year", c => c.String());
        }
    }
}
