using MusicStore.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MusicStore.Domain.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<OrderItemsViewModel> OrderItems { get; set; }
    }
}
