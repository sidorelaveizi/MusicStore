using MusicStore.Domain.Concrete;
using MusicStore.Domain.Entities;
using System.Collections.Generic;

namespace MusicStore.Domain.Abstract
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext context) : base(context)
        {

        }
        public IEnumerable<Album> GetAlbum(int GenreId)
        {
            //return Context.Genres.Find(GenreId).Albums;
            var data = this.Context.Albums;
            return null;
            

        }
        public ApplicationDbContext Context
        {
            get
            {
                return this.context as ApplicationDbContext;
            }
        }
    }
}
