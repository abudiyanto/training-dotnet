namespace Training.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehicleV2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "Color", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "Color");
        }
    }
}
