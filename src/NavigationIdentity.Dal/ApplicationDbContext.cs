using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using NavigationIdentity.Dal.Configurations;
using NavigationIdentity.Models;

namespace NavigationIdentity.Dal
{
   public class ApplicationDbContext 
      : IdentityDbContext<ApplicationUser>
   {

      // Declare additional custom properties
      public DbSet<UserDetails> UserDetails { get; set; }


      #region CTORs
      public ApplicationDbContext()
         : base("DefaultConnection", throwIfV1Schema: false)
      {
      }


      static ApplicationDbContext()
      {
         Database.SetInitializer(new ApplicationDbInitializer());
      }
      #endregion CTORs


      public static ApplicationDbContext Create()
      {
         return new ApplicationDbContext();
      }


      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
         // Configure relationships/attributes
         modelBuilder.Configurations.Add(new UserDetailsConfiguration());
         base.OnModelCreating(modelBuilder);
      }
   }
}
