namespace MVC_Security.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using MVC_Security.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_Security.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MVC_Security.Models.ApplicationDbContext";
        }

        protected override void Seed(MVC_Security.Models.ApplicationDbContext context)
        {
            //var hasher = new PasswordHasher();
            //context.Users.AddOrUpdate(u => u.UserName, new ApplicationUser { UserName = "steven@vdab.be", PasswordHash = hasher.HashPassword("appelmoes") });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //if (!context.Users.Any(u => u.UserName == "Directeur@mvc.net"))
            //{ 
            //    var userStore = new UserStore<ApplicationUser>(context);
            //    var userManager = new UserManager<ApplicationUser>(userStore);
            //    var roleStore = new RoleStore<IdentityRole>(context);
            //    var roleManager = new RoleManager<IdentityRole>(roleStore);
            //    var user = new ApplicationUser { UserName = "Directeur@mvc.net" };
            //    userManager.Create(user, "appelmoes"); 
            //    var role = new IdentityRole { Name = "Management" };
            //    roleManager.Create(role); 
            //    userManager.AddToRole(user.Id, "Management");
            //}
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            ApplicationUser user;
            if (!context.Roles.Any(u => u.Name == "Student"))
                roleManager.Create(new IdentityRole { Name = "Student" });
            if (!context.Roles.Any(u => u.Name == "Leraar"))
                roleManager.Create(new IdentityRole { Name = "Leraar" });
            if (!context.Roles.Any(u => u.Name == "Admin"))
                roleManager.Create(new IdentityRole { Name = "Admin" });
            if (!context.Users.Any(u => u.UserName == "Admin@mvc.net"))
            {
                user = new ApplicationUser { UserName = "Admin@mvc.net" };
                userManager.Create(user, "Admin0");
                userManager.AddToRole(user.Id, "Admin");
            }
            if (!context.Users.Any(u => u.UserName == "Leraar1@mvc.net"))
            {
                user = new ApplicationUser { UserName = "Leraar1@mvc.net" };
                userManager.Create(user, "Leraar1");
                userManager.AddToRole(user.Id, "Leraar");
            }
            if (!context.Users.Any(u => u.UserName == "Leraar2@mvc.net"))
            {
                user = new ApplicationUser { UserName = "Leraar2@mvc.net" };
                userManager.Create(user, "Leraar2");
                userManager.AddToRole(user.Id, "Leraar");
            }
            if (!context.Users.Any(u => u.UserName == "Leraar3@mvc.net"))
            {
                user = new ApplicationUser { UserName = "Leraar3@mvc.net" };
                userManager.Create(user, "Leraar3");
                userManager.AddToRole(user.Id, "Leraar");
            }
            if (!context.Users.Any(u => u.UserName == "Student1@mvc.net"))
            {
                user = new ApplicationUser { UserName = "Student1@mvc.net" };
                userManager.Create(user, "Student1");
                userManager.AddToRole(user.Id, "Student");
            }
            if (!context.Users.Any(u => u.UserName == "Student2@mvc.net"))
            {
                user = new ApplicationUser { UserName = "Student2@mvc.net" };
                userManager.Create(user, "Student2");
                userManager.AddToRole(user.Id, "Student");
            }
            if (!context.Users.Any(u => u.UserName == "Student3@mvc.net"))
            {
                user = new ApplicationUser { UserName = "Student3@mvc.net" };
                userManager.Create(user, "Student3");
                userManager.AddToRole(user.Id, "Student");
            }
            if (!context.Users.Any(u => u.UserName == "Student4@mvc.net"))
            {
                user = new ApplicationUser { UserName = "Student4@mvc.net" };
                userManager.Create(user, "Student4");
                userManager.AddToRole(user.Id, "Student");
            }
        }
    }
}
