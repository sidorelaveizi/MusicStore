using MusicStore.Domain.Entities;

namespace MusicStore.Domain.Abstract
{
    public interface ICartRepository : IGenericRepository<CartLine>
    {
        void AddItem(Album album, int quantity);
      // void AddToCart(int albumId);
        void RemoveLine(Album album);
        void Clear();
       

    }
}
