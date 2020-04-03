namespace Training.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        IdVehicle = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Descriptions = c.String(),
                        Wheel = c.Int(nullable: false),
                        Capacity = c.Int(nullable: false),
                        RegistrationNumber = c.String(),
                        Category_IdCategory = c.String(maxLength: 128),
                        Color_IdColor = c.String(maxLength: 128),
                        Fuel_IdFuel = c.String(maxLength: 128),
                        Year_IdYear = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdVehicle)
                .ForeignKey("dbo.Categories", t => t.Category_IdCategory)
                .ForeignKey("dbo.Colors", t => t.Color_IdColor)
                .ForeignKey("dbo.Fuels", t => t.Fuel_IdFuel)
                .ForeignKey("dbo.Years", t => t.Year_IdYear)
                .Index(t => t.Category_IdCategory)
                .Index(t => t.Color_IdColor)
                .Index(t => t.Fuel_IdFuel)
                .Index(t => t.Year_IdYear);
            
            CreateTable(
                "dbo.Years",
                c => new
                    {
                        IdYear = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.IdYear);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "Year_IdYear", "dbo.Years");
            DropForeignKey("dbo.Vehicles", "Fuel_IdFuel", "dbo.Fuels");
            DropForeignKey("dbo.Vehicles", "Color_IdColor", "dbo.Colors");
            DropForeignKey("dbo.Vehicles", "Category_IdCategory", "dbo.Categories");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.Vehicles", new[] { "Year_IdYear" });
            DropIndex("dbo.Vehicles", new[] { "Fuel_IdFuel" });
            DropIndex("dbo.Vehicles", new[] { "Color_IdColor" });
            DropIndex("dbo.Vehicles", new[] { "Category_IdCategory" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.Years");
            DropTable("dbo.Vehicles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Fuels");
            DropTable("dbo.Colors");
            DropTable("dbo.Categories");
        }
    }
}
