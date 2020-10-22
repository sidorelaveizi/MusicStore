using System;

namespace MusicStore.Domain.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IAlbumRepository Albums { get; }
        IGenreRepository Genres { get; }
        IArtistRepository Artists { get; }
        ICartRepository Cart { get; }
        IOrderRepository Orders { get; }
        IOrderDetailsRepository OrdersDetails { get; }
        int Save();
        

    }
}
