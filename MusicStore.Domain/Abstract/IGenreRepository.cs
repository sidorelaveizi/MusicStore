using MusicStore.Domain.Entities;
using System.Collections.Generic;

namespace MusicStore.Domain.Abstract
{
    public interface IGenreRepository : IGenericRepository<Genre>
    {
       IEnumerable<Album> GetAlbum(int GenreId);

        
    }
}
