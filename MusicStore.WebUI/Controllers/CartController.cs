using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MusicStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly IUnitOfWork repo;

        public CartController(IUnitOfWork work)
        {
            repo = work;
        }

        public ActionResult Index()
        {        
            return View();
        }

        public ActionResult Buy(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            if (Session["cart"] == null)
            {
                List<CartLine> cart = new List<CartLine>();
                cart.Add(new CartLine
                {
                    Album = repo.Albums.GetById(id),
                    Quantity = 1
                });
                ViewBag.count = cart.Sum(q => q.Quantity);
                Session["cart"] = cart;
            }
            else
            {
                List<CartLine> cart = (List<CartLine>)Session["cart"];
                int index = IsExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new CartLine { Album = repo.Albums.GetById(id), Quantity = 1 });
                }
                Session["cart"] = cart;
                ViewBag.count = cart.Sum(q => q.Quantity);            
            }

            return View("Index");
        }
        public ActionResult Remove(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            List<CartLine> cart = (List<CartLine>)Session["cart"];
            int index = IsExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index", "Cart");
        }
        private int IsExist(int? id)
        {
            List<CartLine> cart = (List<CartLine>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Album.AlbumId.Equals(id))
                    return i;
            return -1;
        }

    }
}
