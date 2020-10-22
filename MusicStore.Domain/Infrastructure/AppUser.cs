using Microsoft.AspNet.Identity.EntityFramework;

namespace MusicStore.Domain.Infrastructure
{
    public class AppUser : IdentityUser
    {
        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
        // UserManager<AppUser> manager)
        //{
        //    // Note the authenticationType must match the one defined in 
        //    //   CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = await manager.CreateIdentityAsync(this,
        //DefaultAuthenticationTypes.ApplicationCookie);

        //    return userIdentity;
        //}
    }
}
