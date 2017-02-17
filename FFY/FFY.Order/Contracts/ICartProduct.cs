using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Order.Contracts
{
    public interface ICartProduct
    {
        int Quantity { get; set; }

        Product Product { get; set; }
    }
}
