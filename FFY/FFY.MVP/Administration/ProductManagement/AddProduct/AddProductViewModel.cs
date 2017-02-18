using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Administration.ProductManagement.AddProduct
{
    public class AddProductViewModel
    {
        public IEnumerable<Room> Rooms { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}
