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
    }
}
