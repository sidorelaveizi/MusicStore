using System;

namespace MusicStore.Domain.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IAlbumRepository Albums { get; }
        IGenreRepository Genres { get; }
        IArtistRepository Artists { get; }

        //IUserRepository Users { get; }

        ICartRepository Cart { get; }
        IOrderInterface Orders { get; }
        IOrderDetailsRepository OrdersDetails { get; }
        int Save();
        

    }
}
