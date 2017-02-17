using System;
using System.ComponentModel.DataAnnotations;

namespace FFY.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Email { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(500)]
        public string EmailContent { get; set; }

        public DateTime SendOn { get; set; }

        public string UserProccessedById { get; set; }

        public virtual User UserProcessedBy { get; set; }

        [Range(1, 3)]
        public virtual ContactStatusType ContactStatusType { get; set; }
    }
}