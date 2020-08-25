using Microsoft.AspNetCore.Identity;

namespace SaferSpacesClient.Models
{
  public class ApplicationUser : IdentityUser
  {
    // public IdentityUser (string userName);  IS THIS CORRECT?
  }
}

// https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.identityuser.-ctor?view=aspnetcore-2.2