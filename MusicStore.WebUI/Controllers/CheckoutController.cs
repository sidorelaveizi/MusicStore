using MusicStore.Domain.Abstract;
using System.Web.Mvc;

namespace MusicStore.WebUI.Controllers
{
    public class CheckoutController : Controller
    {

        private readonly IUnitOfWork repo;
        private const string PromoCode = "FREE";

        public CheckoutController(IUnitOfWork work)
        {
            repo = work;
        }
        // GET: Checkout
        public ActionResult AddressAndPayment()
        {
            return View();
        }

        // POST: /Checkout/AddressAndPayment
        //[HttpPost]
        //public ActionResult AddressAndPayment(FormCollection values)
        //{
        //    var order = new Order();
        //    TryUpdateModel(order);
        //    try
        //    {
        //        //judge PromoCode
        //        if (!string.Equals(values["PromoCode"], PromoCode, StringComparison.OrdinalIgnoreCase))
        //        {
        //            return View(order);
        //        }
        //        else
        //        {
        //            order.Username = User.Identity.Name;
        //            order.OrderDate = DateTime.Now;
        //            //Save Order
        //            storeDB.Orders.Add(order);
        //            storeDB.SaveChanges();
        //            //Process the order
        //            var cart = ShoppingCart.GetCart(this.HttpContext);
        //            cart.CreateOrder(order);
        //            return RedirectToAction("Complete", new { id = order.OrderId });
        //        }
        //    }
        //    catch
        //    {
        //        //Invalid - redisplay with errors
        //        return View(order);
        //    }
        //}
        //
        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {
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