using MusicStore.Domain.Concrete;
using MusicStore.Domain.Entities;
using System;
using System.Collections.Generic;
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
            return this.Context.Albums.Where(g => g.GenreId == id).ToList();
        }

        public Genre GetByName(string genre)
        {

            // Retrieve Genre and its Associated Albums from database
            var genreModel = this.Context.Genres.Include("Albums")
                .Single(g => g.Name == genre);

            return genreModel;
        }
        //Searching
        public IEnumerable<Album> SearchAlbum(string searchString)
        {
            var albums = from a in this.Context.Albums
                         select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                albums = albums.Where(a => a.Title.Contains(searchString));
            }
            return albums;
            //return this.Context.Albums.Where(x => x.Title.Contains(searchString));
        }



        public ApplicationDbContext Context {
            get
            {
                return this.context as ApplicationDbContext;
            }
        }


    }
}
