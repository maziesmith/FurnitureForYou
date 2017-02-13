using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FFY.Models
{
    public class City
    {
        private ICollection<Adress> addresses;

        public City()
        {
            this.Adresses = new HashSet<Adress>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Adress> Adresses
        {
            get
            {
                return this.addresses;
            }
            set
            {
                this.addresses = value;
            }
        }

    }
}