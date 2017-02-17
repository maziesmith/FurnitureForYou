using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FFY.Models
{
    public class Order
    {
        private ICollection<Product> products;

        public Order()
        {
            this.Products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public DateTime SendOn { get; set; }

        [Range(0, 1000000)]
        public decimal TotalCost { get; set; }

        public int? AddressId { get; set; }

        public virtual Address Adress { get; set; }

        [Range(1, 3)]
        public virtual OrderStatusType OrderStatusType { get; set; }

        public virtual ICollection<Product> Products
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