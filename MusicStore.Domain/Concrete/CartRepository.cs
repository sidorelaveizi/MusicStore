using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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
       

        public void AddItem(Album album, int quantity)
        {
            CartLine line = lineCollection
.Where(a => a.Albums.AlbumId == album.AlbumId)
.FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Albums = album,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        //private List<CartLine> lineCollection = new List<CartLine>();
        //public void AddItem(Album album, int quantity)
        //{
        //    List<CartLine> lineCollection = new List<CartLine>();
        //    CartLine line = lineCollection
        //    .Where(a => a.Albums.AlbumId == album.AlbumId)
        //    .FirstOrDefault();
        //    if (line == null)
        //    {
        //        lineCollection.Add(new CartLine
        //        {
        //            Albums = album,
        //            Quantity = quantity
        //        });
        //    }
        //    else
        //    {
        //        line.Quantity += quantity;
        //    }
        //}



        public void Clear()
        {
            throw new NotImplementedException();
        }

        public decimal ComputeTotalValue()
        {
            throw new NotImplementedException();
        }

        public void RemoveLine(Album album)
        {
            lineCollection.RemoveAll(a => a.Albums.AlbumId == album.AlbumId);
        }
    }
}
