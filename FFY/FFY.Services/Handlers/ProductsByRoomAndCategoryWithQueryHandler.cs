using FFY.Models;
using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Services.Handlers
{
    public class ProductsByRoomAndCategoryWithQueryHandler : Handler
    { 
        protected override bool CanHandle(string path, string room, string category, string search, bool rangeProvided)
        {
            return room != null
                && category != null
                && (search != null || rangeProvided);
        }
        protected override IEnumerable<Product> Handle(IProductsService productsService, string room, string category, string search, bool rangeProvided, int from, int to)
        {
            var products = productsService.GetProductsByRoomAndCategorySpecialFiltered(room, category);

            //TODO: change it
            if (search != null)
            {
                products = products.Where(p => p.Name.ToLower().Contains(search.ToLower()));
            }

            if (rangeProvided)
            {
                products = products.Where(p => p.DiscountedPrice >= from && p.DiscountedPrice <= to);
            }

            return products;
        }
    }
}
