using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Models
{
    public class ShoppingCart
    {
        private ICollection<CartProduct> cartProducts;

        public ShoppingCart()
        {
            this.CartProducts = new HashSet<CartProduct>();
        }

        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public decimal Total { get; set; }

        public ICollection<CartProduct> CartProducts
        {
            get
            {
                return this.cartProducts;
            }
            set
            {
                this.cartProducts = value;
            }
        }
    }
}
