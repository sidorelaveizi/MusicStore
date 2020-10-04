using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MusicStore.WebUI.Controllers
{
    //[Authorize]
    public class CheckoutController : Controller
    {
        private readonly IUnitOfWork repo;
        private const string PromoCode = "FREE";

        public CheckoutController(IUnitOfWork work)
        {
            repo = work;
        }
        // GET: /Checkout/AddressAndPayment
        //public ActionResult AddressAndPayment()
        //{
        //    return View(new ShippingDetails());
        //}
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

                //1. Save the order into Order table
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

                //2. Save the order detail into Order Detail table
                foreach (CartLine item in cart)
                {
                    OrderDetail orderDetail = new OrderDetail()
                    {
                        OrderId = order.OrderId,
                        Quantity = item.Quantity,
                        AlbumId = item.Albums.AlbumId,
                        UnitPrice = item.Albums.Price
                    };
                    repo.OrdersDetails.Insert(orderDetail);
                    repo.Save();
                }
                Session.Remove("cart");


            }

            //var order = new Order();
            //TryUpdateModel(order);

            //try
            //{
            //    if (string.Equals(values["PromoCode"], PromoCode,
            //        StringComparison.OrdinalIgnoreCase) == false)
            //    {
            //        return View(order);
            //    }
            //    else
            //    {
            //        order.Username = User.Identity.Name;
            //        order.OrderDate = DateTime.Now;

            //        //Save Order
            //        repo.Orders.Insert(order);
            //        repo.Save();
            //        //Process the order
            //        var cart = ShoppingCart.GetCart(this.HttpContext);
            //        cart.CreateOrder(order);

            //        return RedirectToAction("Complete",
            //            new { id = order.OrderId });
            //    }
            //}
            //catch
            //{
            //    //Invalid - redisplay with errors
            //    return View(order);
            //}

            return View("Complete");
           
        }
         
            // GET: /Checkout/Complete
            public ActionResult Complete(int id)
        {

            repo.Orders.isValid(id);
            

            //// Validate customer owns this order
            //bool isValid = repo.Orders.Any(
            //o => o.OrderId == id &&
            //o.Username == User.Identity.Name);
            //if (isValid)
            //{
            //    return View(id);
            //}
            //else
            //{
            //    return View("Error");
            //}

            return View();
        }
    }
}