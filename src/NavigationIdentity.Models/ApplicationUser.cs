using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;
using NavigationIdentity.Models.Interfaces;

namespace NavigationIdentity.Models
{
   [MetadataType(typeof(IApplicationUser))]
   public class ApplicationUser 
      : IdentityUser, IApplicationUser
   {

      // Navigation Properties
      public virtual UserDetails UserDetails { get; set; }

   }
}
