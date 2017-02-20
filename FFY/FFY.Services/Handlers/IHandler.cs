using FFY.Models;
using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Services.Handlers
{
    public interface IHandler
    {
        void SetSuccessor(IHandler successor);

        IEnumerable<Product> HandleProducts(IProductsService productsService,
            string path,
            string room,
            string category,
            string search,
            bool rangeProvided,
            int from,
            int to);
    }
}
