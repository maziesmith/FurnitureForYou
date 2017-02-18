using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public ShoppingCart(string userId, User user, decimal total = 0) : this()
        {
            this.UserId = userId;
            this.User = user;
            this.Total = total;
        }

        [Key]
        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public decimal Total { get; set; }

        public virtual ICollection<CartProduct> CartProducts
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
