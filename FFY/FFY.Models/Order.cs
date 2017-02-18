using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FFY.Models
{
    public class Order
    {
        private ICollection<CartProduct> products;

        public Order()
        {
            this.Products = new HashSet<CartProduct>();
        }

        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public DateTime SendOn { get; set; }

        [Range(0, 1000000)]
        public decimal Total { get; set; }

        public int? AddressId { get; set; }

        public virtual Address Adress { get; set; }

        [Range(1, 3)]
        public virtual OrderStatusType OrderStatusType { get; set; }

        [Range(1, 2)]
        public virtual OrderPaymentStatusType OrderPaymentStatusType { get; set; }

        public virtual ICollection<CartProduct> Products
        {
            get
            {
                return this.products;
            }
            set
            {
                this.products = value;
            }
        }
    }
}