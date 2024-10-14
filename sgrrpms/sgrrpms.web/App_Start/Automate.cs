using Model;
using sgrrpms.AppDbContext;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace App_Start
{
    public class Automate
    {
        public static void CreateRoles()
        {
            using (var context = new ApplicationDb())
            {
                if (!context.Roles.Any())
                {
                    string role = ConfigurationManager.AppSettings["Roles"];
                    string[] roles = role.Split(',');

                    foreach (var item in roles)
                    {
                        var model = new Role
                        {
                            Title = item,
                            CreatedBy = "SuperAdmin",
                            CreatedOn = DateTime.Now,
                            EditedOn = DateTime.Now,
                            Status = true,
                        };
                        context.Roles.Add(model);
                    }

                    context.SaveChanges();
                }
            }
        }
        public static void CreateAdminUser()
        {
            using (var context = new ApplicationDb())
            {
                var admin = Convert.ToString(ConfigurationManager.AppSettings["AdminEmail"]);
                if (context.User.FirstOrDefault(x => x.Email == admin) == null)
                {
                    string adminPassword = ConfigurationManager.AppSettings["AdminPassword"];
                    var user = new User
                    {
                        Name = ConfigurationManager.AppSettings["AdminName"].ToString(),
                        CreatedOn = DateTime.Now,
                        EditedOn = DateTime.Now,
                        CreatedBy = "SuperAdmin",
                        Email = ConfigurationManager.AppSettings["AdminEmail"].ToString(),
                        HashPassword = adminPassword,
                        Status = true,
                    };
                    context.User.Add(user);
                    context.SaveChanges();
                    var userRole = new RoleAssign
                    {
                        UserId = user.Id,
                        RoleId = context.Roles.FirstOrDefault(x => x.Title == "SuperAdmin").Id,
                        CreatedBy = "SuperAdmin",
                        CreatedOn = DateTime.Now,
                        EditedOn = DateTime.Now,
                        Status = true,
                    };
                    context.RoleAssign.Add(userRole);
                    context.SaveChanges();
                }
            }
        }
    }
}