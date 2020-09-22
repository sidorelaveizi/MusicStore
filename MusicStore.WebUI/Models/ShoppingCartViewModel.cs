using MusicStore.Domain.Entities;
using System.Collections.Generic;

namespace MusicStore.WebUI.Models
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}
//}