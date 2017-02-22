using FFY.Models;
using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Services.Handlers
{
    public class DiscountProductsHandler : Handler
    {
        private const string DiscountProductsPath = "/furniture/discount";
        private const int productsAmount = 1000;

        protected override bool CanHandle(string path, string room, string category, string search, bool rangeProvided)
        {
            return path == DiscountProductsPath
                && room == null
                && category == null
                && search == null
                && !rangeProvided;
        }

        protected override IEnumerable<Product> Handle(IProductsService productsService, string room, string category, string search, bool rangeProvided, int from, int to)
        {
            return productsService.GetDiscountProducts(productsAmount).Reverse();
        }
    }
}
