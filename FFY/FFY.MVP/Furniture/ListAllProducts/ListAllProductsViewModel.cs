using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Furniture.ListAllProducts
{
    public class ListAllProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
