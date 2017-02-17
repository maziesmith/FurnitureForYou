using FFY.Models;
using FFY.Order.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Order
{
    public class CartProduct : ICartProduct
    {
        public CartProduct(int quantity, Product product)
        {
            this.Quantity = quantity;
            this.Product = product;
        }

        public int Quantity { get; set; }

        public Product Product { get; set; }

    }
}
