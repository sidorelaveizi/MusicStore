using MusicStore.Domain.Concrete;
using MusicStore.Domain.Entities;
using System.Collections.Generic;

namespace MusicStore.Domain.Abstract
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        private readonly ApplicationDbContext _context;
        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Album> GetAlbum(int GenreId)
        {
          return _context.Genres.Find(GenreId).Albums;
           
            //var data = this.Context.Albums;
            //return null;


        }
        //public ApplicationDbContext Context
        //{
        //    get
        //    {
        //        return this.context as ApplicationDbContext;
        //    }
        //}
    }
}
