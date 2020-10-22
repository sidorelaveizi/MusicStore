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

        public ActionResult Buy(int id)
        {
            Album album = repo.Albums.GetAlbumById(id);

            if (Session["cart"] == null)
            {
                List<CartLine> cart = new List<CartLine>();
                cart.Add(new CartLine
                {
                    Album = album,
                    Quantity = 1
                });
                
                ViewBag.count = cart.Count();
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
                    cart.Add(new CartLine { Album = album, Quantity = 1 });
                }
                ViewBag.count = cart.Count();
                Session["cart"] = cart;
            }

            return View();


            //return RedirectToAction("Index");
        }
        public ActionResult Remove(int id)
        {
            List<CartLine> cart = (List<CartLine>)Session["cart"];
            int index = IsExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index", "Home");
            //return RedirectToAction("Buy", "Cart");
        }
        private int IsExist(int id)
        {
            List<CartLine> cart = (List<CartLine>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Album.AlbumId.Equals(id))
                    return i;
            return -1;
        }

        public ActionResult CartSummary(CartLine cart)
        {
            
            return View(cart);
        }



    }
}
