using MusicStore.Domain.Entities;
using MusicStore.Domain.Models;
using System.Collections.Generic;

namespace MusicStore.Domain.Abstract
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        IEnumerable<Order> FilterOrder(string searchString, int? page);
        List<OrderItemsViewModel> GetOrderDetail(int id);

        List<OrderViewModel> MyOrders(string id);

    }
}
