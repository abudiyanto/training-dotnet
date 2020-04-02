namespace Training.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehicleV7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        IdCategory = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.IdCategory);
            
            AddColumn("dbo.Vehicles", "Category_IdCategory", c => c.String(maxLength: 128));
            CreateIndex("dbo.Vehicles", "Category_IdCategory");
            AddForeignKey("dbo.Vehicles", "Category_IdCategory", "dbo.Categories", "IdCategory");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "Category_IdCategory", "dbo.Categories");
            DropIndex("dbo.Vehicles", new[] { "Category_IdCategory" });
            DropColumn("dbo.Vehicles", "Category_IdCategory");
            DropTable("dbo.Categories");
        }
    }
}
