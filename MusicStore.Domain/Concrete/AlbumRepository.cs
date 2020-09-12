using MusicStore.Domain.Concrete;
using MusicStore.Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MusicStore.Domain.Abstract
{
    public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
    {

        public AlbumRepository(ApplicationDbContext context) : base(context)
        {

        }
        public Artist GetArtist(int AlbumId)
        {
            return this.Context.Albums.Find(AlbumId).Artist;

           
        }

         public Genre GetGenre(int AlbumId)
        {

            return this.Context.Albums.Find(AlbumId).Genre;
        }

       public IEnumerable<Album> GetAlbumByGenre(int id)
        {
            return this.Context.Albums
               .Where(g => g.GenreId == id)
               .Include(p => p.AlbumId)
               .ToList();
        }

        public ApplicationDbContext Context {
            get
            {
                return this.context as ApplicationDbContext;
            }
        }
    }
}
