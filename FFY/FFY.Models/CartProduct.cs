using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Models
{
    public class CartProduct
    {
        public CartProduct()
        {

        }

        public CartProduct(int quantity, Product product) : this()
        {
            this.Quantity = quantity;
            this.Product = product;
        }

        [Key]
        public int Id { get; set; }

        public int Quantity { get; set; }

        public decimal Total { get; set; }

        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
