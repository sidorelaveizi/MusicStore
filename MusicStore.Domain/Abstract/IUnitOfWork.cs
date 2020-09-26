using System;

namespace MusicStore.Domain.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        

        IAlbumRepository Albums { get; }
        IGenreRepository Genres { get; }

        IShoppingRepository Carts { get; }

        ICartRepository Cart { get; }

        int Save();
        

    }
}
