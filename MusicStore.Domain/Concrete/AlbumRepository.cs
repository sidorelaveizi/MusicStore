using MusicStore.Domain.Concrete;
using MusicStore.Domain.Entities;
using MusicStore.Domain.Models;
using PagedList;
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

            albums = _context.Albums.Where(g => g.GenreId == id).ToList();

            return albums;
        }

        // GET: Search Functionality and pagination
        public IEnumerable<Album> SearchAlbum(string searchString, int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 18;

            var albums = _context.Albums
            .Include("Artist").ToList();
            if (!String.IsNullOrEmpty(searchString))
            {   
            albums= albums.Where(a => a.Title.ToLower().Contains(searchString.ToLower()) ||
            a.Artist.Name.ToString().ToLower().Contains(searchString.ToLower())
             || a.Price.ToString().Contains(searchString)).ToList();
              
            }    
            return albums.ToPagedList(pageNumber, pageSize);
        }


        public void DeleteAlbum(int albumID)
        {
            Album album = _context.Albums.Find(albumID);
            _context.Albums.Remove(album);
        }      
        public List<AdminViewModel> GetAlbums(List<AdminViewModel> model)
        {
            var album = GetAllAlbums();
            foreach (var item in album)
            {
                AdminViewModel avm = new AdminViewModel();
                avm.Title = item.Title;
                avm.AlbumId = item.AlbumId;
                avm.Artist = _context.Artists.Where(i => i.ArtistId == item.ArtistId)?.FirstOrDefault().Name;
                avm.Genre = _context.Genres.Where(i => i.GenreId == item.GenreId)?.FirstOrDefault().Name;
                model.Add(avm);
            }
            return model;
        }

        public AlbumDetailView GetAlbumDetails(int id)
        {
            Album album = GetAlbumById(id);
            AlbumDetailView model = new AlbumDetailView()
            {
                ArtistName = GetArtistById(album.ArtistId).Name,
                GenreName = GetGenreById(album.GenreId).Name,
                Price = album.Price,
                AlbumTitle = album.Title,
                AlbumArtUrl = album.AlbumArtUrl,
                Album = GetAlbumById(album.AlbumId)
            };
            return model;
        }


        public Artist GetArtistById(int id)
        {
            return _context.Artists.Where(i => i.ArtistId == id)?.FirstOrDefault();
        }

        public Album GetAlbumById(int id)
        {
            return _context.Albums.Where(i => i.AlbumId == id)?.FirstOrDefault();
        }

        public Genre GetGenreById(int id)
        {
            return _context.Genres.Where(i => i.GenreId == id)?.FirstOrDefault();
        }
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
