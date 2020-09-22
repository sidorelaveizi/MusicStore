using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;

namespace MusicStore.Domain.Concrete
{
    class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {

        }
        //public override IEnumerable<Order> Find(Expression<Func<Order, bool>> predicate)
        //{
           
        //}
    }
}
