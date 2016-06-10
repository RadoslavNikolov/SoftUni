namespace Portal.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Web;
    using DAO;
    using Models.IdentityModels;
    using Newtonsoft.Json;

    public sealed class Configuration : DbMigrationsConfiguration<Portal.Data.ApplicationDbContext>
    {
        private string usersImportPath;

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Portal.Data.ApplicationDbContext context)
        {
            SeedRoles(context);
            SeedUsers(context);
        }



        private void SeedRoles(ApplicationDbContext context)
        {
            // makes an admin role if one doesn't exist
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            // makes an user role if one doesn't exist
            if (!context.Roles.Any(r => r.Name == "User"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "User" };

                manager.Create(role);
            }
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                this.usersImportPath = HttpContext.Current.Server.MapPath(@"~\") + @"Seed\users.json";

                var json = File.ReadAllText(this.usersImportPath);

                var users = JsonConvert.DeserializeObject<IList<UserModel>>(json);

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore)
                {
                    PasswordValidator = new MinimumLengthValidator(3)
                };

                foreach (var userModel in users)
                {
                    var user = new ApplicationUser
                    {
                        UserName = userModel.UserName,
                        Egn = userModel.Egn,
                        Email = userModel.Email,
                        FullName = userModel.FullName,
                        PhoneNumber = userModel.PhoneNumber
                    };

                    var createUserResult = userManager.Create(user, userModel.Password);
                    if (createUserResult.Succeeded)
                    {
                        var addToRoleResult = userManager.AddToRole(user.Id, userModel.Role);
                        if (!addToRoleResult.Succeeded)
                        {
                            userManager.Delete(user);
                        }
                    }
                }
            }
        }
    }
}
