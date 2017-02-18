using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Administration.ProductManagement.AddProduct
{
    public class AddProductEventArgs : EventArgs
    {
        public AddProductEventArgs(string name,
            decimal price,
            int discountPercentage,
            bool hasDiscount,
            string description,
            int categoryId,
            Category category,
            int roomId,
            Room room,
            string imagePath)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Product name cannot be null.");
            }

            if (price < 0)
            {
                throw new ArgumentOutOfRangeException("Price cannot be negative.");
            }

            if (discountPercentage < 0 || discountPercentage > 100)
            {
                throw new ArgumentOutOfRangeException("Discount percentage cannot be less than 0 or greater than 100.");
            }

            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException("Product description cannot be null.");
            }

            if (categoryId < 0)
            {
                throw new ArgumentOutOfRangeException("Category Id cannot be negative.");
            }

            if(category == null)
            {
                throw new ArgumentNullException("Product category cannot be null.");
            }

            if (roomId < 0)
            {
                throw new ArgumentOutOfRangeException("Room Id cannot be negative.");
            }

            if (room == null)
            {
                throw new ArgumentNullException("Product room cannot be null.");
            }

            if (string.IsNullOrEmpty(imagePath))
            {
                throw new ArgumentNullException("Product image path cannot be null or empty.");
            }

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
        }

        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }

        public int DiscountPercentage { get; set; }

        public bool HasDiscount { get; set; }

        public string ImagePath { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Room Room { get; set; }

        public int RoomId { get; set; }
    }
}
