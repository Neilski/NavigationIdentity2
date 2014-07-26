using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NavigationIdentity.Models;

namespace NavigationIdentity.Dal
{
   public class ApplicationDbInitializer
      : CreateDatabaseIfNotExists<ApplicationDbContext>
   {
      protected override void Seed(ApplicationDbContext context)
      {
         InitializeIdentityForEf(context);
         base.Seed(context);
      }


      // Create User=Administrator@admin.com with
      // password=password-123 in the Admin role
      public static void InitializeIdentityForEf(ApplicationDbContext db)
      {
         const string name = "Administrator";
         const string email = "administrator@admin.com";
         const string password = "password-123";
         const string roleName = "Admin";

         var store = new UserStore<ApplicationUser>(db);
         var userManager = new UserManager<ApplicationUser>(store);
         var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

         //Create Role Admin if it does not exist
         var role = roleManager.FindByName(roleName);
         if (role == null)
         {
            role = new IdentityRole(roleName);
            roleManager.Create(new IdentityRole(roleName));
         }

         var user = userManager.FindByName(name);
         if (user == null)
         {
            user = new ApplicationUser
            {
               UserName = name,
               Email = email,
               UserDetails = new UserDetails
               {
                  FirstName = "System",
                  LastName = "Administrator",
                  Gender = Gender.Male,
                  DateOfBirth = new DateTime(2000, 1, 1)
               }
            };
            userManager.Create(user, password);
         }

         // Add user admin to role Admin if not already added
         var rolesForUser = userManager.GetRoles(user.Id);
         if (!rolesForUser.Contains(role.Name))
         {
            userManager.AddToRole(user.Id, role.Name);
         }
      }

   }
}
