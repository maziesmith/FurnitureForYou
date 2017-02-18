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
        ShoppingCart GetCart(string cartId);

        void AssignShoppingCart(ShoppingCart shoppingCart);

        void Add(int quantity, Product product, string cartId);

        void Remove(int productId, string cartId);

        int CartProductsCount(string cartId);
    }
}
