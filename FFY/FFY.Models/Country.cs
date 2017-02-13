using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FFY.Models
{
    public class Country
    {
        private ICollection<City> cities;

        public Country()
        {
            this.Cities = new HashSet<City>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        public virtual ICollection<City> Cities
        {
            get
            {
                return this.cities;
            }
            set
            {
                this.cities = value;
            }
        }
    }
}