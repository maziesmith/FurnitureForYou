using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Furniture.Products
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public string Query { get; set; }
    }
}
