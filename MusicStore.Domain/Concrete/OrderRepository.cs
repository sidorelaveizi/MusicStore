﻿using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MusicStore.Domain.Concrete
{
    public class OrderRepository : GenericRepository<Order>, IOrderInterface
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<Order> GetOrders()
        {
            return null;
            //return _context.Orders.Where(o => o.Username == User.Identity.Name);
        }

        public bool isValid(int id)
        {
            bool isValid = _context.Orders.Any(
            o => o.OrderId == id);
            if (isValid)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
