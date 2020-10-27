using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MusicStore.WebUI.Controllers
{
    [Authorize(Roles = "Users")]
    public class CheckoutController : Controller
    {
        private readonly IUnitOfWork repo;
     
        public CheckoutController(IUnitOfWork work)
        {
            repo = work;
        }
        public ActionResult AddressAndPayment()
        {
            return View("AddressAndPayment");
        }

        //
        // POST: /Checkout/AddressAndPayment
        //[HttpPost]
        public ActionResult ProcessOrder(FormCollection form)
        {
            if (ModelState.IsValid)
            {
                List<CartLine> cart = (List<CartLine>)Session["cart"];
                Order order = new Order()
                {
                    FirstName = form["FirstName"],
                    LastName = form["LastName"],
                    Address = form["Address"],
                    City = form["City"],
                    State = form["State"],
                    Country = form["Country"],
                    PostalCode = form["PostalCode"],
                    Phone = form["Phone"],
                    Email = form["Email"],
                    OrderDate = DateTime.Now
                };
                repo.Orders.Insert(order);
                repo.Save();

               
                foreach (CartLine item in cart)
                {
                    OrderDetail orderDetail = new OrderDetail()
                    {
                        OrderId = order.OrderId,
                        Quantity = item.Quantity,
                        AlbumId = item.Album.AlbumId,
                        UnitPrice = item.Album.Price
                    };
                    repo.OrdersDetails.Insert(orderDetail);
                    repo.Save();
                }
                Session.Remove("cart");
            }


            return View("Complete");
           
        }
         
            // GET: /Checkout/Complete
            public ActionResult CompleteOrder()
        { 
            return View();
        }
    }
}