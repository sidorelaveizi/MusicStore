using MusicStore.Domain.Entities;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Domain.Abstract
{
    public interface IShoppingRepository : IGenericRepository<Cart>
    {
        //ShoppingCart GetCart(HttpContextBase context);
        //ShoppingCart GetCart(Controller controller);

        Cart GetCart(HttpContextBase context);
        Cart GetCart(Controller controller);
        void AddToCart(Album album);
        int RemoveFromCart(int id);
        void EmptyCart();
        List<Cart> GetCartItems();
        int GetCount();
        decimal GetTotal();
        int CreateOrder(Order order);
        string GetCartId(HttpContextBase context);
        void MigrateCart(string userName);



    }
}
