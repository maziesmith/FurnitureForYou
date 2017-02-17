using FFY.Models;
using FFY.Order.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Order.Factories
{
    public interface ICartProductFactory
    {
        ICartProduct CreateCartProduct(int quantity, Product product);
    }
}
