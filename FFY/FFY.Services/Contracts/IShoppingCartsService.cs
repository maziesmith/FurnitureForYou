using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Services.Contracts
{
    public interface IShoppingCartsService
    {
        void AssignShoppingCart(ShoppingCart shoppingCart);

        void Add(int quantity, Product product, string cartId);
    }
}
