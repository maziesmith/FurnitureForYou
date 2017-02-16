using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Administration.EditProduct
{
    public class EditProductViewModel
    {
        public Product Product { get; set; }

        public IEnumerable<Room> Rooms { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}
