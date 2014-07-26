using System.Data.Entity.ModelConfiguration;
using NavigationIdentity.Models;

namespace NavigationIdentity.Dal.Configurations
{
   public class UserDetailsConfiguration
      : EntityTypeConfiguration<UserDetails>
   {
      public UserDetailsConfiguration()
      {
         ToTable("AspNetUserDetails");
         HasKey(x => x.Id);
         HasRequired(e => e.User)
            .WithRequiredDependent(e => e.UserDetails)
            .WillCascadeOnDelete();
      }
   }
}
