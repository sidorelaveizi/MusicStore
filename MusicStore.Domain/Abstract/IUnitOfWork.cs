using System;

namespace MusicStore.Domain.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IAlbumRepository Albums { get;}
        IGenreRepository Genres { get; }
        
        int Save();
        //void Commit();

    }
}
