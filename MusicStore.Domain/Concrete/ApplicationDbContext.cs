using MusicStore.Domain.Entities;
using System.Data.Entity;

namespace MusicStore.Domain.Concrete
{
    public class ApplicationDbContext : DbContext
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

       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
    }
