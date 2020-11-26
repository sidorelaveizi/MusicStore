using Microsoft.AspNet.Identity;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MusicStore.WebUI.Controllers
{
    [Authorize(Roles = "User")]
    public class CheckoutController : Controller
    {
        private readonly IUnitOfWork repo;
        const string PromoCode = "FREE";


        public CheckoutController(IUnitOfWork work)
        {
            repo = work;
        }
        // GET: /Checkout/CheckoutDetails
        public ActionResult CheckoutDetails()
        {
            return View("CheckoutDetails");

        }
        //
        // POST: /Checkout/CheckoutDetails
        [HttpPost]
        public ActionResult ProcessOrder(FormCollection form)
        {
            if (ModelState.IsValid)
            {
                decimal unitPrice = -1;
                var code = form["PromoCode"].ToLower();

                if (!string.IsNullOrEmpty(code) && code.Contains("free"))
                {
                    unitPrice = 0;
                }
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
                    UserId = User.Identity.GetUserId(),
                    OrderDate = DateTime.Now,
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
                        UnitPrice = unitPrice==0?0:item.Album.Price
                    };
                    repo.OrdersDetails.Insert(orderDetail);
                    repo.Save();
                }
                Session.Remove("cart");
            }
            return View("Complete");
        }
         
    }
}