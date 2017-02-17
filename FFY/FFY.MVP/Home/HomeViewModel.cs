using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Home
{
    public class HomeViewModel
    {
        public IEnumerable<Product> DiscountProducts { get; set; }

        public IEnumerable<Product> LatestProducts { get; set; }
    }
}
