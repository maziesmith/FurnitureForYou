using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Administration.AddProduct
{
    public class AddProductEventArgs : EventArgs
    {
        public AddProductEventArgs(Product product)
        {
            if(product == null)
            {
                throw new ArgumentNullException("Product cannot be null");
            }

            this.Product = product;
        }

        public Product Product { get; set; }
    }
}
