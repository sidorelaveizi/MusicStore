using MusicStore.Domain.Concrete;
using MusicStore.Domain.Entities;
using MusicStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MusicStore.Domain.Abstract
{
    public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
    {
        private readonly ApplicationDbContext _context;
        public int PageSize = 4;
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

         // GET: SearchFunctionality
        public IEnumerable<Album> SearchAlbum(string searchString)
        {
            var albums = from a in _context.Albums
                         select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                albums = albums.Where(a => a.Title.Contains(searchString));
            }
            return albums;
        }
        public void DeleteAlbum(int albumID)
        {
            Album album = _context.Albums.Find(albumID);
            _context.Albums.Remove(album);
        }

        //        public AlbumListViewModel Paging(int page = 1)
        //        {
        //           int PageSize = 4;
        //            AlbumListViewModel model = new AlbumListViewModel
        //            {
        //                Albums = _context.Albums
        //.OrderBy(p => p.AlbumId)
        //.Skip((page - 1) * PageSize)
        //.Take(PageSize),

        //                int maxRows = 10;

        //            AlbumListViewModel customerModel = new AlbumListViewModel();
        //            List<Album> albums = new List<Album>();

        //            customerModel.Albums = (from album in albums
        //                                    select albums)
        //                            .OrderBy(album => albums).
        //                            .Skip((page - 1) * maxRows)
        //                            .Take(maxRows).ToList();

        //            double pageCount = (double)((decimal)entities.Customers.Count() / Convert.ToDecimal(maxRows));
        //            customerModel.PageCount = (int)Math.Ceiling(pageCount);

        //            customerModel.CurrentPageIndex = page;

        //            return customerModel;
        //        }



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
