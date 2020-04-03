namespace Training.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCapacityModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Capacities",
                c => new
                    {
                        IdCapacity = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.IdCapacity);
            
            AddColumn("dbo.Vehicles", "Capacity_IdCapacity", c => c.String(maxLength: 128));
            CreateIndex("dbo.Vehicles", "Capacity_IdCapacity");
            AddForeignKey("dbo.Vehicles", "Capacity_IdCapacity", "dbo.Capacities", "IdCapacity");
            DropColumn("dbo.Vehicles", "Capacity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "Capacity", c => c.Int(nullable: false));
            DropForeignKey("dbo.Vehicles", "Capacity_IdCapacity", "dbo.Capacities");
            DropIndex("dbo.Vehicles", new[] { "Capacity_IdCapacity" });
            DropColumn("dbo.Vehicles", "Capacity_IdCapacity");
            DropTable("dbo.Capacities");
        }
    }
}
