namespace Training.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        IdColor = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.IdColor);
            
            CreateTable(
                "dbo.Fuels",
                c => new
                    {
                        IdFuel = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.IdFuel);
            
            CreateTable(
                "dbo.Years",
                c => new
                    {
                        IdYear = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.IdYear);
            
            AddColumn("dbo.Vehicles", "Color_IdColor", c => c.String(maxLength: 128));
            AddColumn("dbo.Vehicles", "Fuel_IdFuel", c => c.String(maxLength: 128));
            AddColumn("dbo.Vehicles", "Year_IdYear", c => c.String(maxLength: 128));
            CreateIndex("dbo.Vehicles", "Color_IdColor");
            CreateIndex("dbo.Vehicles", "Fuel_IdFuel");
            CreateIndex("dbo.Vehicles", "Year_IdYear");
            AddForeignKey("dbo.Vehicles", "Color_IdColor", "dbo.Colors", "IdColor");
            AddForeignKey("dbo.Vehicles", "Fuel_IdFuel", "dbo.Fuels", "IdFuel");
            AddForeignKey("dbo.Vehicles", "Year_IdYear", "dbo.Years", "IdYear");
            DropColumn("dbo.Vehicles", "Color");
            DropColumn("dbo.Vehicles", "Fuel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "Fuel", c => c.String());
            AddColumn("dbo.Vehicles", "Color", c => c.String());
            DropForeignKey("dbo.Vehicles", "Year_IdYear", "dbo.Years");
            DropForeignKey("dbo.Vehicles", "Fuel_IdFuel", "dbo.Fuels");
            DropForeignKey("dbo.Vehicles", "Color_IdColor", "dbo.Colors");
            DropIndex("dbo.Vehicles", new[] { "Year_IdYear" });
            DropIndex("dbo.Vehicles", new[] { "Fuel_IdFuel" });
            DropIndex("dbo.Vehicles", new[] { "Color_IdColor" });
            DropColumn("dbo.Vehicles", "Year_IdYear");
            DropColumn("dbo.Vehicles", "Fuel_IdFuel");
            DropColumn("dbo.Vehicles", "Color_IdColor");
            DropTable("dbo.Years");
            DropTable("dbo.Fuels");
            DropTable("dbo.Colors");
        }
    }
}
