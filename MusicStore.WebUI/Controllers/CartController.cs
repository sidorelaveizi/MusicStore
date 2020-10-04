using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using System.Collections.Generic;
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


        public ActionResult AddToCart(int albumId)
        {
            Album albums = repo.Albums.GetById(albumId);
            if (Session["cart"] == null)
            {
                List<CartLine> cart = new List<CartLine>();
                //var album = repo.Albums.GetById(albumId);
                cart.Add(new CartLine()
                {
                    Albums = albums,
                    Quantity = 1

                });
                Session["cart"] = cart;
            }
            else
            {
                List<CartLine> cart = (List<CartLine>)Session["cart"];
                var album = repo.Albums.GetById(albumId);
                cart.Add(new CartLine()
                {
                    Albums = album,
                    Quantity = 1

                });
                Session["cart"] = cart;
            }


            return View();

        }

        public ActionResult Buy(int id)
        {
            Album albums = repo.Albums.GetById(id);
            if (Session["cart"] == null)
            {
                List<CartLine> cart = new List<CartLine>();
                cart.Add(new CartLine
                {
                    Albums = albums,
                    Quantity = 1
                });
                Session["cart"] = cart;
            }
            else
            {
                List<CartLine> cart = (List<CartLine>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new CartLine { Albums = albums, Quantity = 1 });
                }
                Session["cart"] = cart;
            }

            return View();


            //return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            List<CartLine> cart = (List<CartLine>)Session["cart"];
            int index = isExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            //return RedirectToAction("Index", "Home");
            return RedirectToAction("Buy", "Cart");

            // return Redirect("Buy");
        }
        private int isExist(int id)
        {
            List<CartLine> cart = (List<CartLine>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Albums.AlbumId.Equals(id))
                    return i;
            return -1;
        }
        public void Clear()
        {
            List<CartLine> cart = new List<CartLine>();
            cart.Clear();
        }

    }
}
