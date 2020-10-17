using MusicStore.Domain.Entities;
using System.Collections.Generic;

namespace MusicStore.Domain.Abstract
{
    public interface IOrderInterface : IGenericRepository<Order>
    {
        IEnumerable<Order> GetOrders();
        void Complete(int id);
    }
}
