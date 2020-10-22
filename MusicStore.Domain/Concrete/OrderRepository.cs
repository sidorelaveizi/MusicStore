using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;

namespace MusicStore.Domain.Concrete
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
