using MusicStore.Domain.Entities;
using System.Collections.Generic;


namespace MusicStore.Domain.Abstract
{
    public interface IAlbumRepository : IGenericRepository<Album>
    {

        IEnumerable<Album> GetAlbumsByGenre(int id);


        IEnumerable<Album> SearchAlbum(string searchString);

        void DeleteAlbum(int albumID);

        //List<AdminViewModel> GetAlbums(List<AdminViewModel> model);
        List<Album> GetAllAlbums();
        List<Genre> GetGenres();
        List<Artist> GetArtist();
        void InsertAlbum(Album album);
        void UpdateAlbum(Album album);

        //void PopulateGenreDropDownList(object selectedDepartment = null

    }
}
