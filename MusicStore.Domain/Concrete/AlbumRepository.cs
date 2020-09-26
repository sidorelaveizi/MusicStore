using MusicStore.Domain.Concrete;
using MusicStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicStore.Domain.Abstract
{
    public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
    {
        private readonly ApplicationDbContext _context;
        public AlbumRepository(ApplicationDbContext context) 
        {
            _context = context;

        }
       
       public IEnumerable<Album> GetAlbumsByGenre(int id)
        {
            List<Album> albums = new List<Album>();
           
            albums= _context.Albums.Where(g => g.GenreId == id).ToList();

            return albums;
        }

        //Search album by title
        public IEnumerable<Album> SearchAlbum(string searchString)
        {
            var albums = from a in _context.Albums
                         select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                albums = albums.Where(a => a.Title.Contains(searchString));
            }
            return albums;
            //return this.Context.Albums.Where(x => x.Title.Contains(searchString));
        }



        public Genre GetByName(string genre)
        {

            // Retrieve Genre and its Associated Albums from database
            var genreModel = _context.Genres.Include("Albums")
                .Single(g => g.Name == genre);

            return genreModel;
        }
        

        //public ApplicationDbContext Context {
        //    get
        //    {
        //        return this.context as ApplicationDbContext;
        //    }
        //}


    }
}
