using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Products.GetProductById
{
    public class GetProductByIdEventArgs : EventArgs
    {
        public GetProductByIdEventArgs(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
