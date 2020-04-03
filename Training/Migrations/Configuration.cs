namespace Training.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Training.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Training.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Training.Models.ApplicationDbContext";
        }

        protected override void Seed(Training.Models.ApplicationDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            if (roleManager.Roles.Count() == 0)
            {
                roleManager.Create(new IdentityRole { Name = "Customer" });
                roleManager.Create(new IdentityRole { Name = "Administrator" });
            };

            var administrator = new ApplicationUser
            {
                PhoneNumber = "+62818271214",
                PhoneNumberConfirmed = true,
                UserName = "alex@cloudcomputing.id",
                Email = "alex@cloudcomputing.id"
            };
            if(manager.FindByName("alex@cloucomputing.id") == null)
            {
                manager.Create(administrator, "Training@2020!!");
                manager.AddToRoles(administrator.Id, new string[] { "Administrator", "Customer" });
            }

            var customer = new ApplicationUser
            {
                PhoneNumber = "+62818111111",
                PhoneNumberConfirmed = true,
                UserName = "customer@cloudcomputing.id",
                Email = "customer@cloudcomputing.id"
            };
            if (manager.FindByName("customer@cloudcomputing.id") == null)
            {
                manager.Create(customer, "Customer@2020!!");
                manager.AddToRoles(customer.Id, new string[] { "Customer" });
            }

            //TO:DO 
            //Buat 2 akun user dengan role Administrator dan Customer 
            //Implement otorisasi dan role nya di Controller dan Action yang pernah dibuat 

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
