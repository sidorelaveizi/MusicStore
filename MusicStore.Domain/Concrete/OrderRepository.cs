using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using MusicStore.Domain.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicStore.Domain.Concrete
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Order> FilterOrder(string searchString, int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 10;

            var orders = _context.Orders.ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(o => o.FirstName.ToLower().Contains(searchString.ToLower()) || o.OrderDate.ToString().Contains(searchString.ToUpper()) || o.Email.Contains(searchString.ToLower()) || o.Total.ToString().Contains(searchString.ToLower()) || searchString == null).ToList();
            }
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (var order in orders)
            {
                
                orderDetails = _context.OrderDetails.Where(x => x.OrderId == order.OrderId).ToList();
                order.Total += orderDetails.Sum(o=>o.UnitPrice * o.Quantity);
                order.OrderDetails = orderDetails;
            }
            
            return orders.ToPagedList(pageNumber, pageSize);
        }

        public List<OrderItemsViewModel> GetOrderDetail(int id)
        {
            List<OrderItemsViewModel> list = new List<OrderItemsViewModel>();
            var orders = _context.OrderDetails.Where(x => x.OrderId == id).ToList();

            foreach (var item in orders)
            {
                OrderItemsViewModel avm = new OrderItemsViewModel();
                avm.AlbumName = _context.Albums.Where(i => i.AlbumId == item.AlbumId)?.FirstOrDefault().Title;
                avm.Quantity = item.Quantity;
                avm.UnitPrice = item.UnitPrice;
                avm.Order = _context.Orders.Where(x => x.OrderId == item.OrderId)
                .Select(x => new OrderViewModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,


                }).ToList();
                list.Add(avm);
            }
             return list;
        }
   
       public List<OrderViewModel> MyOrders(string id)
        {
            List<OrderViewModel> list = new List<OrderViewModel>();
            var order = _context.Orders.Where(x => x.UserId == id).ToList();
            foreach (var item in order)
            {
                OrderViewModel ovm = new OrderViewModel();
                ovm.OrderDate = item.OrderDate;
                ovm.Address = item.Address;
                ovm.Email = item.Email;
                ovm.FirstName = item.FirstName;
                ovm.UserId = item.UserId;
                ovm.OrderId = item.OrderId;
                ovm.City = item.City;
                ovm.LastName = item.LastName;
                ovm.PostalCode = item.PostalCode;
                ovm.Phone = item.Phone;
                ovm.OrderItems = _context.OrderDetails.Where(x => x.OrderId == item.OrderId)
                .Select(x=>new OrderItemsViewModel { 
                AlbumId = x.AlbumId,
                Quantity = x.Quantity,
                UnitPrice = x.UnitPrice,
                AlbumName = _context.Albums.Where(i => i.AlbumId == x.AlbumId).FirstOrDefault().Title,
            }).ToList();
                list.Add(ovm);
            }
            return list;        
        }

    }


    }

