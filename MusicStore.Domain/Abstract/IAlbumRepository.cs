using MusicStore.Domain.Entities;
using System.Collections.Generic;

namespace MusicStore.Domain.Abstract
{
    public interface IAlbumRepository
    {
        IEnumerable<Album> Albums { get; }

        
    }
}
