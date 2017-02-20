using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Administration.ProductManagement.EditProduct
{
    public class EditProductEventArgs : EventArgs
    {
        public EditProductEventArgs(Product product)
        {
            this.Product = product;
        }

        public Product Product { get; set; }
    }
}
