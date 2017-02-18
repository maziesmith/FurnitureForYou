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
            if (product == null)
            {
                throw new ArgumentNullException("Product cannot be null");
            }

            this.Product = product;
        }

        public Product Product { get; set; }
    }
}
