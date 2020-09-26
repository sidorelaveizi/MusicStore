using MusicStore.Domain.Entities;
using System.Collections.Generic;

namespace MusicStore.Domain.Abstract
{
    public interface IAlbumRepository : IGenericRepository<Album>
    {
        Genre GetByName(string genre);

        IEnumerable<Album> GetAlbumsByGenre(int id);


        IEnumerable<Album> SearchAlbum(string searchString);


    }
}
