using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FFY.Models
{
    public class Adress
    {
        private ICollection<Order> orders;
        public Adress()
        {
            this.Orders = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string StreetAdress { get; set; }

        public int? CityId { get; set; }

        public virtual City City { get; set; }

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