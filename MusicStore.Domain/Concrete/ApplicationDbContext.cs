using Microsoft.AspNet.Identity.EntityFramework;
using MusicStore.Domain.Entities;
using MusicStore.Domain.Infrastructure;
using System.Data.Entity;

namespace MusicStore.Domain.Concrete
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {

        public ApplicationDbContext(): base("MusicDb")
        {
            this.Configuration.AutoDetectChangesEnabled = true;
            this.Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer(new ApplicationDbInitializer());
        }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Artist> Artists { get; set; }
       
        //public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        //public DbSet<CartLine> CartLines { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }


        static ApplicationDbContext()
        {
            Database.SetInitializer<ApplicationDbContext>(new IdentityDbInit());
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
    public class IdentityDbInit
    : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            PerformInitialSetup(context);
            base.Seed(context);
        }
        public void PerformInitialSetup(ApplicationDbContext context)
        {
            //AppUserManager userMgr = new AppUserManager(new UserStore<AppUser>(context));
            //AppRoleManager roleMgr = new AppRoleManager(new RoleStore<AppRole>(context));
            //string roleName = "Administrators";
            //string userName = "Admin";
            //string password = "MySecret";
            //string email = "admin@example.com";
            //if (!roleMgr.RoleExists(roleName))
            //{
            //    roleMgr.Create(new AppRole(roleName));
            //}
            //AppUser user = userMgr.FindByName(userName);
            //if (user == null)
            //{
            //    userMgr.Create(new AppUser { UserName = userName, Email = email },
            //    password);
            //    user = userMgr.FindByName(userName);
            //}
            //if (!userMgr.IsInRole(user.Id, roleName))
            //{
            //    userMgr.AddToRole(user.Id, roleName);
            //}
        }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //implementimi i membership
        //    //modelBuilder.Entity<User>()
        //    //   .HasMany(u => u.Roles)
        //    //   .WithMany(r => r.Users)
        //    //   .Map(m =>
        //    //   {
        //    //       m.ToTable("UserRoles");
        //    //       m.MapLeftKey("UserId");
        //    //       m.MapRightKey("RoleId");
        //    //   });
        //    base.OnModelCreating(modelBuilder);
        //}
    }
    }
