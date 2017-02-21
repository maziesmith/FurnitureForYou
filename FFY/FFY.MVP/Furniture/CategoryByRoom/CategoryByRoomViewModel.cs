using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Furniture.CategoryByRoom
{
    public class CategoryByRoomViewModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public string Room { get; set; }
    }
}
