using MusicStore.Domain.Abstract;
using System.Data;
using System.Net;
using System.Web.Mvc;

namespace MusicStore.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUnitOfWork repo;

        public OrderController(IUnitOfWork work)
        {
            repo = work;
        }
        // GET: Order
        public ActionResult Index(string searchString, int? page)
        {
            var orderList = repo.Orders.FilterOrder(searchString, page); 
            return View(orderList);
        }

       
        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            var order = repo.Orders.GetOrderDetail(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            return View(order);
        }


        // GET: Order/Delete/5
        public ActionResult Delete(int? id)
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
        public ActionResult Delete(int id)
        {
            try
            {
                var order = repo.Orders.GetById(id);
                repo.Orders.Delete(id);
                repo.Save();
            }
            catch (DataException)
            {

                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }


    }
}
