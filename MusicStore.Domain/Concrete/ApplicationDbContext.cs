using Microsoft.AspNet.Identity.EntityFramework;
using MusicStore.Domain.Entities;
using MusicStore.Domain.Identity;
using System.Data.Entity;

namespace MusicStore.Domain.Concrete
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Genre> Genres { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public ApplicationDbContext() : base("MusicDb")
        {
   
        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
    
