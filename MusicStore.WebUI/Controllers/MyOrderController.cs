using Microsoft.AspNet.Identity;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Concrete;
using System.Data;
using System.Net;
using System.Web.Mvc;

namespace MusicStore.WebUI.Controllers
{
    public class MyOrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MyOrderController(ApplicationDbContext context)
        {
            _context = context;

        }
        private readonly IUnitOfWork repo;

        public MyOrderController(IUnitOfWork work)
        {
            repo = work;
        }
        // GET: MyOrder
        [Authorize]
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var myOrder = repo.Orders.MyOrders(id);
            return View(myOrder);
        }
        // GET: Order/Delete/5
        public ActionResult CancelOrder(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var order = repo.Orders.GetById(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult CancelOrder(int id)
        {
            try
            {
                var order = repo.Orders.GetById(id);
                repo.Orders.Delete(id);
                repo.Save();
            }
            catch (DataException)
            {

                return RedirectToAction("CancelOrder", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var order = repo.Orders.GetOrderDetail(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            return View(order);
        }


    }
}