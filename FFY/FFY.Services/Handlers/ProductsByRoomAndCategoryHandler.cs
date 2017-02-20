using FFY.Models;
using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Services.Handlers
{
    public class ProductsByRoomAndCategoryHandler : Handler
    { 
        protected override bool CanHandle(string path, string room, string category)
        {
            return room != null && category != null;
        }
        protected override IEnumerable<Product> Handle(string room, string category, IProductsService productsService)
        {
            //TODO: change it
            return productsService.GetProductsByRoomSpecialFiltered(room);
        }
    }
}
