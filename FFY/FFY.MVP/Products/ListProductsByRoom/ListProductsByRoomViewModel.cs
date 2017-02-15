using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Products.ListProductsByRoom
{
    public class ListProductsByRoomViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
