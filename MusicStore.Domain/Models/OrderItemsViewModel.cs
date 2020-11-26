using System.Collections.Generic;

namespace MusicStore.Domain.Models
{
    public class OrderItemsViewModel
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int AlbumId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string AlbumName { get; set; }
        public List<OrderViewModel> Order { get; set; }
        public decimal GetTotalCost()
        {
            return Quantity * UnitPrice;
        }

    }
}
