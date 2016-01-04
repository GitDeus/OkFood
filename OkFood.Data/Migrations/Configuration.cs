namespace OkFood.Data.Migrations
{
    using Domain.Model.Entities;
    using Identity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OkFood.Data.Context.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = true;

        }

        protected override void Seed(OkFood.Data.Context.DataContext context)
        {

            //var saveRoles = false;
            //// Create the admin role if it doesn't exist
            //var adminRole = context.Roles.FirstOrDefault(x => x.Name == "Manager");
            //if (adminRole == null)
            //{
            //    adminRole = new Domain.Model.Entities.Role { Name = "Manager" };
            //    context.Roles.Add(adminRole);
            //    saveRoles = true;
            //}

            //// Create the Standard role if it doesn't exist
            //var standardRole = context.Roles.FirstOrDefault(x => x.Name == "User");
            //if (standardRole == null)
            //{
            //    standardRole = new Domain.Model.Entities.Role { Name = "User" };
            //    context.Roles.Add(standardRole);
            //    saveRoles = true;
            //}

            //if (saveRoles)
            //{
            //    context.SaveChanges();
            //}


            //// If the admin user exists then don't do anything else
            //const string adminUsername = "Manager";
            //if (context.Users.FirstOrDefault(x => x.UserName == adminUsername) == null)
            //{
            //    // create the admin user and put him in the admin role
            //    var admin = new User
            //    {
            //        UserId = Guid.Empty,
            //        UserName = adminUsername,
            //        PasswordHash = "password"
            //    };

            //    // Put the admin in the admin role
            //    admin.Roles = new List<Role> { adminRole };

            //    context.Users.Add(admin);
            //    context.SaveChanges();
            //    const string readMeText = @"cvxcxvxcvxcvxc";

            //    // Now add read me
            //    const string name = "Read Me";
            //    var category = context.DbCategories.FirstOrDefault(s=>s.Title == name);
            //    var sub = new Subcategory
            //    {

            //        Id = Guid.NewGuid(),
            //        Category = category,
            //        Date= DateTime.UtcNow,
            //        CategoryId  = category.Id,
            //        Title = readMeText,
            //        Value = decimal.Add(1488,228),
                    
            //    };

            //    context.DbSubcategories.Add(sub);
            //    context.SaveChanges();

            //}

        }        
    }
}
