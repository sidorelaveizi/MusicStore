using MusicStore.Domain.Entities;
using MusicStore.Domain.Models;
using System.Collections.Generic;

namespace MusicStore.Domain.Abstract
{
    public interface IAlbumRepository : IGenericRepository<Album>
    {

        IEnumerable<Album> GetAlbumsByGenre(int id);


        IEnumerable<Album> SearchAlbum(string searchString, int? page);

        void DeleteAlbum(int albumID);

        List<AdminViewModel> GetAlbums(List<AdminViewModel> model);

        AlbumDetailView GetAlbumDetails(int id);
        List<Album> GetAllAlbums();

        Album GetAlbumById(int id);
        List<Genre> GetGenres();
        List<Artist> GetArtist();
        void InsertAlbum(Album album);
        void UpdateAlbum(Album album);
        Artist GetArtistById(int id);
        Genre GetGenreById(int id);
    }
}
