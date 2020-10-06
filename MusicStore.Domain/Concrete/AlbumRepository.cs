using MusicStore.Domain.Concrete;
using MusicStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public void DeleteAlbum(int albumID)
        {
            Album album = _context.Albums.Find(albumID);
            _context.Albums.Remove(album);
        }

        //public List<AdminViewModel> GetAlbums(List<AdminViewModel> model)
        //{
        //    //List<Album> albums = new List<Album>();

        //    var album = GetAllAlbums();
        //    //albums = _context.Albums.Select(i => i).ToList();
        //    foreach (var item in album)
        //    {
        //        AdminViewModel avm = new AdminViewModel();
        //        avm.Title = item.Title;
        //        avm.AlbumId = item.AlbumId;
        //        avm.Artist = _context.Artists.Where(i =>i.ArtistId == item.ArtistId)?.FirstOrDefault().Name;
        //        avm.Genre = _context.Genres.Where(i => i.GenreId == item.GenreId)?.FirstOrDefault().Name;
        //        model.Add(avm);

        //    }

        //    return model;
        //}

        public List<Album> GetAllAlbums()
        {
            return _context.Set<Album>().ToList();
        }

       public List<Genre> GetGenres()
        {

            return _context.Genres.ToList();
        }
        public List<Artist> GetArtist()
        {

            return _context.Artists.ToList();
        }
        public void InsertAlbum(Album album)
        {
            _context.Albums.Add(album);
        }
       public void UpdateAlbum(Album album)
        {
            _context.Entry(album).State = EntityState.Modified;
        }

    }
}
