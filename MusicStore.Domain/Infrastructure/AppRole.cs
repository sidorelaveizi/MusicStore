using Microsoft.AspNet.Identity.EntityFramework;

namespace MusicStore.Domain.Infrastructure
{
    public class AppRole : IdentityRole
    {
        public AppRole() : base() { }
        public AppRole(string name) : base(name) { }
    }
}
