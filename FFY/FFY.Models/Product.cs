using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FFY.Models
{
    public class Product
    {
        public Product()
        {
        }

        public Product(string name,
            decimal price,
            int discountPercentage,
            bool hasDiscount,
            string description,
            int categoryId,
            Category category,
            int roomId,
            Room room,
            string imagePath,
            bool isDeleted = false) : this()
        {
            this.Name = name;
            this.Price = price;
            this.DiscountPercentage = discountPercentage;
            this.HasDiscount = hasDiscount;
            this.Description = description;
            this.CategoryId = categoryId;
            this.Category = category;
            this.RoomId = roomId;
            this.Room = room;
            this.ImagePath = imagePath;
            this.IsDeleted = isDeleted;
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

        public bool IsDeleted { get; set; }
    }
}