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

        protected override bool CanHandle(string path, string room, string category)
        {
            return path == DiscountProductsPath && room == null && category == null;
        }
        protected override IEnumerable<Product> Handle(string room, string category, IProductsService productsService)
        {
            return productsService.GetDiscountProducts(productsAmount);
        }
    }
}
