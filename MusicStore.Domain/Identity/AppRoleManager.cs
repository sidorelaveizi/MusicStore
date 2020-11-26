using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using MusicStore.Domain.Concrete;
using System;

namespace MusicStore.Domain.Identity
{
    public class AppRoleManager : RoleManager<AppRole>, IDisposable
    {
        public AppRoleManager(RoleStore<AppRole> store)
        : base(store)
        {
        }
        public static AppRoleManager Create(
        IdentityFactoryOptions<AppRoleManager> options,
        IOwinContext context)
        {
            return new AppRoleManager(new
            RoleStore<AppRole>(context.Get<ApplicationDbContext>()));
        }
    }
}
