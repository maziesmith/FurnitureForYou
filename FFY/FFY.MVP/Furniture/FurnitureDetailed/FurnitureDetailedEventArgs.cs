using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Furniture.FurnitureDetailed
{
    public class FurnitureDetailedEventArgs : EventArgs
    {
        public FurnitureDetailedEventArgs(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
