using MusicStore.Domain.Entities;
using System.Collections.Generic;

namespace MusicStore.Domain.Abstract
{
    public interface IAlbumRepository : IGenericRepository<Album>
    {
         Genre GetGenre(int AlbumId);

         Artist GetArtist(int AlbumId);

        IEnumerable<Album> GetAlbumByGenre(int id);

    }
}
