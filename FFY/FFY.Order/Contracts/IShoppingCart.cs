using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Order.Contracts
{
    public interface IShoppingCart
    {
        ICollection<ICartProduct> CartProducts { get; }

        void Add(int quantity, int productId);

        void Remove(int productId);

        void Clear();

        decimal Total();
    }
}
