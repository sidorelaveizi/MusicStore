using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using System.Collections.Generic;

namespace MusicStore.Domain.Concrete
{
    public class CartRepository : GenericRepository<CartLine>, ICartRepository
    {
        private readonly ApplicationDbContext _context;
        
        private readonly List<CartLine> lineCollection = new List<CartLine>();
        public CartRepository(ApplicationDbContext context)
        {
            _context= context;

        }
       
        //public void AddItem(Album album, int quantity)
        //{
        //    CartLine line = lineCollection
        //   .Where(a => a.Album.AlbumId == album.AlbumId)
        //   .FirstOrDefault();
        //    if (line == null)
        //    {
        //        lineCollection.Add(new CartLine
        //        {
        //            Album = album,
        //            Quantity = quantity
        //        });
        //    }
        //    else
        //    {
        //        line.Quantity += quantity;
        //    }
        //}

        //public void Clear()
        //{
        //    throw new NotImplementedException();
        //}

        //public void RemoveLine(Album album)
        //{
        //    lineCollection.RemoveAll(a => a.Album.AlbumId == album.AlbumId);
        //}
    }
}
