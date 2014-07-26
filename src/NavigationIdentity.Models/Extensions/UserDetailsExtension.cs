
using System;

namespace NavigationIdentity.Models.Extensions
{
   public static class UserDetailsExtension
   {

      public static string GetFullName(this UserDetails userDetails)
      {
         if (userDetails == null) { return String.Empty; }
         return ((userDetails.FirstName ?? "") + " " + (userDetails.LastName ?? "")).Trim();
      }

   }
}
