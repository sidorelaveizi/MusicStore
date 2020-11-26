using Microsoft.AspNet.Identity.EntityFramework;

namespace MusicStore.Domain.Identity
{
    public class AppRole : IdentityRole
    {
        public AppRole() : base() { }
        public AppRole(string name) : base(name) { }
    }
}
