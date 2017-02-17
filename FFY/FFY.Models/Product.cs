using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FFY.Models
{
    public class Product
    {
        private ICollection<Order> orders;

        public Product()
        {
            this.Orders = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Name { get; set; }

        [Range(0, 100000)]
        public decimal Price { get; set; }

        [Range(0, 100)]
        public int DiscountPercentage { get; set; }

        public bool HasDiscount { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(1000)]
        public string Description { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int? RoomId { get; set; }

        public virtual Room Room { get; set; }

        public string ImagePath { get; set; }


        public virtual ICollection<Order> Orders
        {
            get
            {
                return this.orders;
            }
            set
            {
                this.orders = value;
            }
        }
    }
}